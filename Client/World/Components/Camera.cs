using Client.World.Interfaces;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MonoGame.Extended;
using MonoGame.Extended.ViewportAdapters;
using System;

namespace Client.World.Components
{
    internal class Camera : Component, IMovable, IRotatable
    {
        private float maximumZoom = float.MaxValue;
        private readonly ViewportAdapter viewportAdapter;
        private Rectangle screenBounds;
        private float minimumZoom;
        private float zoom;

        public Camera(IComponentOwner owner, GraphicsDevice graphicsDevice, ViewportAdapter viewportAdapter) : base(owner)
        {
            this.viewportAdapter = viewportAdapter;
            this.Rotation = 0.0f;
            this.Zoom = 1f;
            this.Origin = new Vector2((float)viewportAdapter.VirtualWidth / 2f, (float)viewportAdapter.VirtualHeight / 2f);
            this.Position = Vector2.Zero;
        }

        public Vector2 Position { get; set; }

        public float Rotation { get; set; }

        public Vector2 Origin { get; set; }

        public Vector2 Center
        {
            get
            {
                return this.Position + this.Origin;
            }
        }

        public float Zoom
        {
            get
            {
                return this.zoom;
            }
            set
            {
                if ((double)value < (double)this.MinimumZoom || (double)value > (double)this.MaximumZoom)
                    throw new ArgumentException("Zoom must be between MinimumZoom and MaximumZoom");
                this.zoom = value;
            }
        }

        public float MinimumZoom
        {
            get
            {
                return this.minimumZoom;
            }
            set
            {
                if ((double)value < 0.0)
                    throw new ArgumentException("MinimumZoom must be greater than zero");
                if ((double)this.Zoom < (double)value)
                    this.Zoom = this.MinimumZoom;
                this.minimumZoom = value;
            }
        }

        public Point MapBounds
        {
            get { return this.screenBounds.Size; }
        }

        public float MaximumZoom
        {
            get
            {
                return this.maximumZoom;
            }
            set
            {
                if ((double)value < 0.0)
                    throw new ArgumentException("MaximumZoom must be greater than zero");
                if ((double)this.Zoom > (double)value)
                    this.Zoom = value;
                this.maximumZoom = value;
            }
        }

        public bool HasScreenBounds
        {
            get
            {
                return screenBounds != Rectangle.Empty;
            }
        }

        public RectangleF BoundingRectangle
        {
            get
            {
                Vector3[] corners = this.GetBoundingFrustum().GetCorners();
                Vector3 vector31 = corners[0];
                Vector3 vector32 = corners[2];
                float width = vector32.X - vector31.X;
                float height = vector32.Y - vector31.Y;
                return new RectangleF(vector31.X, vector31.Y, width, height);
            }
        }

        public void Move(Vector2 direction)
        {
            this.Position = this.Position + Vector2.Transform(direction, Matrix.CreateRotationZ(-this.Rotation));
        }

        public void Rotate(float deltaRadians)
        {
            this.Rotation += deltaRadians;
        }

        public void ZoomIn(float deltaZoom)
        {
            this.ClampZoom(this.Zoom + deltaZoom);
        }

        public void ZoomOut(float deltaZoom)
        {
            this.ClampZoom(this.Zoom - deltaZoom);
        }

        private void ClampZoom(float value)
        {
            if ((double)value < (double)this.MinimumZoom)
                this.Zoom = this.MinimumZoom;
            else
                this.Zoom = (double)value > (double)this.MaximumZoom ? this.MaximumZoom : value;
        }

        public void SetScreenBounds(Rectangle screenBounds)
        {
            this.screenBounds = screenBounds;
        }

        public void LookAt(Vector2 position)
        {
            var wantedPosition = position - new Vector2((float)this.viewportAdapter.VirtualWidth / 2f, (float)this.viewportAdapter.VirtualHeight / 2f);
            if (screenBounds != Rectangle.Empty)
            {
                var width = screenBounds.Width - (float)this.viewportAdapter.VirtualWidth;
                var height = screenBounds.Height - (float)this.viewportAdapter.VirtualHeight;

                if (wantedPosition.X <= screenBounds.X)
                    wantedPosition.X = screenBounds.Y;
                if (wantedPosition.Y <= screenBounds.Y)
                    wantedPosition.Y = screenBounds.Y;
                if (wantedPosition.X >= width)
                    wantedPosition.X = width;
                if (wantedPosition.Y >= height)
                    wantedPosition.Y = height;

                this.Position = wantedPosition;
            }
        }

        public Vector2 WorldToScreen(float x, float y)
        {
            return this.WorldToScreen(new Vector2(x, y));
        }

        public Vector2 WorldToScreen(Vector2 worldPosition)
        {
            Viewport viewport = this.viewportAdapter.Viewport;
            return Vector2.Transform(worldPosition + new Vector2((float)viewport.X, (float)viewport.Y), this.GetViewMatrix());
        }

        public Vector2 ScreenToWorld(float x, float y)
        {
            return this.ScreenToWorld(new Vector2(x, y));
        }

        public Vector2 ScreenToWorld(Vector2 screenPosition)
        {
            Viewport viewport = this.viewportAdapter.Viewport;
            return Vector2.Transform(screenPosition - new Vector2((float)viewport.X, (float)viewport.Y), Matrix.Invert(this.GetViewMatrix()));
        }

        public Matrix GetViewMatrix(Vector2 parallaxFactor)
        {
            return this.GetVirtualViewMatrix(parallaxFactor) * this.viewportAdapter.GetScaleMatrix();
        }

        private Matrix GetVirtualViewMatrix(Vector2 parallaxFactor)
        {
            return Matrix.CreateTranslation(new Vector3(-this.Position * parallaxFactor, 0.0f)) * Matrix.CreateTranslation(new Vector3(-this.Origin, 0.0f)) * Matrix.CreateRotationZ(this.Rotation) * Matrix.CreateScale(this.Zoom, this.Zoom, 1f) * Matrix.CreateTranslation(new Vector3(this.Origin, 0.0f));
        }

        private Matrix GetVirtualViewMatrix()
        {
            return this.GetVirtualViewMatrix(Vector2.One);
        }

        public Matrix GetViewMatrix()
        {
            return this.GetViewMatrix(Vector2.One);
        }

        public Matrix GetInverseViewMatrix()
        {
            return Matrix.Invert(this.GetViewMatrix());
        }

        private Matrix GetProjectionMatrix(Matrix viewMatrix)
        {
            Matrix result = Matrix.CreateOrthographicOffCenter(0.0f, (float)this.viewportAdapter.VirtualWidth, (float)this.viewportAdapter.VirtualHeight, 0.0f, -1f, 0.0f);
            Matrix.Multiply(ref viewMatrix, ref result, out result);
            return result;
        }

        public BoundingFrustum GetBoundingFrustum()
        {
            return new BoundingFrustum(this.GetProjectionMatrix(this.GetVirtualViewMatrix()));
        }

        public ContainmentType Contains(Point point)
        {
            return this.Contains(point.ToVector2());
        }

        public ContainmentType Contains(Vector2 vector2)
        {
            return this.GetBoundingFrustum().Contains(new Vector3(vector2.X, vector2.Y, 0.0f));
        }

        public ContainmentType Contains(Rectangle rectangle)
        {
            Vector3 max = new Vector3((float)(rectangle.X + rectangle.Width), (float)(rectangle.Y + rectangle.Height), 0.5f);
            return this.GetBoundingFrustum().Contains(new BoundingBox(new Vector3((float)rectangle.X, (float)rectangle.Y, 0.5f), max));
        }
    }
}
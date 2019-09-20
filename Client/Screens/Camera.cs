using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MonoGame.Extended;
using MonoGame.Extended.ViewportAdapters;

namespace Client.Screens
{
    public class Camera : Camera<Vector2>, IMovable, IRotatable
    {
        private float _maximumZoom = float.MaxValue;
        private readonly ViewportAdapter _viewportAdapter;
        private Rectangle _screenBounds;
        private float _minimumZoom;
        private float _zoom;

        public Camera(GraphicsDevice graphicsDevice)
          : this((ViewportAdapter)new DefaultViewportAdapter(graphicsDevice))
        {
        }

        public Camera(ViewportAdapter viewportAdapter)
        {
            this._viewportAdapter = viewportAdapter;
            this.Rotation = 0.0f;
            this.Zoom = 1f;
            this.Origin = new Vector2((float)viewportAdapter.VirtualWidth / 2f, (float)viewportAdapter.VirtualHeight / 2f);
            this.Position = Vector2.Zero;
        }

        public override Vector2 Position { get; set; }

        public override float Rotation { get; set; }

        public override Vector2 Origin { get; set; }

        public override Vector2 Center
        {
            get
            {
                return this.Position + this.Origin;
            }
        }

        public override float Zoom
        {
            get
            {
                return this._zoom;
            }
            set
            {
                if ((double)value < (double)this.MinimumZoom || (double)value > (double)this.MaximumZoom)
                    throw new ArgumentException("Zoom must be between MinimumZoom and MaximumZoom");
                this._zoom = value;
            }
        }

        public override float MinimumZoom
        {
            get
            {
                return this._minimumZoom;
            }
            set
            {
                if ((double)value < 0.0)
                    throw new ArgumentException("MinimumZoom must be greater than zero");
                if ((double)this.Zoom < (double)value)
                    this.Zoom = this.MinimumZoom;
                this._minimumZoom = value;
            }
        }

        public override float MaximumZoom
        {
            get
            {
                return this._maximumZoom;
            }
            set
            {
                if ((double)value < 0.0)
                    throw new ArgumentException("MaximumZoom must be greater than zero");
                if ((double)this.Zoom > (double)value)
                    this.Zoom = value;
                this._maximumZoom = value;
            }
        }

        public bool HasScreenBounds
        {
            get
            {
                return _screenBounds != Rectangle.Empty;
            }
        }
        public override RectangleF BoundingRectangle
        {
            get
            {
                Vector3[] corners = this.GetBoundingFrustum().GetCorners();
                Vector3 vector3_1 = corners[0];
                Vector3 vector3_2 = corners[2];
                float width = vector3_2.X - vector3_1.X;
                float height = vector3_2.Y - vector3_1.Y;
                return new RectangleF(vector3_1.X, vector3_1.Y, width, height);
            }
        }

        public override void Move(Vector2 direction)
        {
            this.Position = this.Position + Vector2.Transform(direction, Matrix.CreateRotationZ(-this.Rotation));
        }

        public override void Rotate(float deltaRadians)
        {
            this.Rotation += deltaRadians;
        }

        public override void ZoomIn(float deltaZoom)
        {
            this.ClampZoom(this.Zoom + deltaZoom);
        }

        public override void ZoomOut(float deltaZoom)
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
            this._screenBounds = screenBounds;
        }
        public override void LookAt(Vector2 position)
        {
            var wantedPosition = position - new Vector2((float)this._viewportAdapter.VirtualWidth / 2f, (float)this._viewportAdapter.VirtualHeight / 2f);
            if (_screenBounds != Rectangle.Empty)
            {
                var width = _screenBounds.Width - (float) this._viewportAdapter.VirtualWidth;
                var height = _screenBounds.Height - (float)this._viewportAdapter.VirtualHeight;

                if (wantedPosition.X <= _screenBounds.X)
                    wantedPosition.X = _screenBounds.Y;
                if (wantedPosition.Y <= _screenBounds.Y)
                    wantedPosition.Y = _screenBounds.Y;
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

        public override Vector2 WorldToScreen(Vector2 worldPosition)
        {
            Viewport viewport = this._viewportAdapter.Viewport;
            return Vector2.Transform(worldPosition + new Vector2((float)viewport.X, (float)viewport.Y), this.GetViewMatrix());
        }

        public Vector2 ScreenToWorld(float x, float y)
        {
            return this.ScreenToWorld(new Vector2(x, y));
        }

        public override Vector2 ScreenToWorld(Vector2 screenPosition)
        {
            Viewport viewport = this._viewportAdapter.Viewport;
            return Vector2.Transform(screenPosition - new Vector2((float)viewport.X, (float)viewport.Y), Matrix.Invert(this.GetViewMatrix()));
        }

        public Matrix GetViewMatrix(Vector2 parallaxFactor)
        {
            return this.GetVirtualViewMatrix(parallaxFactor) * this._viewportAdapter.GetScaleMatrix();
        }

        private Matrix GetVirtualViewMatrix(Vector2 parallaxFactor)
        {
            return Matrix.CreateTranslation(new Vector3(-this.Position * parallaxFactor, 0.0f)) * Matrix.CreateTranslation(new Vector3(-this.Origin, 0.0f)) * Matrix.CreateRotationZ(this.Rotation) * Matrix.CreateScale(this.Zoom, this.Zoom, 1f) * Matrix.CreateTranslation(new Vector3(this.Origin, 0.0f));
        }

        private Matrix GetVirtualViewMatrix()
        {
            return this.GetVirtualViewMatrix(Vector2.One);
        }

        public override Matrix GetViewMatrix()
        {
            return this.GetViewMatrix(Vector2.One);
        }

        public override Matrix GetInverseViewMatrix()
        {
            return Matrix.Invert(this.GetViewMatrix());
        }

        private Matrix GetProjectionMatrix(Matrix viewMatrix)
        {
            Matrix result = Matrix.CreateOrthographicOffCenter(0.0f, (float)this._viewportAdapter.VirtualWidth, (float)this._viewportAdapter.VirtualHeight, 0.0f, -1f, 0.0f);
            Matrix.Multiply(ref viewMatrix, ref result, out result);
            return result;
        }

        public override BoundingFrustum GetBoundingFrustum()
        {
            return new BoundingFrustum(this.GetProjectionMatrix(this.GetVirtualViewMatrix()));
        }

        public ContainmentType Contains(Point point)
        {
            return this.Contains(point.ToVector2());
        }

        public override ContainmentType Contains(Vector2 vector2)
        {
            return this.GetBoundingFrustum().Contains(new Vector3(vector2.X, vector2.Y, 0.0f));
        }

        public override ContainmentType Contains(Rectangle rectangle)
        {
            Vector3 max = new Vector3((float)(rectangle.X + rectangle.Width), (float)(rectangle.Y + rectangle.Height), 0.5f);
            return this.GetBoundingFrustum().Contains(new BoundingBox(new Vector3((float)rectangle.X, (float)rectangle.Y, 0.5f), max));
        }
    }
}

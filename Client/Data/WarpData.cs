using System;
using System.Collections.Generic;
using System.Text;

namespace Client.Data
{
    class WarpData
    {
        public readonly int XTilePosition;
        public readonly int YTilePosition;
        public readonly int XWarpPosition;
        public readonly int YWarpPosition;
        public readonly int XMapId;
        public readonly int YMapId;

        public WarpData(int xWarpPosition, int yWarpPosition, int xMapId, int yMapId)
            : this(0,0, xWarpPosition, yWarpPosition, xMapId, yMapId)
        {

        }
        public WarpData(int xTilePosition, int yTilePosition, int xWarpPosition, int yWarpPosition, int xMapId, int yMapId)
        {
            this.XTilePosition = xTilePosition;
            this.YTilePosition = yTilePosition;
            this.XWarpPosition = xWarpPosition;
            this.YWarpPosition = yWarpPosition;
            this.XMapId = xMapId;
            this.YMapId = yMapId;
        }
    }
}

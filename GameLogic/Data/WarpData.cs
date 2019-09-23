namespace GameLogic.Data
{
    public class WarpData
    {
        public int XTilePosition;
        public int YTilePosition;
        public int XWarpPosition;
        public int YWarpPosition;
        public int XMapId;
        public int YMapId;
        public int Badge;

        public WarpData()
            : this(0, 0, 0, 0, 0, 0)
        {

        }
        public WarpData(int xWarpPosition, int yWarpPosition, int xMapId, int yMapId)
            : this(0,0, xWarpPosition, yWarpPosition, xMapId, yMapId)
        {

        }
        public WarpData(int xTilePosition, int yTilePosition, int xWarpPosition, int yWarpPosition, int xMapId, int yMapId)
            : this(xTilePosition, yTilePosition, xWarpPosition, yWarpPosition, xMapId, yMapId, 0)
        {

        }
        public WarpData(int xTilePosition, int yTilePosition, int xWarpPosition, int yWarpPosition, int xMapId, int yMapId, int badge)
        {
            this.XTilePosition = xTilePosition;
            this.YTilePosition = yTilePosition;
            this.XWarpPosition = xWarpPosition;
            this.YWarpPosition = yWarpPosition;
            this.XMapId = xMapId;
            this.YMapId = yMapId;
            this.Badge = badge;
        }
    }
}

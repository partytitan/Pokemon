using System.Collections.Generic;

namespace GameLogic.Data
{
    public class MapData
    {
        public List<NpcData> NpcList;
        public List<WarpData> WarpList;

        public MapData()
        {
            NpcList = new List<NpcData>();
            WarpList = new List<WarpData>();
        }
    }
}
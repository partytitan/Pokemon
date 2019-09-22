using System;
using System.Collections.Generic;
using System.Text;

namespace MyContentPipeline.Data
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

using System;
using System.Collections.Generic;
using System.Text;
using Client.Common;

namespace MyContentPipeline.Data
{
    public class NpcData
    {
        public string Name;
        public Directions Direction;
        public int Sprite;
        public int XTilePosition;
        public int YTilePosition;
        public Directions OriginalDirection;
        public string Pokemon;
        public int PartySize;
        public int Badge;
        public List<int> Speech;
        public bool Healer;
        public bool Box;
        public bool Shop;
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace Client.World
{
    interface IWarpComponent : IComponent
    {
        void Warp(int xTilePosition, int yTilePosition, int xWarpPosition, int yWarpPosition, int xWarpMap, int yWarpMap);
    }
}

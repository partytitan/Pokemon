using System;
using System.Collections.Generic;
using System.Text;

namespace Client.World
{
    interface ICollisionObject
    {
        bool Collide(int xTilePosition, int yTilePosition);
    }
}

using System;
using System.Collections.Generic;
using System.Text;
using GameLogic.Common;

namespace Client.World.Interfaces
{
    interface ILedgeCollisionComponent : ICollisionComponent
    {
        bool CheckLedgeDirection(int xTilePosition, int yTilePosition, Directions direction);
    }
}

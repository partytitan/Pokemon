using System;
using System.Collections.Generic;
using System.Text;
using Client.World;

namespace Client.Services.World
{
    internal interface IEntityLoader
    {
        IList<Entity> LoadEntities(string mapName);
    }
}

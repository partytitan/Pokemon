using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using Microsoft.Xna.Framework.Content;
using MyContentPipeline.Data;

namespace Client
{
    class MapDataReader : ContentTypeReader<MapData>
    {
        /// <summary>
        /// Loads an imported shader.
        /// </summary>
        protected override MapData Read(ContentReader input,
            MapData existingInstance)
        {
            if (input == null)
                return default(MapData);
            BinaryFormatter bf = new BinaryFormatter();
            using (MemoryStream ms = new MemoryStream(input.ReadBytes(input.ReadInt32())))
            {
                object obj = bf.Deserialize(ms);
                return (MapData)obj;
            }
        }
    }
}

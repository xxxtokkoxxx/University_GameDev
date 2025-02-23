using System;
using Newtonsoft.Json;

namespace Codebase.SaveLoad
{
    [Serializable]
    public class PlayerData
    {
        [JsonConstructor]
        public PlayerData(SerializableVector3 position, SerializableVector3 rotation)
        {
            Position = position;
            Rotation = rotation;
        }

        public SerializableVector3 Position { get; set; }
        public SerializableVector3 Rotation { get; set; }
    }
}
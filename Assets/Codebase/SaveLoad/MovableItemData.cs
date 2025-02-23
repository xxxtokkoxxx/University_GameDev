using Codebase.Environment;
using Newtonsoft.Json;
using UnityEngine;

namespace Codebase.SaveLoad
{
    public class MovableItemData
    {
        [JsonConstructor]
        public MovableItemData(Vector3 position, Vector3 rotation, MovableItemType movableItemType)
        {
            Position = new SerializableVector3(position);
            Rotation = new SerializableVector3(rotation);
            MovableItemType = movableItemType;
        }

        public MovableItemType MovableItemType { get; set; }
        public SerializableVector3 Position { get; set; }
        public SerializableVector3 Rotation { get; set; }
    }
}
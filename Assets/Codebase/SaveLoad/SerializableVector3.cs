using System;
using Newtonsoft.Json;
using UnityEngine;

namespace Codebase.SaveLoad
{
    [Serializable]
    public class SerializableVector3
    {
        [JsonConstructor]
        public SerializableVector3(Vector3 transformPosition)
        {
            X = transformPosition.x;
            Y = transformPosition.y;
            Z = transformPosition.z;
        }

        public float X { get; set; }
        public float Y { get; set; }
        public float Z { get; set; }
    }
}
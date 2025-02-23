using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Codebase.SaveLoad
{
    [Serializable]
    public class LevelData
    {
        [JsonConstructor]
        public LevelData(List<MovableItemData> itemData)
        {
            Items = itemData;
        }

        public List<MovableItemData> Items { get; set; }
    }
}
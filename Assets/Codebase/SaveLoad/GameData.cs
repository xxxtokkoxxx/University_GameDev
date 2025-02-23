using System;
using Newtonsoft.Json;

namespace Codebase.SaveLoad
{
    [Serializable]
    public class GameData
    {
        [JsonConstructor]
        public GameData(LevelData levelData, PlayerData playerData)
        {
            LevelData = levelData;
            PlayerData = playerData;
        }

        public LevelData LevelData { get; set; }
        public PlayerData PlayerData { get; set; }
    }
}
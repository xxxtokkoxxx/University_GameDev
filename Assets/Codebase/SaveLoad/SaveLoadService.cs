using System.IO;
using Codebase.Environment;
using Newtonsoft.Json;
using UnityEngine;

namespace Codebase.SaveLoad
{
    public class SaveLoadService : ISaveLoadService
    {
        public const string SaveFileName = "Save.txt";

        public void SaveGameData()
        {
            LevelEnvironment levelEnvironment = Object.FindFirstObjectByType<LevelEnvironment>();
            Player.Player player = Object.FindFirstObjectByType<Player.Player>();

            LevelData levelData = levelEnvironment.GetLevelData();
            SerializableVector3 playerPosition = new SerializableVector3(player.transform.position);
            SerializableVector3 playerRotation = new SerializableVector3(player.transform.rotation.eulerAngles);

            PlayerData playerData = new PlayerData(playerPosition, playerRotation);
            GameData gameData = new GameData(levelData, playerData);

            string gameDataJson = JsonConvert.SerializeObject(gameData, Formatting.Indented);
            SaveToFile(gameDataJson, SaveFileName);
        }

        public GameData LoadGameData()
        {
            string filePath = Path.Combine(Application.persistentDataPath, SaveFileName);

            if (!File.Exists(filePath))
            {
                return null;
            }

            string gameDataJson = LoadFromFile(filePath);
            GameData gameData = JsonConvert.DeserializeObject<GameData>(gameDataJson);

            return gameData;
        }

        private void SaveToFile(string data, string fileName)
        {
            string filePath = Path.Combine(Application.persistentDataPath, fileName);

            try
            {
                File.WriteAllText(filePath, data);
            }
            catch (IOException e)
            {
                Debug.LogError("Error writing to file: " + e.Message);
            }
        }

        private string LoadFromFile(string filePath)
        {
            if (File.Exists(filePath))
            {
                try
                {
                    return File.ReadAllText(filePath);
                }
                catch (IOException e)
                {
                    Debug.LogError("Error reading file: " + e.Message);
                }
            }
            else
            {
                Debug.LogWarning("File not found: " + filePath);
            }

            return "";
        }
    }
}
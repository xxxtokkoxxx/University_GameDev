using System.Collections.Generic;
using Codebase.SaveLoad;
using UnityEngine;

namespace Codebase.Environment
{
    public class LevelEnvironment : MonoBehaviour
    {
        [SerializeField] private List<SpawnPoint> _spawnPoints;
        private MovableItem _movableItemCubePrefab;
        private MovableItem _movableItemCylinderPrefab;

        private List<MovableItem> _createdItems = new();
        private const string MovableObjectCube = "MovableObjectCube";
        private const string MovableObjectCylinder = "MovableObjectCylinder";

        public void SetLevelData(LevelData data)
        {
            foreach (MovableItemData itemData in data.Items)
            {
                MovableItem itemReference = itemData.MovableItemType == MovableItemType.Cube ? _movableItemCubePrefab : _movableItemCylinderPrefab;

                MovableItem createdItem = Instantiate(itemReference, new Vector3(itemData.Position.X, itemData.Position.Y, itemData.Position.Z),
                    Quaternion.Euler(new Vector3(itemData.Rotation.X, itemData.Rotation.Y, itemData.Rotation.Z)));

                _createdItems.Add(createdItem);
            }
        }

        public void LoadDefaultLevel()
        {
            foreach (SpawnPoint spawnPoint in _spawnPoints)
            {
                MovableItem itemReference = spawnPoint.MovableItemType == MovableItemType.Cube ? _movableItemCubePrefab : _movableItemCylinderPrefab;
                MovableItem createdItem = Instantiate(itemReference, spawnPoint.transform.position, spawnPoint.transform.rotation);
                _createdItems.Add(createdItem);
            }
        }

        public LevelData GetLevelData()
        {
            List<MovableItemData> itemData = new List<MovableItemData>();

            foreach (MovableItem createdItem in _createdItems)
            {
                itemData.Add(new MovableItemData(createdItem.transform.position, createdItem.transform.rotation.eulerAngles, createdItem.MovableItemType));
            }

            LevelData levelData = new LevelData(itemData);
            return levelData;
        }

        public void LoadMovableItems()
        {
            _movableItemCubePrefab = Resources.Load<MovableItem>(MovableObjectCube);
            _movableItemCylinderPrefab = Resources.Load<MovableItem>(MovableObjectCylinder);
        }
    }
}
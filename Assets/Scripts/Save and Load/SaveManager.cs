using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
namespace MyGameNamespace.SaveLoad
{
    public class SaveManager : MonoBehaviour
    {
        public static SaveManager instance;
        private string fileName;
        public GameData gameData; // Game data reference

        private List<ISaveManager> saveManagers;
        private FileDataHandler dataHandler;

        private void Awake()
        {
            if (instance != null)
                Destroy(instance.gameObject);
            else
                instance = this;
        }

        private void Start()
        {
            dataHandler = new FileDataHandler(Application.persistentDataPath, fileName);
            saveManagers = FindAllSaveManagers();
            LoadGame();
        }

        public void NewGame()
        {
            gameData = new GameData();
        }

        public void LoadGame()
        {
            // Load game data from storage (placeholder comment)

            gameData = dataHandler.Load();

            if (this.gameData == null)
            {
                Debug.Log("No saved data found!");
                NewGame();
            }

            foreach (ISaveManager saveManager in saveManagers)
            {
                saveManager.SaveData(ref gameData); // Pass by ref here too
            }
        }

        public void SaveGame()
        {
            // Save data to storage (placeholder comment)
            foreach (ISaveManager saveManager in saveManagers)
            {
                saveManager.SaveData(ref gameData); // Pass by ref
            }

            dataHandler.Save(gameData);

        }

        private void OnApplicationQuit()
        {
            SaveGame();
        }

        private List<ISaveManager> FindAllSaveManagers()
        {
            IEnumerable<ISaveManager> saveManagers = FindObjectsOfType<MonoBehaviour>().OfType<ISaveManager>();
            return new List<ISaveManager>(saveManagers);
        }
    }
}
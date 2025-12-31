using System.IO;
using UnityEngine;
using VaultSim.Data;

namespace VaultSim.Services
{
    /// <summary>
    /// Handles disk persistence using JSON. Versioned for future migrations.
    /// </summary>
    public sealed class SaveService
    {
        private const string SaveFileName = "vaultsim-save.json";
        private readonly string savePath;

        public SaveService()
        {
            savePath = Path.Combine(Application.persistentDataPath, SaveFileName);
        }

        public void Save(GameStateSnapshot snapshot)
        {
            var json = JsonUtility.ToJson(snapshot, true);
            File.WriteAllText(savePath, json);
        }

        public bool TryLoad(out GameStateSnapshot snapshot)
        {
            if (!File.Exists(savePath))
            {
                snapshot = new GameStateSnapshot();
                return false;
            }

            var json = File.ReadAllText(savePath);
            snapshot = JsonUtility.FromJson<GameStateSnapshot>(json);
            return true;
        }
    }
}

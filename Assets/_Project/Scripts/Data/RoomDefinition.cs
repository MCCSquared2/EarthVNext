using UnityEngine;

namespace VaultSim.Data
{
    [CreateAssetMenu(fileName = "RoomDefinition", menuName = "VaultSim/Room Definition")]
    public class RoomDefinition : ScriptableObject
    {
        public string Id = "room";
        public string DisplayName = "Room";
        public Vector2Int Size = new Vector2Int(1, 1);
        public string ProducesResourceId = "energy";
        public float ProductionPerSecond = 1f;
    }
}

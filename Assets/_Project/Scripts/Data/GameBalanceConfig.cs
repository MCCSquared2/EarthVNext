using UnityEngine;

namespace VaultSim.Data
{
    [CreateAssetMenu(fileName = "GameBalanceConfig", menuName = "VaultSim/Game Balance Config")]
    public class GameBalanceConfig : ScriptableObject
    {
        public ResourceDefinition[] InitialResources;
        public RoomDefinition[] RoomConfigs;
        public DwellerDefinition[] StarterDwellers;
    }
}

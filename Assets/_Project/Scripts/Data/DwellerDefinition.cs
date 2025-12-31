using UnityEngine;

namespace VaultSim.Data
{
    [CreateAssetMenu(fileName = "DwellerDefinition", menuName = "VaultSim/Dweller Definition")]
    public class DwellerDefinition : ScriptableObject
    {
        public string Id = "dweller";
        public string DisplayName = "Dweller";
        public int BaseProductivity = 1;
        public int BaseHappiness = 50;
    }
}

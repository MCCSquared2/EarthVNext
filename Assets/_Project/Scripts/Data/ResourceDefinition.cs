using UnityEngine;

namespace VaultSim.Data
{
    [CreateAssetMenu(fileName = "ResourceDefinition", menuName = "VaultSim/Resource Definition")]
    public class ResourceDefinition : ScriptableObject
    {
        public string Id = "resource";
        public string DisplayName = "Resource";
        public float StartingAmount = 0f;
        public float Capacity = 100f;
    }
}

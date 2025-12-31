using System.Collections.Generic;
using System.Linq;
using VaultSim.Data;

namespace VaultSim.Services
{
    public sealed class ResourceService
    {
        private readonly Dictionary<string, float> amounts = new();

        public ResourceService(IEnumerable<ResourceDefinition> initialDefinitions)
        {
            foreach (var definition in initialDefinitions)
            {
                amounts[definition.Id] = definition.StartingAmount;
            }
        }

        public float GetAmount(string resourceId)
        {
            return amounts.TryGetValue(resourceId, out var value) ? value : 0f;
        }

        public void AddAmount(string resourceId, float delta)
        {
            if (!amounts.ContainsKey(resourceId))
            {
                amounts[resourceId] = 0f;
            }

            amounts[resourceId] += delta;
        }

        public IReadOnlyDictionary<string, float> Snapshot()
        {
            return amounts.ToDictionary(kvp => kvp.Key, kvp => kvp.Value);
        }
    }
}

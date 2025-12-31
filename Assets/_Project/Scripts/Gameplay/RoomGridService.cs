using System.Collections.Generic;
using UnityEngine;
using VaultSim.Core;
using VaultSim.Data;
using VaultSim.Services;

namespace VaultSim.Gameplay
{
    /// <summary>
    /// Manages room placement and simple production over time.
    /// </summary>
    public sealed class RoomGridService
    {
        private readonly Dictionary<Vector2Int, RoomDefinition> placedRooms = new();
        private readonly IReadOnlyCollection<RoomDefinition> availableRooms;

        public RoomGridService(IEnumerable<RoomDefinition> availableRooms)
        {
            this.availableRooms = new List<RoomDefinition>(availableRooms);
        }

        public bool TryPlaceRoom(RoomDefinition definition, Vector2Int position)
        {
            if (placedRooms.ContainsKey(position))
            {
                return false;
            }

            placedRooms[position] = definition;
            return true;
        }

        public void Tick(SimulationTime time, ResourceService resources)
        {
            foreach (var room in placedRooms.Values)
            {
                resources.AddAmount(room.ProducesResourceId, room.ProductionPerSecond * Time.deltaTime);
            }
        }

        public IReadOnlyDictionary<Vector2Int, RoomDefinition> Snapshot() => placedRooms;

        public IReadOnlyCollection<RoomDefinition> AvailableRooms => availableRooms;
    }
}

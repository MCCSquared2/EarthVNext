using System;
using UnityEngine;

namespace VaultSim.Data
{
    [Serializable]
    public class GameStateSnapshot
    {
        public int SaveVersion = 1;
        public float ElapsedSeconds;
        public ResourceSnapshot[] Resources = Array.Empty<ResourceSnapshot>();
        public RoomSnapshot[] Rooms = Array.Empty<RoomSnapshot>();
    }

    [Serializable]
    public class ResourceSnapshot
    {
        public string Id = string.Empty;
        public float Amount;
    }

    [Serializable]
    public class RoomSnapshot
    {
        public string Id = string.Empty;
        public Vector2Int Position;
    }
}

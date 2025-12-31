using UnityEngine;
using VaultSim.Data;
using VaultSim.Gameplay;
using VaultSim.Services;

namespace VaultSim.Core
{
    /// <summary>
    /// Entry point MonoBehaviour that wires up core services for playmode runs.
    /// </summary>
    public sealed class GameBootstrapper : MonoBehaviour
    {
        [SerializeField]
        private GameBalanceConfig balanceConfig;

        private SimulationTime simulationTime;
        private ResourceService resourceService;
        private RoomGridService roomGridService;

        private void Awake()
        {
            simulationTime = new SimulationTime();
            resourceService = new ResourceService(balanceConfig.InitialResources);
            roomGridService = new RoomGridService(balanceConfig.RoomConfigs);
        }

        private void Start()
        {
            Debug.Log("VaultSim bootstrap complete. Ready for gameplay loop.");
        }

        private void Update()
        {
            var delta = Time.deltaTime;
            simulationTime.Tick(delta);
            roomGridService.Tick(simulationTime, resourceService);
        }

        public SimulationTime SimulationTime => simulationTime;

        public ResourceService ResourceService => resourceService;

        public RoomGridService RoomGridService => roomGridService;
    }
}

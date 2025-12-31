using System;

namespace VaultSim.Core
{
    /// <summary>
    /// Simple simulation clock that accumulates elapsed time and exposes tick events.
    /// </summary>
    public sealed class SimulationTime
    {
        public event Action<float>? OnTick;

        public float ElapsedSeconds { get; private set; }

        public void Tick(float deltaTime)
        {
            ElapsedSeconds += deltaTime;
            OnTick?.Invoke(deltaTime);
        }
    }
}

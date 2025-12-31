using NUnit.Framework;
using VaultSim.Core;

namespace VaultSim.Tests
{
    public class SimulationTimeTests
    {
        [Test]
        public void Tick_IncreasesElapsedTime()
        {
            var time = new SimulationTime();
            time.Tick(1.5f);
            Assert.AreEqual(1.5f, time.ElapsedSeconds);
        }
    }
}

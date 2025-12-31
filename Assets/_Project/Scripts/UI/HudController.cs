using System.Text;
using UnityEngine;
using UnityEngine.UI;
using VaultSim.Core;
using VaultSim.Services;

namespace VaultSim.UI
{
    /// <summary>
    /// Minimal HUD to surface resource totals.
    /// </summary>
    [RequireComponent(typeof(Canvas))]
    public sealed class HudController : MonoBehaviour
    {
        [SerializeField]
        private Text resourceText;

        [SerializeField]
        private GameBootstrapper bootstrapper;

        private ResourceService resourceService;

        private void Start()
        {
            if (bootstrapper == null)
            {
                bootstrapper = FindObjectOfType<GameBootstrapper>();
            }

            resourceService = bootstrapper.ResourceService;
            UpdateHud();
        }

        private void Update()
        {
            UpdateHud();
        }

        private void UpdateHud()
        {
            if (resourceService == null || resourceText == null)
            {
                return;
            }

            var builder = new StringBuilder();
            foreach (var kvp in resourceService.Snapshot())
            {
                builder.AppendLine($"{kvp.Key}: {kvp.Value:0.0}");
            }

            resourceText.text = builder.ToString();
        }
    }
}

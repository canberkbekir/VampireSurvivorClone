using UnityEngine;

namespace Upgrades
{
    [CreateAssetMenu(fileName = "UpgradeContainer", menuName = "Upgrade/UpgradeContainer")]
    public class UpgradeContainer : ScriptableObject
    { 
        [SerializeField] private UpgradeData[] _upgrades;
        public UpgradeData[] Upgrades => _upgrades;
        
        public UpgradeData[] GetRandomUpgrades(int count)
        {
            var randomUpgrades = new UpgradeData[count];
            for (var i = 0; i < count; i++)
            {
                randomUpgrades[i] = _upgrades[Random.Range(0, _upgrades.Length)];
            }
            return randomUpgrades;
        }
    }
}

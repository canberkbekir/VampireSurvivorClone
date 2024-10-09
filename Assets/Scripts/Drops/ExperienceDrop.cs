using Global;
using UnityEngine;

namespace Drops
{
    public class ExperienceDrop : Drop
    {
        [Header("References")]
        [SerializeField] private LevelUpManager _levelUpManager;
        
        private void Start()
        {
            _levelUpManager = GameManager.Instance.levelUpManager;
        }
        public override void OnDrop()
        {
            var dropCount = Random.Range(1, _levelUpManager.droppableExperienceCount+1);
            for (var i = 0; i < dropCount; i++)
            {
                base.OnDrop(); 
            }
        }
         
    }
}

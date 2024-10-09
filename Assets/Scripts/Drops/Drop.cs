using DG.Tweening;
using Global;
using UnityEngine;

namespace Drops
{
    public abstract class Drop : MonoBehaviour
    { 
        [Header("Settings")]
        [SerializeField] private float maxDropDistance = 4f;
        [SerializeField] private float minimumDropDistance = 1f;
        [SerializeField] private float dropDuration = 0.5f;
        
        [Space]
        [Header("References")]
        [SerializeField] protected GameObject dropPrefab;
        

        public virtual void OnDrop()
        {
            var dropObject = Instantiate(dropPrefab, transform.position, Quaternion.identity);
            var dropDirection = Random.insideUnitCircle.normalized;
            var dropRange = Random.Range(minimumDropDistance, maxDropDistance);
            var dropPosition = (Vector2)transform.position + dropDirection * dropRange;

            dropObject.transform.DOMove(dropPosition,dropDuration, false).SetEase(Ease.OutCubic);
        } 
    }
}

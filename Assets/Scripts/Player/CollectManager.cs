using System;
using DG.Tweening;
using Global;
using UnityEngine;

namespace Player
{
    public class CollectManager : MonoBehaviour
    {
        [SerializeField] private LevelUpManager _levelUpManager; 
        [SerializeField] private float collectDuration = 0.5f;
        [SerializeField] private CircleCollider2D _collider;
        private void Awake()
        {
            _levelUpManager = GameManager.Instance.levelUpManager;
            _collider = GetComponent<CircleCollider2D>(); 
        }

        private void Start()
        {
            _collider.radius = _levelUpManager.GetCollectDistance(); 
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag("Experience"))
            {
             
                other.enabled = false;
                
                other.transform.parent = transform;
                other.transform.DOLocalMove(Vector3.zero, collectDuration).SetEase(Ease.OutCubic).OnComplete(() =>
                {
                    _levelUpManager.AddExperience();
                    Destroy(other.gameObject);
                });
            }
            
        }
    }
}

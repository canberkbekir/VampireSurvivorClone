using System;
using System.Collections.Generic;
using UnityEngine;
using Weapons;

namespace Player.Hands
{
    public class HandManager : MonoBehaviour
    { 
        [Header("Settings")]
        [SerializeField] private int maxHandCount = 6;
        [SerializeField] private float radius = 5f; 
        [SerializeField] private GameObject handPrefab;  
        
        [Space] 
        [Header("Starting Values")]
        [SerializeField] private WeaponData weaponData;      
        [SerializeField] private int startingHandCount = 1;
        
        [Space]
        [Header("References")]
        [SerializeField] private PlayerAttackZone _playerAttackZone;  
        
        [Header("Debug")]
        [SerializeField] private List<Hand> Hands = new List<Hand>();
        
        private void Start()
        { 
            StartWithHands(); 
        } 

        private void StartWithHands()
        {
            for (var i = 0; i < startingHandCount; i++)
            {
                AddHand(weaponData);
            }
        }
        
        private void PlaceHandsOnCircle()
        {
            var angleStep = 360f / Hands.Count;

            for (var i = 0; i < Hands.Count; i++)
            {
                var angle = i * angleStep;
                var angleRad = angle * Mathf.Deg2Rad;

                var x = Mathf.Cos(angleRad) * radius;
                var y = Mathf.Sin(angleRad) * radius;

                var handPosition = new Vector2(x, y);
                Hands[i].transform.localPosition = handPosition;
            }
        }
        
        public void AddHand(WeaponData data)
        {
            if (Hands.Count >= maxHandCount) return;
 
            var newHandObject = Instantiate(handPrefab, gameObject.transform);

            var newHand = newHandObject.GetComponent<Hand>();
 
            newHand.SetupHand(data);
 
            Hands.Add(newHand);
 
            PlaceHandsOnCircle();
        }

        
        public PlayerAttackZone GetPlayerAttackZone()
        {
            return _playerAttackZone;
        }

        private void OnDrawGizmos()
        {
            Gizmos.color = Color.white;
            Gizmos.DrawWireSphere(transform.position, radius);
        }
    }
}

using UnityEngine;

namespace Player
{
    public class PlayerMovement : MonoBehaviour
    {  
        [Header("References")]
        [SerializeField] private Input.InputObject _inputObject;
        [SerializeField] private Rigidbody2D _rigidbody2D;
        [SerializeField] private PlayerStats _playerStats;

        private Vector2 _movement;
        
        private float _speed => _playerStats.speed;

        private void Awake()
        {
            _inputObject.OnMovementEvent += OnMovement;
            _rigidbody2D = GetComponent<Rigidbody2D>();
            _playerStats = GetComponent<PlayerStats>();
             
        } 
        private void OnMovement(Vector2 movement)
        {
            _movement = movement;
        }

        private void Update()
        {
            Move(); 
        }

        private void Move()
        { 
            _rigidbody2D.velocity = _movement * _speed; 
        }
    }
}

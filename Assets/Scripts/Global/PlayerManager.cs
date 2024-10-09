using Player;
using UnityEngine;
using UnityEngine.Serialization;

namespace Global
{
    public class PlayerManager : MonoBehaviour
    { 
        public static PlayerManager Instance { get; private set; }
        
        [FormerlySerializedAs("player")]
        [Header("References")]
        [SerializeField] private Player.Player _player;
        [SerializeField] private GameObject playerPrefab;


        private void Awake()
        {
            if (Instance != null && Instance != this) 
            { 
                Destroy(this); 
            } 
            else 
            { 
                Instance = this; 
            }  
        } 
        
        public void SetPlayer(Player.Player player)
        {
            this._player = player;
        }
        
        public Player.Player GetPlayer()
        {
            return _player;
        }
        
        public PlayerStats GetPlayerStats()
        {
            return _player.GetComponent<PlayerStats>();
        }
        
        public GameObject GetPlayerPrefab()
        {
            return playerPrefab;
        }
    }
}

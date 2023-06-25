using UnityEngine;

//Represents a player awareness controller for an enemy in a game
public class PlayerAwarenessController : MonoBehaviour
{
    public bool AwareOfPlayer { get; private set; } 
    public Vector2 DirectionToPlayer { get; private set; }
    [SerializeField]
    private float _playerAwarenessDistance;
    private Transform _player;

    private void Awake()
    {
        _player = FindObjectOfType<PlayerMovement>().transform;
    }

    void Update()
    {
        Vector2 enemyToPlayerVector = _player.position - transform.position;
        DirectionToPlayer = enemyToPlayerVector.normalized; 
        
        // Check if the distance between the enemy and the player is within the awareness distance
        AwareOfPlayer = enemyToPlayerVector.magnitude <= _playerAwarenessDistance; 
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CustomEventBus;

public class ObstecleController : MonoBehaviour
{
    [SerializeField] private Transform _UpperObstacle;
    [SerializeField] private Transform _BottomObstacle;
    [SerializeField, Range(0,10)] private float _speed = 1f;
    private Rigidbody2D rigidbody;
    void OnEnable()
    {
        EventBus.endGame += OnEndGame;  
    }
    void OnDisable()
    {
        EventBus.endGame -= OnEndGame;  
    }
    private void OnEndGame() => _speed = 0f;
    void Awake()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        int randomGap = Random.Range(CONSTANTS.SCRIPT_CONSTANS.MinGapBetweenObstacle, CONSTANTS.SCRIPT_CONSTANS.MaxGapBetweenObstacle);
        _UpperObstacle.position = new Vector2(_UpperObstacle.position.x, _UpperObstacle.position.y + randomGap / 2); 
        _BottomObstacle.position = new Vector2(_BottomObstacle.position.x, _BottomObstacle.position.y - randomGap / 2);
    }
    void Update()
    {
        rigidbody.velocity = new Vector2(-1 * _speed, 0);
    }
}

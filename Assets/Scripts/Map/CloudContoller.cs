using UnityEngine;
using CustomEventBus;

public class CloudContoller : MonoBehaviour
{
    [SerializeField, Range(0, 10)] private float _speed = 1f;
    private Rigidbody2D rigidbody;
    void OnEnable()
    {
        EventBus.endGame += OnEndGame;
    }
    void OnDisable()
    {
        EventBus.endGame -= OnEndGame;
    }
    void Awake()
    {
        rigidbody = GetComponent<Rigidbody2D>();
    }
    private void OnEndGame() => _speed = 0f;
    void Update()
    {
        rigidbody.velocity = new Vector2(-1 * _speed, 0);
    }
}

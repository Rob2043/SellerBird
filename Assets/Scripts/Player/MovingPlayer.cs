using UnityEngine;
using CustomEventBus;

public class MovingPlayer : MonoBehaviour
{
    [SerializeField,Range(0,10)] private float _speed = 1f;
    [SerializeField] private Animator animator;
    private Rigidbody2D _rigidbody;
    public void Init()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        animator.Play("Bird 2 Cyan");
    }
    private void OnEnable()
    {
        EventBus.endGame += OnEndGame;
    }
    private void OnDisable()
    {
        EventBus.endGame -= OnEndGame;
    }
    private void OnEndGame()
    {
        _speed = 0f;
        animator.speed = 0f;
    }
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            _rigidbody.AddForce(Vector2.up * _speed, ForceMode2D.Impulse);
        }
    }
}

using UnityEngine;
using CustomEventBus;
using CustomInterfaces;
using UnityEngine.Rendering.Universal;

public class ObstecleController : MonoBehaviour , IMainObstcle
{
    [SerializeField] private Transform _UpperObstacle;
    [SerializeField] private Transform _BottomObstacle;
    [SerializeField, Range(0, 10)] private float _speed = 1f;
    private Rigidbody2D rigidbody;
    private float _stateYPosition = 0;
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
        ChanhgePosition();
    }
    void Update()
    {
        rigidbody.velocity = new Vector2(-1 * _speed, 0);
    }
    public void ChanhgePosition()
    {
        float randomGap = Random.Range(CONSTANTS.SCRIPT_CONSTANS.MinGapBetweenObstacle, CONSTANTS.SCRIPT_CONSTANS.MaxGapBetweenObstacle);
        _UpperObstacle.position = new Vector2(_UpperObstacle.position.x, _stateYPosition + randomGap / 2);
        _BottomObstacle.position = new Vector2(_BottomObstacle.position.x, _stateYPosition - randomGap / 2);
    }
}

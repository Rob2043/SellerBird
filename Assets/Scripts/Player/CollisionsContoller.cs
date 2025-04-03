using CustomInterfaces;
using UnityEngine;
using CustomEventBus;

public class CollisionsController : MonoBehaviour
{
    private  IObstacle obstacle;
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("EndGame") && collision.TryGetComponent(out obstacle))
        {
            obstacle.collision2D.isTrigger = false;
            Time.timeScale = 0f;
        }
        if (collision.gameObject.CompareTag("BottomCollision"))
        {
            EventBus.endGame();
        }
        if (collision.CompareTag("Score"))
        {
            EventBus.addPoints.Invoke(1);
        }
    }
}

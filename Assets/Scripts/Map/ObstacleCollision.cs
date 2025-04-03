using System.Collections;
using System.Collections.Generic;
using CustomInterfaces;
using UnityEngine;

public class ObstacleCollision : MonoBehaviour, IObstacle
{
    public BoxCollider2D collision2D {get ; set;}
    void Start()
    {
        collision2D = gameObject.GetComponent<BoxCollider2D>();
    }
}

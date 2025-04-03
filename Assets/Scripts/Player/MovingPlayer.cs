using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MovingPlayer : MonoBehaviour
{
    [SerializeField,Range(0,10)] private float _speed = 1f;
    private Rigidbody2D _rigidbody;
    public void Init()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            _rigidbody.AddForce(Vector2.up * _speed, ForceMode2D.Impulse);
        }
    }
}

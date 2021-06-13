using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Bullet : MonoBehaviour
{
    private Rigidbody2D _rigidbody;
    [SerializeField] private float _speed;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        _rigidbody.MovePosition(transform.position + transform.up * _speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Asteroid asteroid))
        {
            asteroid.Destroy();
        }

        if (collision.TryGetComponent(out Enemy enemy))
        {
            enemy.Destroy();
        }

        if (!collision.TryGetComponent(out PlayerController player))
        {
            Destroy(gameObject);
        }
    }
}

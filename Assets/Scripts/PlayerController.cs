using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerController : MonoBehaviour
{
    [SerializeField] private float _thrustSpeed = 1f;
    [SerializeField] private float _turnSpeed = 0.1f;
    private Rigidbody2D _rigidbody;
    private bool _thrusting;
    private float _turnDirection;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        _thrusting = Input.GetKey(KeyCode.W);

        if (Input.GetKey(KeyCode.A))
        {
            _turnDirection = 1f;
        }
        else if (Input.GetKey(KeyCode.D))
        {
            _turnDirection = -1f;
        }
        else
        {
            _turnDirection = 0;
        }
    }

    private void FixedUpdate()
    {
        if (_thrusting)
        {
            _rigidbody.AddForce(transform.up * _thrustSpeed);
        }

        if (_turnDirection != 0)
        {
            _rigidbody.AddTorque(_turnDirection * _turnSpeed);
        }
    }
}

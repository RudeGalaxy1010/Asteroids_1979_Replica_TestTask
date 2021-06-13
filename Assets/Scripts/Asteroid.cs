using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Collider2D))]
public class Asteroid : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private Asteroid _asteroidPrefab;
    private Vector3 _direction;
    private Rigidbody2D _rigidbody;

    private void Start()
    {
        Init();
    }

    private void Init()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _direction = transform.up * _speed;
    }

    private void Update()
    {
        _rigidbody.MovePosition(transform.position + _direction * _speed * Time.deltaTime);

        if (_rigidbody.position.magnitude > 50f)
        {
            Destroy(gameObject);
        }
    }

    public void Destroy()
    {
        if (_asteroidPrefab != null)
        {
            var asteroid = Instantiate(_asteroidPrefab, transform.position, transform.rotation);
            asteroid.transform.Rotate(Vector3.forward, 90);
            asteroid = Instantiate(_asteroidPrefab, transform.position, transform.rotation);
            asteroid.transform.Rotate(Vector3.forward, -90);
        }

        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out PlayerController player))
        {
            FindObjectOfType<LosePanel>().ShowPanel();
        }
    }
}

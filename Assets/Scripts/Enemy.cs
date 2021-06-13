using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Collider2D))]
public class Enemy : MonoBehaviour
{
    [SerializeField] private float _speed;
    private Transform _target;
    private Rigidbody2D _rigidbody;

    private void Start()
    {
        Init();
    }

    public void Init()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _target = FindObjectOfType<PlayerController>().transform;
    }

    private void Update()
    {
        _rigidbody.position = Vector3.MoveTowards(_rigidbody.position, _target.position, _speed * Time.deltaTime);

        if (_rigidbody.position.magnitude > 50f)
        {
            Destroy(gameObject);
        }
    }

    public void Destroy()
    {
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out PlayerController player))
        {
            FindObjectOfType<LosePanel>().ShowPanel();
            Destroy(gameObject);
        }
    }
}

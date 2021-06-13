using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidSpawner : MonoBehaviour
{
    [SerializeField] private float _spawnFieldSize;
    [SerializeField] private Vector2 _spawnTime;
    [SerializeField] private List<Asteroid> _asteroidPrefabs;

    private void Start()
    {
        Init();
    }

    public void Init()
    {
        StartCoroutine(Spawn());
    }

    private IEnumerator Spawn()
    {
        yield return new WaitForSeconds(Random.Range(_spawnTime.x, _spawnTime.y));
        var prefab = _asteroidPrefabs[Random.Range(0, _asteroidPrefabs.Count)];
        var position = transform.position + Vector3.right * Random.Range(-_spawnFieldSize, _spawnFieldSize);
        var asteroid = Instantiate(prefab, position, transform.rotation);
        StartCoroutine(Spawn());
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireCube(transform.position, new Vector3(_spawnFieldSize * 2, 1f, 1f));
    }
}

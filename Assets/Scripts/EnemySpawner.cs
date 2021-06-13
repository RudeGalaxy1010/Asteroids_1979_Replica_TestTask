using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private float _spawnFieldSize;
    [SerializeField] private List<Enemy> _enemyPrefabs;
    [SerializeField] private float _spawnTime;

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
        yield return new WaitForSeconds(_spawnTime);
        var prefab = _enemyPrefabs[Random.Range(0, _enemyPrefabs.Count)];
        var position = transform.position + Vector3.right * Random.Range(-_spawnFieldSize, _spawnFieldSize);
        var enemy = Instantiate(prefab, position, transform.rotation);
        StartCoroutine(Spawn());
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireCube(transform.position, new Vector3(_spawnFieldSize * 2, 1f, 1f));
    }
}

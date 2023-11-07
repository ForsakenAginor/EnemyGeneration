using System.Collections;
using UnityEngine;

public class Spawners : MonoBehaviour
{
    private readonly float _spawnFrequency = 2;
    private Spawner[] _spawners;
    private bool _isSpawning = true;

    private void Awake()
    {
        _spawners = GetComponentsInChildren<Spawner>();
    }

    private void Start()
    {
        var spawner = StartCoroutine(Spawn());
    }

    private IEnumerator Spawn()
    {
        while (_isSpawning)
        {
            if (_spawners != null && _spawners.Length > 0)
                _spawners[Random.Range(0, _spawners.Length)].SpawnCreature();

            yield return new WaitForSeconds(_spawnFrequency);
        }
    }
}

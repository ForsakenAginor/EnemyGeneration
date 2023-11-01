using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawners : MonoBehaviour
{
    private readonly float _spawnFrequency = 2;
    private Spawner[] _spawners;
    private float _runningTime;

    private void Awake()
    {
        _spawners = GetComponentsInChildren<Spawner>();
    }

    private void Update()
    {
        _runningTime += Time.deltaTime;

        if (_runningTime >= _spawnFrequency)
        {
            _runningTime = 0;

            if(_spawners != null && _spawners.Length > 0)
                _spawners[RandomNumbersGenerator.GenerateRandomNumber(_spawners.Length)].SpawnCreature();
        }
    }
}

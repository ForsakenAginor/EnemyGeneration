using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private Rocket _creature;
    [SerializeField] private float _speed;

    private Vector2 _creatureVelocity;

    private void Awake()
    {
        _creatureVelocity = new Vector2(0, _speed);
    }

    public void SpawnCreature()
    {
        Rocket newCreature = Instantiate(_creature, transform.position, Quaternion.identity);

        if (newCreature.TryGetComponent<Rigidbody2D>(out Rigidbody2D rigidbody))
        {
            rigidbody.velocity = _creatureVelocity;
        }
    }
}

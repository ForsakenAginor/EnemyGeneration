using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private Chaser _creature;
    [SerializeField] private Transform _target;

    public void SpawnCreature()
    {
        Chaser newCreature = Instantiate(_creature, transform.position, Quaternion.identity);
        newCreature.SetTarget(_target);
    }
}

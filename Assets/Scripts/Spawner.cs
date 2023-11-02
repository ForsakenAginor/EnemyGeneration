using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private Rocket _creature;
    [SerializeField] private Transform _target;

    public void SpawnCreature()
    {
        Rocket newCreature = Instantiate(_creature, transform.position, Quaternion.identity);
        newCreature.Target = _target;
    }
}

using Unity.Mathematics;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent (typeof(BoxCollider2D))]
public class Chaser : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private ParticleSystem _detonateEffect;

    private Transform _target;

    public void SetTarget(Transform target)
    {
        _target = target;
    }

    private void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, _target.transform.position, Time.deltaTime * _speed);
        RotateToTarget();
    }

    private void RotateToTarget()
    {
        float PiInDegrees = 180;
        transform.rotation = Quaternion.identity;
        float tangens = (_target.transform.position.x - transform.position.x) / (_target.transform.position.y - transform.position.y);
        float angle = math.atan(tangens) * PiInDegrees / math.PI;

        if (angle < 0 && _target.transform.position.x > transform.position.x)
            angle = PiInDegrees + angle;
        else if (angle > 0 && _target.transform.position.x < transform.position.x)
            angle = angle - PiInDegrees;

        transform.Rotate(new Vector3(0, 0, 0 - angle));
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.collider.TryGetComponent(out Target target))
        {
            Instantiate(_detonateEffect, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }
}

using Unity.Mathematics;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent (typeof(BoxCollider2D))]
public class Rocket : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private ParticleSystem _detonateEffect;

    public Transform Target { get; set; }

    private void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, Target.transform.position, Time.deltaTime * _speed);
        RotateToTarget();
    }

    private void RotateToTarget()
    {
        float PiInDegrees = 180;
        transform.rotation = Quaternion.identity;
        float tangens = (Target.transform.position.x - transform.position.x) / (Target.transform.position.y - transform.position.y);
        float angle = math.atan(tangens) * PiInDegrees / math.PI;

        if (angle < 0 && Target.transform.position.x > transform.position.x)
            angle = PiInDegrees + angle;
        else if (angle > 0 && Target.transform.position.x < transform.position.x)
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

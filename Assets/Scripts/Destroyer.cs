using UnityEngine;

public class Destroyer : MonoBehaviour
{
    private float _destructionDelay = 5;

    private void Start()
    {
        Destroy(gameObject, _destructionDelay);
    }
}

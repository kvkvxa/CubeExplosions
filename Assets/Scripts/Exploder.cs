using UnityEngine;

public class Exploder : MonoBehaviour
{

    private float _explosionForce = 5f;

    public void ApplyExplosionForce(Cube cube)
    {
        if (cube.Rigidbody != null)
        {
            Vector3 explosionDirection = Random.onUnitSphere;

            cube.Rigidbody.AddForce(explosionDirection * _explosionForce, ForceMode.Impulse);
        }
    }
}
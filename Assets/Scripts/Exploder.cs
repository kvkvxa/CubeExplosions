using UnityEngine;

public class Exploder : MonoBehaviour
{
    private float _explosionForce = 5f;
    private float _explosionRadius = 5f;

    public void ApplyExplosionForce(Cube cube)
    {
        Vector3 explosionCenter = cube.transform.position;
        float scaleDependentMultiplier = 1 / cube.transform.localScale.x;

        _explosionRadius *= scaleDependentMultiplier;
        _explosionForce *= scaleDependentMultiplier;

        Collider[] colliders = Physics.OverlapSphere(explosionCenter, _explosionRadius);

        foreach (var collider in colliders)
        {
            Rigidbody affectedObject = collider.GetComponent<Rigidbody>();

            if (affectedObject != null)
            {
                Vector3 explosionDirection = collider.transform.position - explosionCenter;
                float distance = explosionDirection.magnitude;

                float explosionFadeRatio = distance / _explosionRadius;

                explosionDirection.Normalize();
                float force = Mathf.Lerp(_explosionForce, 0, explosionFadeRatio);

                affectedObject.AddForce(explosionDirection * force, ForceMode.Impulse);
            }
        }
    }
}
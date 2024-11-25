using UnityEngine;

public class Exploder : MonoBehaviour
{
    private float _generalExplosionForce = 3f;
    private float _generalExplosionRadius = 3f;

    public void ApplyExplosionForce(Cube cube)
    {
        Vector3 explosionCenter = cube.transform.position;
        float scaleDependentMultiplier = 1 / cube.transform.localScale.x;

        float individualExplosionRadius = _generalExplosionRadius * scaleDependentMultiplier;
        float individualExplosionForce = _generalExplosionForce * scaleDependentMultiplier;

        Collider[] colliders = Physics.OverlapSphere(explosionCenter, individualExplosionRadius);

        foreach (var collider in colliders)
        {
            Rigidbody affectedObject = collider.GetComponent<Rigidbody>();

            if (affectedObject != null)
            {
                Vector3 explosionDirection = collider.transform.position - explosionCenter;
                float distance = explosionDirection.magnitude;

                float explosionFadeRatio = distance / individualExplosionRadius;

                explosionDirection.Normalize();
                float force = Mathf.Lerp(individualExplosionForce, 0, explosionFadeRatio);

                affectedObject.AddForce(explosionDirection * force, ForceMode.Impulse);
            }
        }
    }
}
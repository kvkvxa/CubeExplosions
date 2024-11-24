using UnityEngine;

public class Divider : MonoBehaviour
{
    [SerializeField] private DividingChanceCalculator _dividingChanceCalculator;
    [SerializeField] private CubeFactory _cubeFactory;

    private float _scaleDivider = 2f;
    private int minCubes = 2;
    private int maxCubes = 6;

    private float _explosionForce = 5f;

    public void AttachToCube(DissociatingCube cube)
    {
        cube.CubeClicked += Divide;
    }

    private void Divide(DissociatingCube cube)
    {
        Vector3 previousScale = cube.transform.localScale;
        Vector3 newScale = previousScale / _scaleDivider;
        Vector3 position = cube.transform.position;

        if (_dividingChanceCalculator.GetChance(previousScale))
        {
            for (int i = 0; i < Random.Range(minCubes, maxCubes); i++)
            {
                DissociatingCube newCube = _cubeFactory.Create(newScale, this, position);
                ApplyExplosionForce(newCube);
            }
        }

        Destroy(cube.gameObject);
    }
    private void ApplyExplosionForce(DissociatingCube cube)
    {
        Rigidbody cubeRigidBody = cube.GetComponent<Rigidbody>();
        if (cubeRigidBody != null)
        {
            Vector3 explosionDirection = Random.onUnitSphere;

            cubeRigidBody.AddForce(explosionDirection * _explosionForce, ForceMode.Impulse);
        }
    }
}
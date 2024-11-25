using UnityEngine;

public class Divider : MonoBehaviour
{
    [SerializeField] private DividingChanceCalculator _dividingChanceCalculator;
    [SerializeField] private CubeFactory _cubeFactory;
    [SerializeField] private Cube _firstCube;
    [SerializeField] private Exploder _exploder;

    private float _scaleDivider = 2f;

    private int _minCubes = 2;
    private int _maxCubes = 6;

    private void Awake()
    {
        _firstCube.Clicked += Divide;
    }

    private void OnDestroy()
    {
        _firstCube.Clicked -= Divide;
    }

    public void Init(Cube cube)
    {
        cube.Clicked += Divide;
    }

    private void Divide(Cube cube)
    {
        Vector3 previousScale = cube.transform.localScale;
        Vector3 newScale = previousScale / _scaleDivider;

        Vector3 position = cube.transform.position;

        int cubesCount = Random.Range(_minCubes, _maxCubes + 1);

        if (_dividingChanceCalculator.IsDividing(previousScale))
        {
            for (int i = 0; i < cubesCount; i++)
            {
                Cube newCube = _cubeFactory.Create(newScale, this, position);
            }
        }

        _exploder.ApplyExplosionForce(cube);

        cube.Clicked -= Divide;
        Destroy(cube.gameObject);
    }
}
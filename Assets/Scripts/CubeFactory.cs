using System.Collections.Generic;
using UnityEngine;

public class CubeFactory : MonoBehaviour
{
    [SerializeField] private Cube _cubePrefab;

    private readonly List<Color> _colors = new();

    private void Start()
    {
        FillColors();
    }

    public Cube Create(Vector3 scale, Vector3 previousPosition)
    {
        Vector3 randomOffset = Random.insideUnitSphere * 0.5f;
        Vector3 newPosition = previousPosition + randomOffset;

        Cube newCube = Instantiate(_cubePrefab, newPosition, Quaternion.identity);
        newCube.transform.localScale = scale;

        Renderer renderer = newCube.Renderer;
        renderer.material.color = GetRandomColor();

        return newCube;
    }

    private void FillColors()
    {
        _colors.Add(Color.red);
        _colors.Add(Color.green);
        _colors.Add(Color.blue);
        _colors.Add(Color.cyan);
        _colors.Add(Color.magenta);
        _colors.Add(Color.yellow);
        _colors.Add(Color.black);
        _colors.Add(Color.gray);
    }

    private Color GetRandomColor()
    {
        return _colors[Random.Range(0, _colors.Count)];
    }
}
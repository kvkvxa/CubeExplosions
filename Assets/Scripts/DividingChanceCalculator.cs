using UnityEngine;

public class DividingChanceCalculator : MonoBehaviour
{
    [SerializeField] private DissociatingCube _cubePrefab;

    private static Vector3 s_originalScale;
    
    private bool _isDividing;
    private float _dividingChance;

    public bool IsDividing => _isDividing;

    private static readonly System.Random _random = new();

    private void Start()
    {
        s_originalScale = _cubePrefab.transform.localScale;
    }
    
    public bool GetChance(Vector3 scale)
    {
        _dividingChance = scale.x / s_originalScale.x;
        _isDividing = _random.NextDouble() < _dividingChance;

        return _isDividing;
    }
}
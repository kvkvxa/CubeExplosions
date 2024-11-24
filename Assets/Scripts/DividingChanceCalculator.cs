using UnityEngine;

public class DividingChanceCalculator : MonoBehaviour
{
    [SerializeField] private Cube _cubePrefab;

    private Vector3 _originalScale;
    
    private float _dividingChance;

    private void Start()
    {
        _originalScale = _cubePrefab.transform.localScale;
    }
    
    public bool IsDividing(Vector3 scale)
    {
        _dividingChance = scale.x / _originalScale.x;

        return Random.value < _dividingChance;
    }
}
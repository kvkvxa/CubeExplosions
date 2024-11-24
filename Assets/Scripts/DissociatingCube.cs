using System;
using UnityEngine;

[RequireComponent(typeof(BoxCollider))]
[RequireComponent(typeof(MeshRenderer))]
[RequireComponent(typeof(Rigidbody))]
public class DissociatingCube : MonoBehaviour
{
    [SerializeField] private Divider _divider;

    public event Action<DissociatingCube> CubeClicked;

    private void Start()
    {
        if (_divider != null)
        {
            _divider.AttachToCube(this);
        }
    }

    private void OnMouseDown()
    {
        CubeClicked?.Invoke(this);
    }
}
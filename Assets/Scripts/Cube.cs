using System;
using UnityEngine;

[RequireComponent(typeof(BoxCollider))]
[RequireComponent(typeof(Renderer))]
[RequireComponent(typeof(Rigidbody))]
public class Cube : MonoBehaviour
{
    [field: SerializeField]
    public Rigidbody Rigidbody { get; private set; }

    [field: SerializeField]
    public Renderer Renderer { get; private set; }

    public event Action<Cube> Clicked;

    private void Awake()
    {
        Rigidbody = GetComponent<Rigidbody>();
        Renderer = GetComponent<Renderer>();
    }

    private void OnMouseDown()
    {
        Clicked?.Invoke(this);
    }
}

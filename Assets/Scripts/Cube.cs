using System;
using UnityEngine;

[RequireComponent(typeof(BoxCollider))]
[RequireComponent(typeof(Renderer))]
[RequireComponent(typeof(Rigidbody))]
public class Cube : MonoBehaviour
{
    private Rigidbody _rigidbody;
    private Renderer _renderer;

    public event Action<Cube> Clicked;

    public Rigidbody Rigidbody => _rigidbody;
    public Renderer Renderer => _renderer;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _renderer = GetComponent<Renderer>();
    }

    private void OnMouseDown()
    {
        Clicked?.Invoke(this);
    }
}
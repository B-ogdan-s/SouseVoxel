using System;
using System.Collections;
using UnityEngine;

public abstract class Entity : MonoBehaviour
{
    [SerializeField] protected EntityInfo _entityInfo;
    [SerializeField] private Animator _animator;

    protected Vector3 _direction = Vector3.zero;
    private const int _rotateStap = 20;

    public Animator Animator => _animator;

    public abstract void Move();
    public abstract void Rotate();

    public void SetDirection(Vector3 direction)
    {
        _direction = direction;
    }
}

[Serializable]
public struct EntityInfo
{
    [SerializeField] private Transform _modelTransform;
    [SerializeField] private float _speed;
    [SerializeField] private float _rotateTime;

    public Transform ModelTransform => _modelTransform;
    public float Speed => _speed;
    public float RotateTime => _rotateTime;
}

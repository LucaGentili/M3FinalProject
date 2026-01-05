using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animations : MonoBehaviour
{
    private Animator _animator;
    [SerializeField] private string _hSpeedName = "hSpeed";
    [SerializeField] private string _vSpeedName = "vSpeed";
    [SerializeField] private string _isMoving = "isMoving";

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    public void SetDirectionalSpeed(Vector2 speed)
    {
        SetHorizontalSpeed(speed.x);
        SetVerticalSpeed(speed.y);
    }

    public void SetHorizontalSpeed(float speed)
    {
        _animator.SetFloat(_hSpeedName, speed);
    }

    public void SetVerticalSpeed(float speed)
    {
        _animator.SetFloat(_vSpeedName, speed);
    }
    public void SetIsMoving(bool isMoving)
    {
        _animator.SetBool(_isMoving, isMoving);
    }
    public void SetDirectionAndSetMoving(Vector2 direction)
    {
        if (direction != Vector2.zero)
        {
            SetDirectionalSpeed(direction);
            SetIsMoving(true);
        }
        else
        {
            SetIsMoving(false);
        }
    }
}

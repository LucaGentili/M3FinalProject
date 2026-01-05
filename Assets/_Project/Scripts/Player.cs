using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class Player : MonoBehaviour
{
    private float _speed = 2f;
    [SerializeField] private float _h, _v;
    private Rigidbody2D _rb;
    private Animations _animations;
    public Vector2 direction { get; private set; }
    public bool walking = false;

    void Awake()
    {   
        _rb = GetComponent<Rigidbody2D>();
        _animations = GetComponentInChildren<Animations>();
    }
   
    public void Die()
    {
        Destroy(gameObject);
    }
    void Update()
    {
        _h = Input.GetAxis("Horizontal");
        _v = Input.GetAxis("Vertical");

        direction = new Vector2(_h, _v);
        walking = direction != Vector2.zero;
        _animations.SetDirectionAndSetMoving(direction);
    }
    void FixedUpdate()
    {
        float sqrLenght = direction.sqrMagnitude;

        if (walking)
        {
            if (sqrLenght > 1)
            {
                direction = direction / Mathf.Sqrt(sqrLenght);
            }

            _rb.MovePosition(_rb.position + direction * (_speed * Time.deltaTime));
        }
    }
}



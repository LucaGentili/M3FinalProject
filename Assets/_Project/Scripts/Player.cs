using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class Player : LifeController
{
    private float _speed = 2f;
    [SerializeField] private float _h, _v;
    private Rigidbody2D _rb;
    private LifeController lifePlayer;
    public Vector2 direction { get; private set; }
    public bool walking = false;

    void Awake()
    {
        lifePlayer = GetComponent<LifeController>();   
        _rb = GetComponent<Rigidbody2D>();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Enemy"))
        {
            lifePlayer.TakeDamage(lifePlayer.hp);
            if(lifePlayer.IsAlive())
            {
                Die();
            }
        }
    }
    public override void Die()
    {
        Destroy(gameObject);
    }
    void Update()
    {
        _h = Input.GetAxis("Horizontal");
        _v = Input.GetAxis("Vertical");

        direction = new Vector2(_h, _v);
        walking = direction != Vector2.zero;
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



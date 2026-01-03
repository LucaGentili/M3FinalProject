using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Enemy : LifeController
{
    [SerializeField] public float rangeEnemy = 5f;
    public float moveSpeed = 2.5f;
    [SerializeField] public float stopDistance = 0.1f;
    [SerializeField] public Player target;
    public bool walking = false;
    private Rigidbody2D _rb;
    public Vector2 moveDirection;

    void ChaserEnemy()
    {
        moveDirection = (target.transform.position - transform.position).normalized;
        walking = moveDirection != Vector2.zero;
        _rb.velocity = moveDirection * moveSpeed;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            Die();
        }
    }

    void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();

        if(target == null)
        {
            target = FindAnyObjectByType<Player>();
        }
    }

    public override void Die()
    {
        Destroy(gameObject);
    }
    void FixedUpdate()
    {
        ChaserEnemy();
    }
}

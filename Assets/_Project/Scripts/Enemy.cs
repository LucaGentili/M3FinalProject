using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] public float rangeEnemy = 5f;
    public float moveSpeed = 2.5f;
    [SerializeField] public float stopDistance = 0.1f;
    [SerializeField] public Player target;
    [SerializeField] private int damage;
    public bool walking = false;
    private Rigidbody2D _rb;
    public Vector2 moveDirection;

    void ChaserEnemy()
    {
        if (target == null) return; 
        moveDirection = (target.transform.position - transform.position).normalized;
        walking = moveDirection != Vector2.zero;
        _rb.velocity = moveDirection * moveSpeed;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Player player = collision.collider.GetComponent<Player>();
            LifeController lifePlayer = collision.collider.GetComponent<LifeController>();
            if (lifePlayer != null && player != null)
            {
                lifePlayer.TakeDamage(damage);
                if (!lifePlayer.IsAlive())
                {
                    player.Die();
                }
                Die();
            }
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

    public void Die()
    {
        Destroy(gameObject);
    }
    void FixedUpdate()
    {
        ChaserEnemy();
    }
}

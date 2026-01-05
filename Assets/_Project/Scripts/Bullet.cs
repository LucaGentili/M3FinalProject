using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Rendering;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] public int bulletDamage;
    private float lifeSpan = 5f;
    [SerializeField] public float bulletSpeed;
    private Rigidbody2D _rb;
    public Vector2 direction;

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Enemy enm = collision.collider.GetComponent<Enemy>();
            LifeController lifeEnemy = collision.collider.GetComponent<LifeController>();
            if (lifeEnemy != null && enm != null)
            {
                lifeEnemy.TakeDamage(bulletDamage);
                if (lifeEnemy.IsAlive())
                {
                    enm.Die();
                }
            }
        }
        Destroy(gameObject);
    }
    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
        Destroy(gameObject, lifeSpan);
    }
    void FixedUpdate()
    {
        _rb.MovePosition(_rb.position + direction * (bulletSpeed * Time.deltaTime));
    }

    public void SetBulletDir(Vector2 dir)
    {
        direction = dir;
    }
}

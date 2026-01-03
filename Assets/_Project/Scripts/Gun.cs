using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    [SerializeField] private float _fireRate = 3f;
    [SerializeField] private float _fireRange = 8f;
    [SerializeField] public Bullet bulletPrefab;
    private float _lastShoot = 0f;
    public Vector2 shootDir;
    Player player;
    private bool IfShoot()
    {
        float shootTime = _lastShoot + _fireRate;

        if(Time.time > shootTime )
        {
            return true;
        }
        return false;
    }
    private void Shoot(Vector2 direction)
    {
        _lastShoot = Time.time;
        Vector2 spawnPosition = transform.position;
        Vector2 fireDirection = Vector2.up;
        Bullet projectile = Instantiate(bulletPrefab);
        projectile.transform.position = spawnPosition;
        projectile.SetBulletDir(direction);
        
    }
    void Awake()
    {
        player = GetComponentInParent<Player>();
    }
    void Update()
    {
        if (IfShoot()) { Shoot(player.direction); }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Character
{
    [SerializeField] private EnemyData enemyData;
    private PlayerMovement player;
    [SerializeField] private GameObject bulletObject;
    private float currrentShootCooldown;
    private Rigidbody2D rid;
    void Start()
    {
        player = PlayerMovement.instance;
        rid = GetComponent<Rigidbody2D>();
        currrentShootCooldown = enemyData.attackCooldownSpeed;
    }

    void Update()
    {
        Vector3 dir = player.transform.position - this.transform.position;
        rid.velocity = (dir).normalized * enemyData.enemySpeed;
        float aimAngle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg - 90f;
        rid.rotation = aimAngle;

        if(currrentShootCooldown > 0)
        {
            currrentShootCooldown -= Time.deltaTime;
        }

        else if(currrentShootCooldown < 0)
        {
            currrentShootCooldown = enemyData.attackCooldownSpeed;
            Shoot();
        }
    }

    void Shoot()
    {
        GameObject bullet = Instantiate(bulletObject, transform.position, transform.rotation);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        Bullet b = bullet.GetComponent<Bullet>();
        b.targetTag = "Player";
        b.bulletDamage = enemyData.bulletDamage;
        b.sourceTag = "Enemy";
        rb.AddForce(transform.up * enemyData.bulletSpeed, ForceMode2D.Impulse);
    }

    public override void GainHealth(int amount)
    {
        base.GainHealth(amount);
        if(health <= 0)
        {
            Destroy(this.gameObject);
        }
    }
}

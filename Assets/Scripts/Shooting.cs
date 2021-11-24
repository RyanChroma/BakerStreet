using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    //public Transform transform;
    public GameObject bulletPrefab;

    public float bulletForce = 20f;

    void Update()
    {
        if(Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }
    }  

    void Shoot()
    {
        GameObject bullet = Instantiate(bulletPrefab, transform.position, transform.rotation);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        Bullet b = bullet.GetComponent<Bullet>();
        b.targetTag = "Enemy";
        b.bulletDamage = 10;
        //Debug.Log("Firepoint.position = " + transform.position);
        rb.AddForce(transform.up * bulletForce, ForceMode2D.Impulse);
        b.sourceTag = "Player";
    }
}
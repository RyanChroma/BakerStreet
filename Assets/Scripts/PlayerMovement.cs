using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    Rigidbody2D body;

    float horizontal;
    float vertical;
    float moveLimiter = 0.7f;

    public float runSpeed = 20.0f;

    private PlayerData playerData;

    void Start ()
    {
        body = GetComponent<Rigidbody2D>();
        playerData = new PlayerData();
        playerData.health = playerData.maxHealth;
    }

    void Update()
    {
        // Gives a value between -1 and 1
        horizontal = Input.GetAxisRaw("Horizontal"); // -1 is left
        vertical = Input.GetAxisRaw("Vertical"); // -1 is down
    }

    void FixedUpdate()
    {
        if (horizontal != 0 && vertical != 0) // Check for diagonal movement
        {
            // limit movement speed diagonally, so you move at 70% speed
            horizontal *= moveLimiter;
            vertical *= moveLimiter;
        } 

    body.velocity = new Vector2(horizontal * runSpeed, vertical * runSpeed);
    }

    public void GainHealth(int amount)
    {
        playerData.health += amount;
        playerData.health = Mathf.Min(playerData.health, playerData.maxHealth);
        Debug.Log("HealthStat");
    }
}
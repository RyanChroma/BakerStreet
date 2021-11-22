using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    Rigidbody2D body;

    float horizontal;
    float vertical;
    float moveLimiter = 0.7f;

    public float runSpeed = 20.0f;

    [SerializeField] private PlayerData playerData;
    [SerializeField] private Image healthBar;
    [SerializeField] Camera sceneCamera;
    
    Vector2 mousePosition;
    void Start ()
    {
        body = GetComponent<Rigidbody2D>();
        playerData.health = (float)playerData.maxHealth / 2;
        Debug.Log("Health" + playerData.health);
        UpdateHealthBar();
    }

    void Update()
    {
        // Gives a value between -1 and 1
        horizontal = Input.GetAxisRaw("Horizontal"); // -1 is left
        vertical = Input.GetAxisRaw("Vertical"); // -1 is down
        mousePosition = sceneCamera.ScreenToWorldPoint(Input.mousePosition);
    }

    void FixedUpdate()
    {
        if (horizontal != 0 && vertical != 0) // Check for diagonal movement
        {
            // limit movement speed diagonally, so you move at 70% speed
            horizontal *= moveLimiter;
            vertical *= moveLimiter;
        }

        GetComponent<Rigidbody2D>().velocity = new Vector2(horizontal * runSpeed, vertical * runSpeed);
        Vector2 aimDirection = mousePosition - GetComponent<Rigidbody2D>().position;
        
        float aimAngle = Mathf.Atan2(aimDirection.y, aimDirection.x) * Mathf.Rad2Deg - 90f;
        GetComponent<Rigidbody2D>().rotation = aimAngle;

        //body.velocity = new Vector2(horizontal * runSpeed, vertical * runSpeed);
    }

    public void GainHealth(int amount)
    {
        playerData.health += amount;
        playerData.health = Mathf.Min(playerData.health, playerData.maxHealth);
        Debug.Log("HealthStat");
        UpdateHealthBar();
    }

    private void UpdateHealthBar()
    {
        healthBar.fillAmount = (float)playerData.health / playerData.maxHealth;
    }
}
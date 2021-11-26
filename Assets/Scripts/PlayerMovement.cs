using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Character : MonoBehaviour
{
    [SerializeField] public float health;
	[SerializeField] public float maxHealth;

    public virtual void GainHealth(int amount)
    {
        health += amount;
        health = Mathf.Min(health, maxHealth);
    }
}

public class PlayerMovement : Character
{
    Rigidbody2D body;

    float horizontal;
    float vertical;
    float moveLimiter = 0.7f;

    public float runSpeed = 20.0f;

    [SerializeField] private PlayerData playerData;
    [SerializeField] private Image healthBar;
    [SerializeField] Camera sceneCamera;
    public static PlayerMovement instance;
    Vector2 mousePosition;

    void Awake()
    {
        if(instance != null)
        {
            Destroy(instance.gameObject);
        }

        instance = this;
    }

    void Start ()
    {
        body = GetComponent<Rigidbody2D>();
        //playerData.health = (float)playerData.maxHealth / 2;
        Debug.Log("Health" + playerData.health);
        health = playerData.health;
        UpdateHealthBar();
    }

    void Update()
    {
        // Gives a value between -1 and 1
        horizontal = Input.GetAxisRaw("Horizontal"); // -1 is left
        vertical = Input.GetAxisRaw("Vertical"); // -1 is down
        mousePosition = sceneCamera.ScreenToWorldPoint(Input.mousePosition);

        if (Input.GetKeyDown(KeyCode.Q))
        {
            health += 100;
        }
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

    public override void GainHealth(int amount)
    {
        base.GainHealth(amount);
        playerData.health = health;
        UpdateHealthBar();
        if(health <= 0)
        {
            SceneChange.ForceChangeScene("Wasted");
        }
    }

    private void UpdateHealthBar()
    {
        healthBar.fillAmount = (float)health / maxHealth;
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ExitFastFood : MonoBehaviour
{
    public GameObject E;
    public bool colliderCheck;

    void OnTriggerEnter2D(Collider2D col)
    {
        colliderCheck = true;
        E.SetActive(true);
    }

    void OnTriggerExit2D(Collider2D other)
    {
        colliderCheck = false;
        E.SetActive(false);
    }

    void Start()
    {
        colliderCheck = false;
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.E) && colliderCheck == true)
        {
            SceneManager.LoadScene("GromeStreet");
        }
    }
}
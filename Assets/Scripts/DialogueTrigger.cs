using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    public bool colliderCheck;
    public GameObject E;
    
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
        
    }
}
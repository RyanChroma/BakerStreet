using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarTrigger : MonoBehaviour
{
    public bool carColliderCheck;
    public GameObject E;
    public GameObject CarCanvas;

    void Start()
    {
        carColliderCheck = false;
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        carColliderCheck = true;
        E.SetActive(true);
    }

    void OnTriggerExit2D(Collider2D other)
    {
        carColliderCheck = false;
        E.SetActive(false);
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.E) && carColliderCheck == true)
        {
            CarCanvas.SetActive(true);
        }
    }

    void changeCanvasProperty(GameObject CarCanvas, bool disable) 
    {
     if (!disable)
         CarCanvas.SetActive(false);

     else
         CarCanvas.SetActive(true);
    }
}
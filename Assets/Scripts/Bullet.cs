using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] public string targetTag;
    [SerializeField] public string sourceTag;
    [SerializeField] public int bulletDamage;

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == targetTag)
        {
            Character character = other.GetComponent<Character>();
            character.GainHealth(- bulletDamage);
        }

        if(other.tag != sourceTag)
        {
            Destroy(this.gameObject);
        }
    }
}

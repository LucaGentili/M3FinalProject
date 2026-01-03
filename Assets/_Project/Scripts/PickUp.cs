using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour
{
    public Gun gunPrefab;
    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            Gun weapon = Instantiate(gunPrefab, collision.transform);
            Destroy(gameObject);
        }
    }    
}

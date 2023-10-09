using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpLife : MonoBehaviour
{
    public GameObject gameObject;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            PlayerHealth.instance.Heal(1);
            Destroy(gameObject);
        }
    }
}
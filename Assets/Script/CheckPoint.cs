using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPoint : MonoBehaviour
{

    public GameObject Respawn;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            PlayerHealth playerHealth = collision.transform.GetComponent<PlayerHealth>();
            Perso_Controller playercontroller = collision.transform.GetComponent<Perso_Controller>();
            if (!playerHealth.isdie)
            {
                Respawn.transform.position = collision.transform.position;

            }
        }
    }
}

using UnityEngine;




public class trap : MonoBehaviour
{


    public static trap instance;

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("Attention, instance > 1 !");
            return;
        }
        instance = this;
    }



    PlayerHealth PlayerHealth;
     public int damage = 1;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.transform.CompareTag("Player"))
        {
            PlayerHealth playerHealth = collision.transform.GetComponent<PlayerHealth>();
            playerHealth.TakeDamage(damage);
            Perso_Controller Perso_Controller = collision.transform.GetComponent<Perso_Controller>();
            
            if (!playerHealth.isdie)
            {
            if (Perso_Controller.facingRight)
            {
                print("te soul�ve a gauche");
                Perso_Controller.GetComponent<Rigidbody2D>().velocity = new Vector2(-1f*(Perso_Controller.jumpPower), Perso_Controller.jumpPower) * 0.5f;
                Perso_Controller.canMove = false;
                Perso_Controller.MAJ();               
            }

            if (!Perso_Controller.facingRight)
            {
                print("te soul�ve a droite");
                Perso_Controller.GetComponent<Rigidbody2D>().velocity = new Vector2(Perso_Controller.jumpPower, Perso_Controller.jumpPower) * 0.5f;
                Perso_Controller.canMove = false;
                Perso_Controller.MAJ();
            }
            }
        }
    }
}

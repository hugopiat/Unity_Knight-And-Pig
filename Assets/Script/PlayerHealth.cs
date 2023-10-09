using UnityEngine;
using System.Collections;
public class PlayerHealth : MonoBehaviour
{
    public int currentHealth;
    int MaxHealth = 3;
    public float InvincibilityDelayTime = 2f;
    public bool Invincible = false;
    public bool isdie = false;
    public static PlayerHealth instance;
    Ennemy_Patrol ennemyController;
    Perso_Controller playerController;
    SpriteRenderer EnnemiRenderer;

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("Attention, instance > 1 !");
            return;
        }
        instance = this;
    }

    void Start()
    {
        EnnemiRenderer = GetComponent<SpriteRenderer>();
        playerController = GetComponent<Perso_Controller>();
        currentHealth = MaxHealth;
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.H))
            TakeDamage(1);
        if (Input.GetKeyDown(KeyCode.U))
            Heal(1);
        if (currentHealth > MaxHealth)
            currentHealth = MaxHealth;
    }

    public void TakeDamage(int damages)
    {
        if (!Invincible)
        {
            HeartScript.health -= damages;
            currentHealth -= damages;
            
            if (HeartScript.health <= 0)
            {
                isdie = true;
                Die();
                return;
            }

            Invincible = true;
            playerController.Hit = true;
            playerController.canMove = false;
            StartCoroutine(InvincibilityDelay());
        }

    }
    public void Heal(int heal)
    {
        int x = 0;
        while (x < heal && HeartScript.health < 3)
        {
            HeartScript.health += 1;
            x += 1;
        }
    }
    public void Die()
    {
        Debug.Log("Le joueur est éliminé");
        Perso_Controller.instance.enabled = false;
        
        Perso_Controller.instance.playerAnim.SetBool("Mort", isdie);
        Perso_Controller.instance.playerRB.bodyType = RigidbodyType2D.Kinematic;
        Perso_Controller.instance.playerRB.velocity = Vector3.zero;
        Perso_Controller.instance.playerCollider.enabled = false;
        Ennemy_Patrol.instance.enabled = false;
        Ennemy_Patrol.instance.EnnemieAnimator.enabled = false;
        GameOverManager.instance.OnPlayerDeath();
    }
    public IEnumerator InvincibilityDelay()
    {
        yield return new WaitForSeconds(InvincibilityDelayTime / 2);
        Invincible = false;
        playerController.Hit = false;
    }
}

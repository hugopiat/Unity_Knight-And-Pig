using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ennemy_Patrol: MonoBehaviour
{
    public float speed;
    public Transform EnnemieTrans;
    public Transform[] waypoints;
    public Transform waypoints_Perso;
    private Transform target;
    public static Ennemy_Patrol instance;
    public Animator EnnemieAnimator;
    public Rigidbody2D EnnemieRB;

    public int damage = 1;
    //public bool Hit = false;

    SpriteRenderer EnnemiRenderer; // Propri�t� qui tiendra la r�f�ence du sprite rendered de notre player
    PlayerHealth playerHealth;
    Perso_Controller playercontroller;
    

    // Start is called before the first frame update
    void Start()
    {
        EnnemiRenderer = GetComponent<SpriteRenderer>();// R�cup�rer le component sprite renderer en dessous de cette ligne
        target = waypoints[0];
        EnnemieAnimator = GetComponent<Animator>();
    }

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("Attention, instance > 1 !");
            return;
        }
        instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 dir = target.position - EnnemieTrans.position;
        EnnemieTrans.Translate(dir.normalized * speed * Time.deltaTime, Space.World);

        if (((waypoints_Perso.position.x - waypoints[0].position.x) > 0f && (waypoints[1].position.x - waypoints_Perso.position.x) > 0f))
        {
            target = waypoints_Perso;
            if (waypoints_Perso.position.x < EnnemieTrans.position.x)
                EnnemiRenderer.flipX = false;
            else
                EnnemiRenderer.flipX = true;
        }
        else
        {
            float distance = Mathf.Abs(EnnemieTrans.position.x - waypoints[0].position.x);
            float distance_2 =  Mathf.Abs(EnnemieTrans.position.x - waypoints[1].position.x);
            if ( distance < 0.3f || distance_2 < 0.3f)
            {
                if (distance < distance_2)
                    target = waypoints[1];
                else
                    target = waypoints[0];
            }
            if (target == waypoints[0])
                EnnemiRenderer.flipX = false; // M�me chose ici pour que notre flipx et facingRight soient en phase
            else if (target == waypoints[1])
                EnnemiRenderer.flipX = true;
        }        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.CompareTag("Player"))
        {
            int cote;
            playerHealth = collision.transform.GetComponent<PlayerHealth>();
            playercontroller = collision.transform.GetComponent<Perso_Controller>();
            playerHealth.TakeDamage(damage);

            if (!playerHealth.isdie)
            {
                if (playercontroller.facingRight)
                    cote = -1;
                else
                    cote = 1;

                playercontroller.playerRB.velocity = new Vector2(cote * playercontroller.jumpPower, playercontroller.jumpPower);
                playercontroller.canMove = false;
                playercontroller.Hit = true;
                playercontroller.MAJ();
            }

            
        }
    }
}

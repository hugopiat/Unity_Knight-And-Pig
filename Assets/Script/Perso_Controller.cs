using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Perso_Controller : MonoBehaviour
{
    public Rigidbody2D playerRB; 
    SpriteRenderer playerRenderer; 
    public Animator playerAnim;
    public bool facingRight = true; 
    public float maxSpeed; 
    public bool grounded = false; 
    public float jumpPower = 2.0f;
    public float VerticalVelocity;
    public int maxSaut = 2;
    public bool enter_door = false;
    public bool get_out_door = false;
    int Jump = 0;
    public bool Hit = false;
    public bool canMove = true;
    float groundCheckRadius = 0.2f; 
    public LayerMask groundLayer;
    public Transform groundCheck; 
    public float HorizontaleVelocity;
    public static Perso_Controller instance;
    public CapsuleCollider2D playerCollider;


    // Use this for initialization

    void Start()
    {
        playerRB = GetComponent<Rigidbody2D>(); 
        playerRenderer = GetComponent<SpriteRenderer>();
        playerAnim = GetComponent<Animator>();
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

    void Update()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        grounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);

        deplacement();
        Saut();
        MAJ();

        void deplacement()
        {
            if (canMove)
            {
                if (moveHorizontal > 0.01f && !facingRight)
                    Flip();
                else if (moveHorizontal < -0.01f && facingRight)
                    Flip();

                playerRB.velocity = new Vector2(moveHorizontal * maxSpeed, playerRB.velocity.y); 
                playerAnim.SetFloat("MoveSpeed", Mathf.Abs(moveHorizontal));
            }
            else
            {
                playerRB.velocity = new Vector2(playerRB.velocity.x, playerRB.velocity.y); 
                playerAnim.SetFloat("MoveSpeed", 0); 
            }

        }

        void Saut()
        {
            if (Input.GetKeyDown(KeyCode.Space) && Jump < maxSaut)
            {
                playerRB.velocity = new Vector2(playerRB.velocity.x, jumpPower); 
                grounded = false; 
                Jump += 1;
                MAJ();
            }
        }       
    }
    public void Flip()
    {
        facingRight = !facingRight; 
        playerRenderer.flipX = !playerRenderer.flipX;
    }

    public void MAJ()
    {
        if (grounded && playerRB.velocity.y < 0.05)
        {
            Jump = 0;
            canMove = true;
        }
        playerAnim.SetBool("IsGrounded", grounded); 
        playerAnim.SetFloat("VerticalVelocity", playerRB.velocity.y);
        playerAnim.SetFloat("HorizontaleVelocity", playerRB.velocity.x); 
        playerAnim.SetBool("Hit", Hit); 
        playerAnim.SetBool("Enter_door", enter_door); 
        playerAnim.SetBool("Get_Out_door", get_out_door); 
    }
}
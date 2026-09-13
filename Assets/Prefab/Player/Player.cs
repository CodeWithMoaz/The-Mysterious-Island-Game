using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public GameObject canvasPause;
    public GameObject gameOver;
    public GameObject HTPPausecanvas;
    public int attacksword = 1;
    public float movespeed;
    public float jumpHeight;
    public bool isFacingRight;
    public KeyCode spacebar;
    public KeyCode L;
    public KeyCode R;
    public KeyCode S;
    public KeyCode C;
    public KeyCode Shift;
    public KeyCode Sword;
    public KeyCode Arrow;
    public KeyCode Gun;
    public KeyCode Exit;
    public Transform groundCheck;
    public GameObject Shield;
    public float groundCheckRadius;
    public LayerMask whatIsGround;
    [SerializeField] private LayerMask wallLayer;
    private float wallJumpCooldown;
    private bool grounded;
    private bool holdSword=false;
    private bool paused=false;
    public bool holdArrow=false;
    public bool holdGun=false;
    private bool crouch;
    private bool shield;
    private Animator anim;
    public Camera Cam;
    public float Zoomspeed;
    public Transform attackPoint;
    public float attackRange = 0.5f;
    public LayerMask enemyLayers;


    public static bool guncollected;
    public  bool guncollectedd;



    [Header("Jump Sound")]
    [SerializeField] private AudioClip jumpSound; 
    
    [Header("Sowrd Sound")]
    [SerializeField] private AudioClip swordSound;



    
    private void Awake()
    {

    }

    public void reloadScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Time.timeScale = 1;
    }
    public void PauseGame()
    {
        HTPPausecanvas.SetActive(false);
        canvasPause.SetActive(true);
        Time.timeScale = 0;
    }
    public void ResumeGame()
    {
        canvasPause.SetActive(false);
        Time.timeScale = 1;
    }
    public void OpenHelp()
    {
        HTPPausecanvas.SetActive(true);
        canvasPause.SetActive(false);
        Time.timeScale = 0;
    }

    
    // Start is called before the first frame update
    void Start()
    {
   
        isFacingRight = true;
        anim = GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {
        guncollectedd=guncollected;
        if (Input.GetKey(C))
        {
            shield = true;
            
        }
        else
        {
            shield = false;
        }
        Shield.SetActive(shield);


        if (FindObjectOfType<Player>().GetComponent<health>().lives <= -1)
        {
           foreach(var component in FindObjectOfType<Player>().GetComponent<health>().components) 
            {
                component.enabled = false;
            }
           gameOver.SetActive(true);
        }
        if (Input.GetKeyDown(Exit))
        {

            if (paused == true)
            {
               
                ResumeGame();
                paused = false;
            }
            else
            {

                PauseGame();
                paused =true;
            }

        }
        

        //Wall Jump Logic:

        if (wallJumpCooldown > 0.2f)
        {

            GetComponent<Rigidbody2D>().velocity = new Vector2( movespeed, GetComponent<Rigidbody2D>().velocity.y);

            if (onWall() && !grounded)
            {
        
                GetComponent<Rigidbody2D>().gravityScale = 0;
                GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            }

            else
            {
                GetComponent<Rigidbody2D>().gravityScale = 1;
            

            }
            if (Input.GetKey(spacebar))
            {
                Jump();

                if (Input.GetKey(KeyCode.Space) && grounded)
                {
                    SoundManager.instance.PlaySound(jumpSound);
                }
            }
        }

        else
            wallJumpCooldown += Time.deltaTime;



        if (Input.GetKey(Shift))
        {
            anim.SetBool("shift", true);
        }
        else
        {
            anim.SetBool("shift", false);
        }

        if (Input.GetKeyDown(Sword))
        {
            holdSword = !holdSword;
            holdArrow = false;
            holdGun = false;
        }
        if (Input.GetKeyDown(Arrow))
        {
            holdArrow = !holdArrow;
            holdSword = false;
            holdGun = false;
        }
        if (Input.GetKeyDown(Gun) && guncollectedd==true)
        {
            holdGun = !holdGun;
            holdSword = false;
            holdArrow = false;
        }


        if (Input.GetMouseButtonDown(0) && holdSword==true) 
        {
            anim.SetTrigger("Attack Sword");

        }

        if (Input.GetMouseButtonDown(0) && holdArrow == true)
        {
            anim.SetTrigger("Attack Arrow");

        }
        
        if (Input.GetMouseButtonDown(0) && holdGun == true)
        {
            anim.SetTrigger("Attack Gun");

        }





        
        if(Input.GetKey(S) && grounded)
        {
            crouch = true;
        }
        else
        {
            crouch = false;
        }

        if (Input.GetKeyDown(spacebar))
        {
            Jump();
        }


        if (Input.GetKey(L))
        {
            //Cam.orthographicSize = Mathf.Lerp(Cam.orthographicSize, 7, Time.deltaTime * Zoomspeed);

            if (grounded)
            {
                SoundManager.PlayFootstepAudio();
            }

            if (holdArrow == true && !Input.GetKey(Shift))
            {
                GetComponent<Rigidbody2D>().velocity = new Vector2(-(movespeed)/2, GetComponent<Rigidbody2D>().velocity.y);
            }
            else if (holdSword == true && !Input.GetKey(Shift)&& crouch == false)
            {
                GetComponent<Rigidbody2D>().velocity = new Vector2((-movespeed )/1.5f, GetComponent<Rigidbody2D>().velocity.y);
            }
            else if(crouch==true && !Input.GetKey(Shift))
            {
                GetComponent<Rigidbody2D>().velocity = new Vector2((-movespeed) / 2, GetComponent<Rigidbody2D>().velocity.y);
            }
            else
            {
                crouch=false;
                GetComponent<Rigidbody2D>().velocity = new Vector2(-movespeed, GetComponent<Rigidbody2D>().velocity.y);
            }
            if (isFacingRight)
            {
                flip();
                isFacingRight = false;
            }
        }
        else if (Input.GetKey(R))
        {
            //Cam.orthographicSize = Mathf.Lerp(Cam.orthographicSize, 7, Time.deltaTime * Zoomspeed);

            if (grounded)
            {
                SoundManager.PlayFootstepAudio();
            }

            if (holdArrow == true && !Input.GetKey(Shift))
            {

                GetComponent<Rigidbody2D>().velocity = new Vector2((movespeed)/2, GetComponent<Rigidbody2D>().velocity.y);
            }

            else if(holdSword == true && !Input.GetKey(Shift) && crouch==false)
            {
                GetComponent<Rigidbody2D>().velocity = new Vector2((movespeed)/1.5f, GetComponent<Rigidbody2D>().velocity.y);
            }

            else if (crouch == true && !Input.GetKey(Shift))
            {
                GetComponent<Rigidbody2D>().velocity = new Vector2((movespeed) / 2, GetComponent<Rigidbody2D>().velocity.y);
            }
            else
            {
                crouch = false;
                GetComponent<Rigidbody2D>().velocity = new Vector2(movespeed, GetComponent<Rigidbody2D>().velocity.y);
            }
            if (!isFacingRight)
            {
                flip();
                isFacingRight = true;
            }
        }
        
        

        else
        {
            
                
            
            GetComponent<Rigidbody2D>().velocity = new Vector2(0, GetComponent<Rigidbody2D>().velocity.y);

            //StartCoroutine(WaitingIdle());
            //Cam.orthographicSize = Mathf.Lerp(Cam.orthographicSize, 4, Time.deltaTime * Zoomspeed);
            

        }
        anim.SetFloat("Speed", Mathf.Abs(GetComponent<Rigidbody2D>().velocity.x));
        anim.SetBool("Grounded", grounded);
        anim.SetBool("Crouch", crouch);
        anim.SetBool("Shield", shield);
        anim.SetBool("Hold Sword", holdSword);
        anim.SetBool("Hold Arrow", holdArrow);
        anim.SetBool("Hold Gun", holdGun);
    }

    void flip()
    {
         if (transform.localScale.x > 0)
        {
            transform.position = new Vector3(transform.position.x - 0.465f, transform.position.y, transform.position.z);
        }
        else
        {
            transform.position = new Vector3(transform.position.x + 0.465f, transform.position.y, transform.position.z);
        }
        transform.localScale = new Vector3(-(transform.localScale.x), transform.localScale.y, transform.localScale.z);
       
    }
    void FixedUpdate()
    {
        grounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, whatIsGround);
    }
    void Jump()
    {
        if (grounded)
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<Rigidbody2D>().velocity.x, jumpHeight);
        }
        else if (onWall() && !grounded)
        {
            if (movespeed == 0)
            {
                GetComponent<Rigidbody2D>().velocity = new Vector2(-Mathf.Sign(transform.localScale.x) * 10, 0);
                transform.localScale = new Vector3(-Mathf.Sign(transform.localScale.x), transform.localScale.y, transform.localScale.z);
            }
            else
            {
                GetComponent<Rigidbody2D>().velocity = new Vector2(-Mathf.Sign(transform.localScale.x) * 3, 6);
            }
            wallJumpCooldown = 0;

        }

    }
    private bool onWall()
    {
        RaycastHit2D raycastHit = Physics2D.BoxCast(GetComponent<BoxCollider2D>().bounds.center, GetComponent<BoxCollider2D>().bounds.size, 0, new Vector2(transform.localScale.x, 0), 0.1f, wallLayer);

        return raycastHit.collider != null;
    }

    void AttackSword()
    {
        
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange,enemyLayers);
        if (hitEnemies.Length > 0)
        {
            foreach (Collider2D enemy in hitEnemies)
            {
                SoundManager.instance.PlaySound(swordSound);
                if (enemy.GetComponent<health>().enabled == false)
                {
                    enemy.GetComponent<bat_health>().TakeDamage(attacksword);
                }
                else
                {
                    enemy.GetComponent<health>().TakeDamage(attacksword);
                }
            }
        }

    }


    private void OnDrawGizmosSelected()
    {
        if (attackPoint == null)
            return;

        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }

   



    //public IEnumerator WaitingIdle()
    //{
        
    //    yield return new WaitForSeconds(5);

    //}


}
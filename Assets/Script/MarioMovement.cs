using UnityEngine;
using System.Collections;
using TMPro;
public class MarioMovement : MonoBehaviour

{
    public Animator animator;
    public RuntimeAnimatorController stage0, stage1, stage2;
    public int currentSage = 0;
    public AudioClip moveMario;
    public AudioClip jumpMario;
    public AudioClip enemySound;
    public AudioClip FlagSound;
    public GameObject Flag;
    public GameObject gameover;
    public GameObject tile;
    public GameObject Aenemy;
    public GameObject Bombtile;
    public Rigidbody2D rb;
    public float movementSpeed = 8f;
    public float jumpForce = 14f;
    public TextMeshProUGUI coin;
    public Collider2D polygon;
    int x = 0;
    bool jump = true;
    float jumpTime = 0.2f;
    bool canJump = true;
    public bool bombis = true;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator.runtimeAnimatorController = stage0;
        animator.SetTrigger("Trigger");
        if (currentSage == 0)
        {
            polygon.enabled = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (currentSage == 0)
        {
            animator.runtimeAnimatorController = stage0;
        }
        if (currentSage == -1)
        {
            Destroy(gameObject);
            gameover.SetActive(true);
            Time.timeScale = 0;
        }
        if (currentSage == 1)
        {
            animator.runtimeAnimatorController = stage1;

        }
        if (currentSage == 2)
        {
            animator.runtimeAnimatorController = stage2;
        }
        if (currentSage == 0)
        {
            polygon.enabled = false;
        }
        if (currentSage > 0)
        {
            polygon.enabled = true;
        }
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        if (horizontalInput == 1)
        {
            AudioSource.PlayClipAtPoint(moveMario, transform.position, 1);
            animator.SetInteger("Int", 1);
        }
        if (horizontalInput == -1)
        {
            AudioSource.PlayClipAtPoint(moveMario, transform.position, 1);
            animator.SetInteger("Int", -1);
        }
        if (horizontalInput == 0)
        {
            animator.SetInteger("Int", 0);
        }
        rb.velocity = new Vector3(horizontalInput * movementSpeed, rb.velocity.y, verticalInput * movementSpeed);

        if (jump == true)
        {
            if (Input.GetButtonDown("Jump"))
            {
                jumpTime = 0.2f;
            }
            else if (Input.GetButton("Jump") && canJump)
            {
                jumpTime -= Time.deltaTime;

                if (jumpTime < 0f)
                {
                    canJump = false;
                    jump = false;
                    AudioSource.PlayClipAtPoint(jumpMario, transform.position, 1);
                    animator.SetTrigger("Trigger");
                    rb.velocity = new Vector2(rb.velocity.x, 13);
                }
            }
            else if (Input.GetButtonUp("Jump") && canJump)
            {
                if (jumpTime > 0f)
                {
                    rb.velocity = new Vector2(rb.velocity.x, 9.5f);
                    AudioSource.PlayClipAtPoint(jumpMario, transform.position, 1);
                    animator.SetTrigger("Trigger");
                }
                canJump = true;
                jump = false;
            }

            if (Input.GetButtonUp("Jump")) canJump = true;
        }
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            movementSpeed++;
        }
        if (Input.GetKeyDown(KeyCode.RightShift))
        {
            movementSpeed--;
        }

    }
    void OnCollisionEnter2D(Collision2D collision)
    {

        jump = true;
        animator.SetTrigger("Trigger");
        if (collision.gameObject.tag == "pipe")
        {
            animator.SetInteger("Int", 2);
        }
       
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "EnemyHitPoint")
        {
            collision.transform.parent.GetComponent<EnemyMovement>().Dead();
        }
        if (collision.gameObject.tag == "enemy")
        {
            currentSage--;
        }
        if (collision.gameObject.tag == "Ttile")
        {
            tile.SetActive(true);
        }
        if (collision.gameObject.tag == "Tenemy")
        {
            Debug.Log(12345);
            Aenemy.SetActive(true);
        }
        if (collision.gameObject.tag == "powerUp")
        {
            Destroy(Aenemy, 0.5F);
        }
        if (collision.gameObject.tag == "stick")
        {
            LeanTween.moveY(Flag, -2.68f, 2);
            AudioSource.PlayClipAtPoint(FlagSound, transform.position, 1);
            Time.timeScale = 0;
           
        }  
        if (collision.gameObject.tag == "coin")
        {
            x++;
            coin.text = x.ToString();
        }
        if (collision.gameObject.tag == "poweUp")
        {
            currentSage++;
        }
        if (collision.gameObject.tag == "bombtile")
        {
            Debug.Log(234567890);
            rb.velocity = new Vector2(rb.velocity.x, 0);
            bombis = true;
        
        }

    }
}

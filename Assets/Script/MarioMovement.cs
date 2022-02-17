using UnityEngine;
using System.Collections;
using TMPro;
public class MarioMovement : MonoBehaviour

{
    public Animator animator;
    public AudioClip moveMario;
    public AudioClip jumpMario;
    public AudioClip enemySound;
    public AudioClip FlagSound;
    public GameObject Flag;
    public GameObject gameover;
    Rigidbody2D rb;
    public float movementSpeed = 8f;
    public float jumpForce = 14f;
    public TextMeshProUGUI coin;
    int x = 0;
    int y = 0;
    bool jump = true;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator.SetTrigger("Trigger");
      
    }

    // Update is called once per frame
    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        if(horizontalInput == 1)
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
        if (Input.GetButtonDown("Jump"))
        {
            if (jump == true)
            {
                AudioSource.PlayClipAtPoint(jumpMario, transform.position, 1);
                animator.SetTrigger("Trigger");
                rb.velocity = new Vector2(rb.velocity.x, jumpForce);
                jump = false;
            }
        }

        if (Input.GetButtonDown("left shift"))
        {
            movementSpeed = 12f;
        }

    }
    void OnCollisionEnter2D(Collision2D collision)
    {
     
        {
            jump = true;
        }

        animator.SetTrigger("Trigger");
        if (collision.gameObject.tag == "pipe")
        {
            animator.SetInteger("Int", 2);
        }
        if (collision.gameObject.tag == "enemy")
        {
            y++;
            if (y > 1)
            {
                Destroy(gameObject);
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "enemy")
        {
            var coliders = collision.gameObject.GetComponentsInChildren<Collider2D>();

            for (int i = 0; i < coliders.Length; i++)
            {
                coliders[i].enabled = false;
            }

            Destroy(collision.gameObject, 1f);
            AudioSource.PlayClipAtPoint(enemySound, transform.position, 1);
        }

        if (collision.gameObject.tag == "stick")
        {
            LeanTween.moveY(Flag, -2.68f, 2);
            AudioSource.PlayClipAtPoint(FlagSound, transform.position, 1);
        }
        if (collision.gameObject.tag == "coin")
        {
            x++;
            coin.text = x.ToString();
        }
        if (collision.gameObject.tag == "Aenemy")
        {
            animator.SetLayerWeight(1, 1);
        }
    }
}
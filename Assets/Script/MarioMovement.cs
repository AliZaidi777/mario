using UnityEngine;
using System.Collections;
public class MarioMovement : MonoBehaviour

{
    public Animator animator;
    public AudioClip moveMario;
    public AudioClip jumpMario;
    Rigidbody2D rb;
    public float movementSpeed = 6f;
    public float jumpForce = 5f;
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
            AudioSource.PlayClipAtPoint(jumpMario, transform.position, 1);
            animator.SetTrigger("Trigger");
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        }
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        animator.SetTrigger("Trigger");
        if (collision.gameObject.tag == "pipe")
        {
            animator.SetInteger("Int", 2);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "enemy")
        {
            Destroy(collision.gameObject);
        }
    }
}
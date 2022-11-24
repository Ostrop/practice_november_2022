using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed;
    public float jumpForce;
    Rigidbody2D rb;
    Collider2D coll;
    Animator animator;
    GameObject laser;

    public bool isGrounded;
    public LayerMask whatIsGround;
    public float collTimer, collTimerJump;
    bool TimerOn = false, collTimerJumpOn = false;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        coll = GetComponent<Collider2D>();
        animator = GetComponent<Animator>();
        laser = GameObject.Find("Red-Laser-Transparent-PNG");
    }

    private void Update()
    {
        isGrounded = Physics2D.IsTouchingLayers(coll, whatIsGround);

        rb.velocity = new Vector2(speed, rb.velocity.y);
        if (Input.GetKeyDown(KeyCode.W) && isGrounded)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            animator.SetBool("Jump", true);
        }
        else if (Input.GetKeyDown(KeyCode.S) && isGrounded)
        {
            animator.SetBool("Down", true);
            laser.GetComponent<Collider2D>().enabled = false;
            collTimer = 0;
            TimerOn = true;
        }
        else
        {
            animator.SetBool("Jump", false);
            animator.SetBool("Down", false);
            animator.SetBool("MegaJump", false);
        }
        if (Input.GetKeyDown(KeyCode.Space) && PlayerPrefs.GetInt("Tokens") >= 3 && !collTimerJumpOn && isGrounded && !TimerOn)
        {
            animator.SetBool("MegaJump", true);
            jumpForce = 10;
            collTimerJumpOn = true;
            collTimerJump = 0;
            laser.GetComponent<Collider2D>().enabled = false;
            GameManager.instance.UseUlty();
        }
        if (TimerOn)
            collTimer += Time.deltaTime;

        if (collTimerJumpOn)
            collTimerJump += Time.deltaTime;

        if (collTimerJump >= 3)
        {
            jumpForce = 5;
            collTimerJumpOn = false;
            if (!TimerOn)
                laser.GetComponent<Collider2D>().enabled = true;
        }
        if (collTimer >= 2)
        {
            if (!collTimerJumpOn)
                laser.GetComponent<Collider2D>().enabled = true;
            TimerOn = false;
        }

    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("PipePart"))
        {
            GameManager.instance.Lose();
        }
    }
}

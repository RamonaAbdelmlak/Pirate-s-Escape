using UnityEngine;
using UnityEngine.InputSystem;

public class SCR_Player_Movement : MonoBehaviour
{
    public Rigidbody2D rb;
    public float moveSpeed;
    public float jumpStrength;
    public float dashStrength;
    public Vector2 moveInput;
    public InputAction jump;
    public InputAction dash;
    public bool canJump;
    public bool canDash;
    public SCR_Player_Wait playerWait;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnEnable()
    {
        jump.Enable();
        dash.Enable();
    }
    void FixedUpdate()
    {
        rb.linearVelocityX = moveInput.x * moveSpeed;
        if (jump.IsPressed())
        {
            if (canJump && rb.linearVelocityY == 0)
            {
                rb.AddForce(Vector2.up * jumpStrength, ForceMode2D.Impulse);
            }
        }
        if (dash.IsPressed())
        {
            if (canDash)
            {
                if (moveInput.x > 0)
                {
                    rb.AddForce(Vector2.right * dashStrength, ForceMode2D.Impulse);
                }
                else if (moveInput.x < 0)
                {
                    rb.AddForce(Vector2.left * dashStrength, ForceMode2D.Impulse);
                }
                StartCoroutine(playerWait.Dash());
            }
        }
    }
    public void OnMove(InputValue input)
    {
        moveInput = input.Get<Vector2>();
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Floor") || collision.gameObject.CompareTag("Platform"))
        {
            canJump = true;
        }
    }
    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Floor") || collision.gameObject.CompareTag("Platform"))
        {
            canJump = false;
        }
    }
}

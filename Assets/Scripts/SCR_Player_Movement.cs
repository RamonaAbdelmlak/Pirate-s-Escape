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
    public bool canMove = true;
    public bool canJump;
    public bool canDash;
    public SCR_Player_Wait playerWait;
    public float lastDirection = 1;
    public SCR_Player_Anim playerAnim;
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
        if (canMove)
        {
            rb.linearVelocityX = moveInput.x * moveSpeed;
            if (lastDirection > 0)
            {
                if (canJump && moveInput.x != 0)
                {
                    playerAnim.PlayAnimation("Run Right");
                }
            }
            else if (lastDirection < 0)
            {
                if (canJump && moveInput.x != 0)
                {
                    playerAnim.PlayAnimation("Run Left");
                }
            }
        }
        // rb.linearVelocityX = moveInput.x * moveSpeed;
        if (jump.IsPressed())
        {
            if (canJump && rb.linearVelocityY == 0)
            {
                rb.AddForce(Vector2.up * jumpStrength, ForceMode2D.Impulse);
                if (lastDirection > 0)
                {
                    playerAnim.PlayAnimation("Jump Right");
                }
                else if (lastDirection < 0)
                {
                    playerAnim.PlayAnimation("Jump Left");
                }
            }
        }
        if (moveInput.x == 0 && (playerAnim.animator.GetCurrentAnimatorStateInfo(0).IsName("Run Right") || playerAnim.animator.GetCurrentAnimatorStateInfo(0).IsName("Run Left")))
        {
            playerAnim.PlayAnimation("Idle");
        }
        if (canJump && rb.linearVelocityY == 0 && moveInput.x == 0)
        {
            playerAnim.PlayAnimation("Idle");
        }
        if (!canJump && rb.linearVelocityY < 0)
        {
            if (lastDirection > 0)
            {
                playerAnim.PlayAnimation("Fall Right");
            }
            else if (lastDirection < 0)
            {
                playerAnim.PlayAnimation("Fall Left");
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
                if (lastDirection > 0)
                {
                    playerAnim.PlayAnimation("Dash Right");
                }
                else if (lastDirection < 0)
                {
                    playerAnim.PlayAnimation("Dash Left");
                }
                StartCoroutine(playerWait.Dash());
            }
        }
        LastDirectionMoved();
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
    public void LastDirectionMoved()
    {
        if (moveInput.x > 0)
        {
            lastDirection = 1;
        }
        else if (moveInput.x < 0)
        {
            lastDirection = -1;
        }
    }
}

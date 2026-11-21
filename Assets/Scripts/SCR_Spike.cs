using UnityEngine;

public class SCR_Spike : MonoBehaviour
{
    public Rigidbody2D rb;
    public float verticalKnockback = 50f;
    public SCR_Player_Movement playerMovement;
    public SCR_Player_Wait playerWait;
    public SCR_Player_Anim playerAnim;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D other) {
        rb = other.gameObject.GetComponent<Rigidbody2D>();
        playerMovement = other.gameObject.GetComponent<SCR_Player_Movement>();
        playerMovement.canMove = false;
        playerWait = other.gameObject.GetComponent<SCR_Player_Wait>();
        playerAnim = other.gameObject.GetComponent<SCR_Player_Anim>();
        if (rb.linearVelocity.x > 0)
        {
            rb.AddForce(Vector2.up * verticalKnockback, ForceMode2D.Impulse);
            rb.AddForce(Vector2.left * verticalKnockback, ForceMode2D.Impulse);
            playerAnim.PlayAnimation("Dmg Right");
        }  
        else
        {
            rb.AddForce(Vector2.up * verticalKnockback, ForceMode2D.Impulse);
            rb.AddForce(Vector2.right * verticalKnockback, ForceMode2D.Impulse);
            playerAnim.PlayAnimation("Dmg Left");
        }
        StartCoroutine(playerWait.pauseMovement());
    }
}

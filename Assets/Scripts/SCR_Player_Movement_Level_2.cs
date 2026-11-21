using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
    
public class SCR_Player_Movement_Level_2 : MonoBehaviour
{
    public Rigidbody2D rb;
    public GameObject bulletSource;
    public Vector2 moveInput;
    public float moveSpeed;
    public bool canMove = true;
    public float bulletSpeed;
    public InputAction fireBullet;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        fireBullet.Enable();
    }

    // Update is called once per frame
    void Update()
    {
        if (fireBullet.WasPressedThisFrame())
        {
            GameObject tmp = Instantiate(bulletSource, transform.position, transform.rotation);
            tmp.GetComponent<SpriteRenderer>().enabled = true;
            tmp.transform.SetParent(null);
            tmp.GetComponent<Rigidbody2D>().linearVelocity = new Vector2(bulletSpeed, 0f);
        }
    }

    void FixedUpdate()
    {
        if (canMove)
        {
            rb.linearVelocity = moveInput * moveSpeed;
        }
       
        
    }

    public void OnMove(InputValue input)
    {
        moveInput = input.Get<Vector2>();
    }
    
}

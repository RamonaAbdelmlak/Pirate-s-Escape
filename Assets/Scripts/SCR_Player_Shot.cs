using UnityEngine;

public class SCR_Player_Shot : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void On(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            collision.gameObject.GetComponent<SCR_Enemy_Health>().TakeDamage(10);
        }
        Destroy(gameObject);
    }
}

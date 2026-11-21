using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class SCR_Player_Health : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;
    public SCR_Player_Movement_Level_2 playerMovement;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        currentHealth = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        if (currentHealth <= 0)
        {
            currentHealth = 0;
            StartCoroutine(Death());
        }
    }
    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
    }
    public IEnumerator Death()
    {
        playerMovement.canMove = false;
        yield return new WaitForSeconds(0.5f);
        GetComponent<SpriteRenderer>().enabled = false;
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene(1);
    }
}

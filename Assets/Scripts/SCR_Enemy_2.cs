using UnityEngine;

public class SCR_Enemy_2 : MonoBehaviour
{
    public float detectionRange = 6f;
    public float speed = 5f;
    public GameObject ignore;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Kamikaze();
    }
    public void Kamikaze()
    {
        GameObject[] obj = GameObject.FindGameObjectsWithTag("Player");
        if (obj.Length > 0)
        {
            Vector3 target = obj[0].transform.position;
            if (Vector3.Distance(transform.position, target) <= detectionRange)
            {
                transform.position = Vector3.MoveTowards(transform.position, target, Time.deltaTime * speed);
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            other.gameObject.GetComponent<SCR_Player_Health>().TakeDamage(20);
            Destroy(gameObject);
        }
    }
    
}

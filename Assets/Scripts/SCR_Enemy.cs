using UnityEngine;

public class SCR_Enemy : MonoBehaviour
{
    public float detectionRange;
    public GameObject bulletSource;
    public bool canShoot = true;
    public SCR_Enemy_Wait enemyWait;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (canShoot)
        {
            shoot();
            canShoot = false;
            StartCoroutine(enemyWait.shootCooldown());
        }
    }

    public void shoot()
    {
        GameObject[] obj = GameObject.FindGameObjectsWithTag("Player");
        if (obj.Length > 0)
        {
            Vector3 target = obj[0].transform.position;
            if (Vector3.Distance(transform.position, target) <= detectionRange)
            {
                GameObject tmp = Instantiate(bulletSource, transform.position, transform.rotation);
                tmp.transform.SetParent(null);
                tmp.SetActive(true);
            }
        }
    }
}

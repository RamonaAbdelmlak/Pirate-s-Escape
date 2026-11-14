using UnityEngine;
using System.Collections;
public class SCR_Enemy_Wait : MonoBehaviour
{
    public SCR_Enemy enemy;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public IEnumerator shootCooldown()
    {
        enemy.canShoot = false;
        yield return new WaitForSeconds(0.33f);
        enemy.canShoot = true;
    }
}

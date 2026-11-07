using System.Collections;
using UnityEngine;

public class SCR_Player_Wait : MonoBehaviour
{
    public SCR_Player_Movement playerMovement;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public IEnumerator Dash()
    {
        yield return new WaitForSeconds(0.1f);
        playerMovement.canDash = false;
        yield return new WaitForSeconds(1f);
        playerMovement.canDash = true;
    }
}

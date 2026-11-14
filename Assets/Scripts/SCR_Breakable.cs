using UnityEngine;
using System.Collections;
public class SCR_Breakable : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        StartCoroutine(Break());
    }
    public IEnumerator Break()
    {
        yield return new WaitForSeconds(1f);
        Destroy(gameObject);
    }
}

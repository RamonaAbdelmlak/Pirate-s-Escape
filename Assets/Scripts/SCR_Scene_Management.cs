using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SCR_Scene_Management : MonoBehaviour
{
    public int sceneToLoad = 1;
    public string tagCheck = "Floor";
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag(tagCheck))
        {
            StartCoroutine(ReloadScene());
        }
    }
    public IEnumerator ReloadScene()
    {
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene(sceneToLoad);
    }
}

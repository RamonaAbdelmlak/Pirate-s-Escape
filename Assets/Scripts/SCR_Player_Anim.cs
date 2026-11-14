using UnityEngine;

public class SCR_Player_Anim : MonoBehaviour
{
    public Animator animator;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlayAnimation(string animationName)
    {
        animator.Play(animationName);
    }
}

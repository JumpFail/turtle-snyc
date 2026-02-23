using UnityEngine;

public class animMove : MonoBehaviour
{
    private Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.D))
        {
            animator.SetBool("isLooping", true);
        }
        if (Input.GetKeyUp(KeyCode.D))
        {
            animator.SetBool("isLooping", false);
        }
    }
}

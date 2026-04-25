using UnityEngine;

public class Animation : MonoBehaviour
{
    private Animator animator;

    void Start()
    { 
     animator = GetComponent<Animator>();
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            animator.SetTrigger("writing");
        }
    }
}

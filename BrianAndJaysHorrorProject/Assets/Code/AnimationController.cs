using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationController : MonoBehaviour
{
    // Start is called before the first frame update

    Animator animator;
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        bool forwardPressed = Input.GetKey(KeyCode.W);
        if (forwardPressed)
        {
            animator.SetBool("IsForward", true);
        }
        if (!forwardPressed)
        {
            animator.SetBool("IsForward", false);
        }
    }
}

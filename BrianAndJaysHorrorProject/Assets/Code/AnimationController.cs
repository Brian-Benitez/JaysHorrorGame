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
        bool leftPressed = Input.GetKey(KeyCode.A);
        bool rightPressed = Input.GetKey(KeyCode.D);
        if (forwardPressed)
        {
            animator.SetBool("IsForward", true);
        }
        if (!forwardPressed)
        {
            animator.SetBool("IsForward", false);
        }
        if (leftPressed)
        {
            animator.SetBool("IsLeft", true);
        }
        if (!leftPressed)
        {
            animator.SetBool("IsLeft", false);
        }
        if (rightPressed)
        {
            animator.SetBool("IsRight", true);
        }
        if (!rightPressed)
        {
            animator.SetBool("IsRight", false);
        }


    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationController : MonoBehaviour
{
    public int currentAnimState = 0;
    int lastAnimState;
    public Animator thisAnimator;

    // Start is called before the first frame update
    void Start()
    {
        thisAnimator.applyRootMotion = false;
    }

    private void FixedUpdate()
    {
        AnimUpdate();
    }

    public void AnimUpdate()
    {
        if (lastAnimState != currentAnimState)
        {
            switch (currentAnimState)
            {
                case 0:
                    thisAnimator.SetTrigger("Idle");
                    break;
                case 1:
                    thisAnimator.SetTrigger("Run");
                    break;
                case 2:
                    thisAnimator.SetTrigger("Fire");
                    break;

            }
            lastAnimState = currentAnimState;
        }
    }
}

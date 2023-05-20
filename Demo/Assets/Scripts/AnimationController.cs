using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class AnimationController : MonoBehaviour
{
    [SerializeField] Animator animator;
    public void SetMotionValue(float value)
    {
        GetComponent<Animator>().SetFloat("MovementSpeed", value);
    }

    public void SetAttackTrigger()
    {
        GetComponent<Animator>().SetTrigger("Attack");
    }
    
    public void SetJumpTrigger()
    {
        
    }
    public void SetDeathTrigger()
    {
        
    }

    private void Update()
    {
        if(Input.GetKey("w"))
        {
            animator.SetBool("IsWalking",true);
            animator.SetBool("Isidle", false);
        }
        else
        {
            animator.SetBool("IsWalking", false);
            animator.SetBool("Isidle", true);
        }

        if (Input.GetKey(KeyCode.Space))
        {
            animator.SetBool("IsWalking", true);
            animator.SetBool("Isidle", false);
        }
        else
        {
            animator.SetBool("IsWalking", false);
            animator.SetBool("Isidle", true);
        }
    }

}

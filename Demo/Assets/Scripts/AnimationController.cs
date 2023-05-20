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
        //moverse
        if(Input.GetKeyDown("w"))
        {
            animator.SetBool("IsWalking", true);          
        }

        if (Input.GetKeyUp("w"))
        {
            animator.SetBool("IsWalking", false);        
        }

        //saltar
        if (Input.GetKeyDown(KeyCode.Space))
        {
            animator.SetBool("IsJumping", true);
        }
        
        if(Input.GetKeyUp(KeyCode.Space))
        {
            animator.SetBool("IsJumping", false);
        }

        //correr
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            animator.SetBool("IsRunning", true);
            animator.SetBool("IsWalking", false);
        }

        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            animator.SetBool("IsRunning", false);
            animator.SetBool("IsWalking", true);
        }

    }

}

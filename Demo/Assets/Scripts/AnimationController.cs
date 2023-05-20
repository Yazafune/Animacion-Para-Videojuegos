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
        GetComponent<Animator>().SetTrigger("Jump");
    }
    
    public void SetDamageTrigger()
    {
        GetComponent<Animator>().SetTrigger("Damage");
    }
    public void SetDeathTrigger()
    {
        GetComponent<Animator>().SetTrigger("Death");
    }
    
    public void SetFootTrigger()
    {
        GetComponent<Animator>().SetTrigger("Foot");
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

        }

        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            animator.SetBool("IsRunning", false);

        }

        //Ataque 1
        if (Input.GetButtonDown("Fire1"))
        {
            animator.SetBool("IsAttacking1", true);

        }

        if (Input.GetButtonUp("Fire1"))
        {
            animator.SetBool("IsAttacking1", false);

        }

    }

}

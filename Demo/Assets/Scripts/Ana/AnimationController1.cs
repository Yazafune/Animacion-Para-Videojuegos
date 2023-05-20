using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class AnimationController1 : MonoBehaviour
{
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
   
    
    
}

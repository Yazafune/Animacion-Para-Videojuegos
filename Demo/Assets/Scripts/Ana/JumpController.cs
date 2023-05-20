using System.Collections;
using System.Collections.Generic;
using UnityEngine.Events;
using UnityEngine;
using UnityEngine.InputSystem;


public class JumpController : MonoBehaviour
{
    [SerializeField] private UnityEvent onJump;
    
    public void Jump(InputAction.CallbackContext context)
    {
        if (context.action.WasPerformedThisFrame())
        {
            Debug.Log("Saltando");
            onJump?.Invoke();
        }
        
    }
}

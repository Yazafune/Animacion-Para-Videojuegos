using System.Collections;
using System.Collections.Generic;
using UnityEngine.Events;
using UnityEngine;

public class JumpController : MonoBehaviour
{
    [SerializeField] private UnityEvent onJump;
    
    public void Jump()
    {
        onJump?.Invoke();
    }
}

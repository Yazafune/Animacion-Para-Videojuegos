using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.Events;
using UnityEngine;

public class AttackController : MonoBehaviour
{
    [SerializeField] private UnityEvent onAttack;
    
    public void Attack()
    {
        onAttack?.Invoke();
    }
}

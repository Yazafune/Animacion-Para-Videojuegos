using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations.Rigging;

[Serializable]
public struct Multiparentconstrainconfig
{
    public MultiParentConstraint constraint;
    public int[] directParents;
    public int[] inverseParents;

}

[RequireComponent(typeof(Animator))]
public class CurveAnimationParentConstrain : MonoBehaviour
{
    private Animator anim; 
    [SerializeField] private Multiparentconstrainconfig[] drivenConstrains;

    private void Awake()
    {
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        //float value = anim.GetFloat();
    }
}

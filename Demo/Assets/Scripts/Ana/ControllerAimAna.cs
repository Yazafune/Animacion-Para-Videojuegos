using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.Animations.Rigging;

public class ControllerAimAna : MonoBehaviour
{
    [SerializeField] private Vector3 detectionRelativePosition;
    [SerializeField] private float radiusDetection;
    [SerializeField] private LayerMask maskDetection;

    [SerializeField] private MultiAimConstraint contraintAim;

    private void FixedUpdate()
    {
        Collider[] detected = Physics.OverlapSphere(transform.TransformPoint(detectionRelativePosition),
            radiusDetection, maskDetection);

        if (detected != null && detected.Length > 0)
        {
            contraintAim.weight = 1;
            contraintAim.data.sourceObjects.Clear();
            contraintAim.data.sourceObjects.Add(new WeightedTransform(detected[0].transform, weight:1));
        }
        
    }
}

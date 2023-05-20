using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations.Rigging;


public class AimController : MonoBehaviour
{
    [SerializeField] Vector3 relativeDetectionPosition;
    [SerializeField] float detectionRadius;
    [SerializeField] LayerMask detectionMask;

    [SerializeField] MultiAimConstraint aimConstraint;
    private void FixedUpdate()
    {
        Collider[] detected = Physics.OverlapSphere(transform.TransformPoint(relativeDetectionPosition), detectionRadius, detectionMask);
        if (detected != null && detected.Length > 0)
        {
            aimConstraint.weight = 1;
            aimConstraint.data.sourceObjects.Clear();
            aimConstraint.data.sourceObjects.Add(new WeightedTransform(detected[0].transform, 1f));

        }

    }
}

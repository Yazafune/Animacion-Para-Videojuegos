using System;
using System.Collections;
using System.Collections.Generic;
using OpenCover.Framework.Model;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;
using CallbackContext = UnityEngine.InputSystem.InputAction.CallbackContext;

namespace Ana
{
    [Serializable]
    public class UnityFloatEvent : UnityEvent<float>
    {
        
    }
    public class SimpleMovement : MonoBehaviour
    {
        [SerializeField] private Transform cameraTransform;
        [SerializeField] private Vector2 inputValue;
        [SerializeField] private Vector2 smoothInput;
        [SerializeField] private float speed;
        [SerializeField] private float aceleration;
        [SerializeField] private UnityFloatEvent onMoved;
        //[SerializeField] private UnityEvent onFoot;
        
        public void Move(CallbackContext context)
        {
            inputValue = context.ReadValue<Vector2>();
        }

        private void Update()
        {
            smoothInput = Vector2.Lerp(smoothInput, inputValue, Time.deltaTime * aceleration);
            Vector3 forwardVector = Vector3.ProjectOnPlane(cameraTransform.forward, transform.up);
            Vector3 rigthVector = cameraTransform.right;
            Vector3 motionVector = forwardVector * smoothInput.y + rigthVector * smoothInput.x;
            transform.Translate(motionVector * (Time.deltaTime * speed), Space.World);
            onMoved?.Invoke(smoothInput.magnitude);
            //onFoot?.Invoke();
            if (motionVector.magnitude > 0.01)
            {
                transform.forward = motionVector.normalized;
            }
        }
    }
}


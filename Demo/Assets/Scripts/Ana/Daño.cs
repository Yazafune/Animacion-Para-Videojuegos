using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Daño : MonoBehaviour
{
    public int cantidad = 20;
    private void OnTriggerEnter(Collider collider)
    {
        if (collider.tag == "Player")
        {
            collider.GetComponent<VidaYDaño>().RestarVida(cantidad);
        }
    }
    
    
    
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CargarNuevaEscena : MonoBehaviour
{
    [SerializeField] string escena;

    public void Cargar()
    {
        SceneManager.LoadScene(escena);
    }
}

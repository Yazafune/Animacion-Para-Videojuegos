using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SeleccionarPJ : MonoBehaviour
{
    [SerializeField] int numPj;
    

    public void EmpezarDemo()
    {
        PlayerPrefs.SetInt("Personaje", numPj);
        SceneManager.LoadScene("CampoDePruebas");
    }
}

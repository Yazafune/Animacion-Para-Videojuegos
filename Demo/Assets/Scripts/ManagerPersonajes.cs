using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManagerPersonajes : MonoBehaviour
{
    [SerializeField] GameObject[] personaje;
    [SerializeField] ObjetoDanino[] trampa;
    void Start()
    {
        Desactivar();
        if (PlayerPrefs.GetInt("Personaje") == 1)
        {
            EstablecerValores(0);
        }
        else if(PlayerPrefs.GetInt("Personaje") == 2)
        {
            EstablecerValores(1);
        }
        else if (PlayerPrefs.GetInt("Personaje") == 3)
        {
            EstablecerValores(2);
        }
        else if (PlayerPrefs.GetInt("Personaje") == 4)
        {
            EstablecerValores(3);
        }
    }
    void EstablecerValores(int i)
    {
        personaje[i].SetActive(true);
        trampa[0].saludPersonaje = personaje[i].GetComponent<SaludPersonaje>();
        trampa[1].saludPersonaje = personaje[i].GetComponent<SaludPersonaje>();
    }
    void Desactivar()
    {
        personaje[0].SetActive(false);
        personaje[1].SetActive(false);
        personaje[2].SetActive(false);
        personaje[3].SetActive(false);
    }
}

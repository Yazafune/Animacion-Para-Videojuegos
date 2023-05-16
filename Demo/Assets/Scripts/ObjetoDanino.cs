using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjetoDanino : MonoBehaviour
{
    public int cantidadDanio = 10; // Cantidad de daño causado al jugador
    public SaludPersonaje saludPersonaje; // Referencia al script de salud del jugador

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (saludPersonaje != null)
            {
                // Llamar a la función RecibirDanio del componente SaludPersonaje del jugador
                saludPersonaje.RecibirDanio(cantidadDanio);
            }
        }
    }
}



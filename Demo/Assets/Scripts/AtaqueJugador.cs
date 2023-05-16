using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AtaqueJugador : MonoBehaviour
{
    public float tiempoEntreClicks = 0.5f; // Tiempo máximo entre clics para considerar una cadena de ataques
    public float tiempoMaximoCombo = 1.5f; // Tiempo máximo para completar un combo
    public float retrasoEntreAtaques = 0.5f; // Retraso después de cada ataque

    private float contadorTiempo = 0f; // Contador de tiempo para el combo
    private int contadorClicks = 0; // Contador de clics para el combo
    private bool ataqueEjecutado = false; // Indicador de si el ataque actual ya se ha ejecutado

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            contadorClicks++;

            if (contadorClicks == 1)
            {
                // Primer ataque: Ataque ligero
                Debug.Log("Ataque ligero");
            }
            else if (contadorClicks == 2)
            {
                // Segundo ataque: Ataque mediano
                Debug.Log("Ataque mediano");
            }
            else if (contadorClicks == 3)
            {
                // Tercer ataque: Ataque pesado
                Debug.Log("Ataque pesado");
            }

            // Reiniciar el contador de tiempo después de cada clic
            contadorTiempo = 0f;
            ataqueEjecutado = true;
        }

        if (ataqueEjecutado)
        {
            contadorTiempo += Time.deltaTime;

            if (contadorTiempo >= retrasoEntreAtaques)
            {
                // Reiniciar el contador de clics después de un retraso entre ataques
                contadorClicks = 0;
                ataqueEjecutado = false;
            }
        }

        if (contadorTiempo >= tiempoMaximoCombo)
        {
            // Reiniciar el contador de tiempo y clics si se excede el tiempo máximo para completar el combo
            contadorTiempo = 0f;
            contadorClicks = 0;
            ataqueEjecutado = false;
        }
    }
}


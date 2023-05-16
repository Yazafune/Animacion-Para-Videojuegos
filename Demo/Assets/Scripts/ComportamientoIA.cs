using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComportamientoIA : MonoBehaviour
{
    public Transform[] puntos; // Array de transform para almacenar los puntos de movimiento
    public float tiempoEsperaMinimo = 1f; // Tiempo m�nimo de espera en cada punto
    public float tiempoEsperaMaximo = 3f; // Tiempo m�ximo de espera en cada punto
    public float velocidadMovimiento = 3f; // Velocidad de movimiento hacia el punto
    public float velocidadRotacion = 5f; // Velocidad de rotaci�n hacia el punto

    private int indicePuntoActual; // �ndice del punto actual
    private float tiempoEspera; // Tiempo de espera en el punto actual

    private void Start()
    {
        tiempoEspera = Random.Range(tiempoEsperaMinimo, tiempoEsperaMaximo); // Establecer un tiempo de espera aleatorio inicial

        // Verificar si hay puntos disponibles
        if (puntos.Length > 0)
        {
            indicePuntoActual = Random.Range(0, puntos.Length); // Elegir aleatoriamente un punto inicial
            MoverseHaciaPuntoActual(); // Iniciar el movimiento hacia el punto actual
        }
    }

    private void Update()
    {
        // Verificar si el NPC ha llegado al punto actual
        if (Vector3.Distance(transform.position, puntos[indicePuntoActual].position) <= 0.2f)
        {
            tiempoEspera -= Time.deltaTime; // Actualizar el tiempo de espera

            // Verificar si ha pasado el tiempo de espera en el punto actual
            if (tiempoEspera <= 0f)
            {
                ElegirNuevoPunto(); // Elegir un nuevo punto aleatoriamente
            }
        }

        MoverseHaciaPuntoActual();
        RotarHaciaPunto();
    }

    private void MoverseHaciaPuntoActual()
    {
        if (puntos.Length > 0)
        {
            // Verificar si el �ndice del punto actual est� dentro del rango v�lido
            if (indicePuntoActual >= 0 && indicePuntoActual < puntos.Length)
            {
                Vector3 direccion = puntos[indicePuntoActual].position - transform.position; // Calcular la direcci�n hacia el punto
                direccion.y = 0f; // No aplicar movimiento vertical

                transform.Translate(direccion.normalized * velocidadMovimiento * Time.deltaTime, Space.World); // Moverse hacia el punto
            }
        }
    }

    private void ElegirNuevoPunto()
    {
        // Elegir un nuevo �ndice de punto aleatoriamente
        int nuevoIndice = Random.Range(0, puntos.Length);

        // Verificar si el nuevo �ndice es diferente al actual
        if (nuevoIndice != indicePuntoActual)
        {
            indicePuntoActual = nuevoIndice; // Actualizar el �ndice del punto actual

            tiempoEspera = Random.Range(tiempoEsperaMinimo, tiempoEsperaMaximo); // Establecer un nuevo tiempo de espera aleatorio
        }
        else
        {
            ElegirNuevoPunto(); // Si el nuevo �ndice es igual al actual, elegir nuevamente
        }
    }

    private void RotarHaciaPunto()
    {
        if (puntos.Length > 0)
        {
            // Verificar si el �ndice del punto actual est� dentro del rango v�lido
            if (indicePuntoActual >= 0 && indicePuntoActual < puntos.Length)
            {
                Vector3 direccion = puntos[indicePuntoActual].position - transform.position; // Calcular la direcci�n hacia el punto

                if (direccion != Vector3.zero)
                {
                    Quaternion rotacionDeseada = Quaternion.LookRotation(direccion); // Obtener la rotaci�n deseada hacia el punto

                    transform.rotation = Quaternion.Slerp(transform.rotation, rotacionDeseada, velocidadRotacion * Time.deltaTime); // Rotar gradualmente hacia el punto
                }
            }
        }
    }
}







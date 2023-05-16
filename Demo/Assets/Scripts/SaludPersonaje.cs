using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SaludPersonaje : MonoBehaviour
{
    public int saludMaxima = 100; // Salud máxima del personaje
    [SerializeField] int saludActual; // Salud actual del personaje

    private bool regenerandoSalud = false; // Variable que indica si se está regenerando la salud
    public int tiempoEspera = 6; // Tiempo de espera en segundos antes de iniciar la regeneración de salud
    public float tiempoRegeneracion = 6f; // Tiempo en segundos para regenerar la salud
    public int cantidadRegeneracion = 5; // Cantidad de salud regenerada por segundo

    private float tiempoUltimoDanio; // Tiempo en que se recibió el último daño
    private int saludInicialRegeneracion; // Valor inicial de salud al iniciar la regeneración

    private void Start()
    {
        saludActual = saludMaxima; // Inicializar la salud actual con el valor máximo al iniciar el juego
    }

    private void Update()
    {
        if (!regenerandoSalud && saludActual < saludMaxima && Time.time - tiempoUltimoDanio >= tiempoEspera)
        {
            saludInicialRegeneracion = saludActual;
            StartCoroutine(RegenerarSalud());
        }
    }

    public void RecibirDanio(int cantidadDanio)
    {
        saludActual -= cantidadDanio; // Restar la cantidad de daño recibido a la salud actual
        tiempoUltimoDanio = Time.time; // Actualizar el tiempo del último daño recibido

        if (saludActual <= 0)
        {
            // Si la salud llega a cero, llamar a la función de muerte
            Morir();
        }
    }

    private void Morir()
    {
        // Aquí puedes agregar la lógica para cuando el personaje muere, como reproducir una animación de muerte, desactivar controles, etc.
        Debug.Log("El personaje ha muerto");

        // Cargar la escena del menú principal
        SceneManager.LoadScene("MenuPrincipal");
    }

    private System.Collections.IEnumerator RegenerarSalud()
    {
        float tiempoInicioRegeneracion = Time.time;
        float tiempoActual = 0f;

        while (tiempoActual < tiempoRegeneracion)
        {
            float saludInterpolada = Mathf.Lerp(saludInicialRegeneracion, saludMaxima, tiempoActual / tiempoRegeneracion);
            saludActual = Mathf.RoundToInt(saludInterpolada);
            tiempoActual = Time.time - tiempoInicioRegeneracion;
            yield return null;
        }

        saludActual = saludMaxima;
        regenerandoSalud = false;
    }
}








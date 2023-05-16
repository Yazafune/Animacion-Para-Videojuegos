using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SaludPersonaje : MonoBehaviour
{
    public int saludMaxima = 100; // Salud m�xima del personaje
    [SerializeField] int saludActual; // Salud actual del personaje

    private bool regenerandoSalud = false; // Variable que indica si se est� regenerando la salud
    public int tiempoEspera = 6; // Tiempo de espera en segundos antes de iniciar la regeneraci�n de salud
    public float tiempoRegeneracion = 6f; // Tiempo en segundos para regenerar la salud
    public int cantidadRegeneracion = 5; // Cantidad de salud regenerada por segundo

    private float tiempoUltimoDanio; // Tiempo en que se recibi� el �ltimo da�o
    private int saludInicialRegeneracion; // Valor inicial de salud al iniciar la regeneraci�n

    private void Start()
    {
        saludActual = saludMaxima; // Inicializar la salud actual con el valor m�ximo al iniciar el juego
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
        saludActual -= cantidadDanio; // Restar la cantidad de da�o recibido a la salud actual
        tiempoUltimoDanio = Time.time; // Actualizar el tiempo del �ltimo da�o recibido

        if (saludActual <= 0)
        {
            // Si la salud llega a cero, llamar a la funci�n de muerte
            Morir();
        }
    }

    private void Morir()
    {
        // Aqu� puedes agregar la l�gica para cuando el personaje muere, como reproducir una animaci�n de muerte, desactivar controles, etc.
        Debug.Log("El personaje ha muerto");

        // Cargar la escena del men� principal
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








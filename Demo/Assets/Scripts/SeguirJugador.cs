using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeguirJugador : MonoBehaviour
{
    public Transform jugador; // Referencia al transform del jugador
    public float suavidadMovimiento = 0.5f; // Suavidad del movimiento de la c�mara
    public float velocidadRotacion = 3f; // Velocidad de rotaci�n de la c�mara

    private Vector3 desplazamiento; // Desplazamiento relativo entre la c�mara y el jugador

    private float mouseX; // Movimiento horizontal del mouse
    private float mouseY; // Movimiento vertical del mouse

    private void Start()
    {
        desplazamiento = transform.position - jugador.position; // Calcular el desplazamiento inicial
        Cursor.lockState = CursorLockMode.Locked; // Bloquear el cursor en el centro de la pantalla
    }

    private void LateUpdate()
    {
        mouseX += Input.GetAxis("Mouse X") * velocidadRotacion; // Obtener el movimiento horizontal del mouse
        mouseY -= Input.GetAxis("Mouse Y") * velocidadRotacion; // Obtener el movimiento vertical del mouse

        mouseY = Mathf.Clamp(mouseY, -35f, 60f); // Limitar el �ngulo de rotaci�n vertical

        Quaternion rotacionY = Quaternion.Euler(0f, mouseX, 0f); // Calcular la rotaci�n horizontal del jugador
        Quaternion rotacionX = Quaternion.Euler(mouseY, mouseX, 0f); // Calcular la rotaci�n vertical del jugador

        jugador.rotation = Quaternion.Slerp(jugador.rotation, rotacionY, suavidadMovimiento); // Interpolar suavemente la rotaci�n horizontal del jugador

        Vector3 posicionObjetivo = jugador.position + rotacionX * desplazamiento; // Calcular la posici�n objetivo de la c�mara

        transform.position = Vector3.Lerp(transform.position, posicionObjetivo, suavidadMovimiento); // Interpolar suavemente la posici�n de la c�mara hacia la posici�n objetivo

        transform.LookAt(jugador.position); // Mantener la c�mara mirando hacia el jugador
    }
}

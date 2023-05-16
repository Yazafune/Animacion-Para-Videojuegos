using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeguirJugador : MonoBehaviour
{
    public Transform jugador; // Referencia al transform del jugador
    public float suavidadMovimiento = 0.5f; // Suavidad del movimiento de la cámara
    public float velocidadRotacion = 3f; // Velocidad de rotación de la cámara

    private Vector3 desplazamiento; // Desplazamiento relativo entre la cámara y el jugador

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

        mouseY = Mathf.Clamp(mouseY, -35f, 60f); // Limitar el ángulo de rotación vertical

        Quaternion rotacionY = Quaternion.Euler(0f, mouseX, 0f); // Calcular la rotación horizontal del jugador
        Quaternion rotacionX = Quaternion.Euler(mouseY, mouseX, 0f); // Calcular la rotación vertical del jugador

        jugador.rotation = Quaternion.Slerp(jugador.rotation, rotacionY, suavidadMovimiento); // Interpolar suavemente la rotación horizontal del jugador

        Vector3 posicionObjetivo = jugador.position + rotacionX * desplazamiento; // Calcular la posición objetivo de la cámara

        transform.position = Vector3.Lerp(transform.position, posicionObjetivo, suavidadMovimiento); // Interpolar suavemente la posición de la cámara hacia la posición objetivo

        transform.LookAt(jugador.position); // Mantener la cámara mirando hacia el jugador
    }
}

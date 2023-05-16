using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimientoPersonaje : MonoBehaviour
{
    public float velocidadMovimiento = 5f; // Velocidad de movimiento normal
    public float velocidadSprint = 10f; // Velocidad de sprint
    public float velocidadRotacion = 10f; // Velocidad de rotación
    public float fuerzaSalto = 5f; // Fuerza de salto

    private float velocidadActual; // Velocidad actual de movimiento
    private Rigidbody rb; // Referencia al componente Rigidbody

    private void Start()
    {
        velocidadActual = velocidadMovimiento; // Establecer la velocidad actual al valor inicial
        rb = GetComponent<Rigidbody>(); // Obtener la referencia al componente Rigidbody
    }

    private void Update()
    {
        float movimientoHorizontal = Input.GetAxis("Horizontal");
        float movimientoVertical = Input.GetAxis("Vertical");

        Vector3 movimiento = transform.forward * movimientoVertical * velocidadActual +
                             transform.right * movimientoHorizontal * velocidadActual;

        rb.MovePosition(transform.position + movimiento * Time.deltaTime);

        if (movimiento != Vector3.zero)
        {
            Quaternion rotacionDeseada = Quaternion.LookRotation(movimiento);
            transform.rotation = Quaternion.Slerp(transform.rotation, rotacionDeseada, velocidadRotacion * Time.deltaTime);
        }

        // Verificar si se presionó la tecla Shift para sprintar
        if (Input.GetKey(KeyCode.LeftShift))
        {
            velocidadActual = velocidadSprint; // Cambiar la velocidad actual a la velocidad de sprint
        }
        else
        {
            velocidadActual = velocidadMovimiento; // Volver a la velocidad de movimiento normal
        }

        // Verificar si se presionó la tecla de espacio para saltar
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Saltar();
        }
    }

    private void Saltar()
    {
        rb.AddForce(Vector3.up * fuerzaSalto, ForceMode.Impulse);
    }
}


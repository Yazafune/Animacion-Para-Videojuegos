using UnityEngine;

public class proyectil : MonoBehaviour
{
    public float velocidad = 10f; // Velocidad de movimiento del proyectil
    public float tiempoDeVida = 2f; // Tiempo que tarda el proyectil en desaparecer

    private float contadorTiempo = 0f; // Contador de tiempo

    private void Update()
    {
        // Mover el proyectil hacia adelante
        transform.Translate(Vector3.forward * velocidad * Time.deltaTime);

        // Incrementar el contador de tiempo
        contadorTiempo += Time.deltaTime;

        // Comprobar si el proyectil debe desaparecer
        if (contadorTiempo >= tiempoDeVida)
        {
            // Destruir el proyectil
            Destroy(gameObject);
        }
    }
}


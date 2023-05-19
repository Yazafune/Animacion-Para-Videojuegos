using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

    
    public class VidaYDaño : MonoBehaviour
    {
        public int vida = 100;

        [SerializeField] private UnityEvent onDeath;

        public void RestarVida(int cantidad)
        {
            vida -= cantidad;
            UIVida.instance.Salud(cantidad);

            if (cantidad <= 0)
            {
                onDeath?.Invoke();
                CambiarDeScena();
            }
        }
    
        private void CambiarDeScena()
        {
            Debug.Log("El personaje ha muerto");
            SceneManager.LoadScene("MenuPrincipal");
        }
        
        
    
    
    }



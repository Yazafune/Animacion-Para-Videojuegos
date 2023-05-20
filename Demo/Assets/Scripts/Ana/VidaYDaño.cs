using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

    
    public class VidaYDaño : MonoBehaviour
    {
        public int vida = 100;
        public bool muerto = false;

        [SerializeField] private UnityEvent onDeath;
        [SerializeField] private UnityEvent onDamage;

        public void RestarVida(int cantidad)
        {
            vida -= cantidad;
            UIVida.instance.Salud(cantidad);
            
            if (vida <= 0 && muerto == false)
            {
                muerto = true;
                onDeath?.Invoke();
                Debug.Log("me mori");
                Invoke("CambiarDeScena", 4);
            }

            if (muerto == true)
            {
                return;
            }
            
            
            onDamage?.Invoke();
            Debug.Log("auch");
            
        }
    
        private void CambiarDeScena()
        {
            Debug.Log("El personaje ha muerto");
            SceneManager.LoadScene("MenuPrincipal");
        }
        
        
    
    
    }



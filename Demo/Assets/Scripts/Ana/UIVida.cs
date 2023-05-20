using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class UIVida : MonoBehaviour
{
    public static UIVida instance;
    public Slider sliderVida;
    private float sumVida;
    private float resVida;
    public Color vidaAlta;
    public Color vidaMedia;
    public Color vidaBaja;

    private void Start()
    {
        instance = this;
    }

    public void Salud(float value)
    {
        resVida = value;
        StartCoroutine("reducirVida");
    }

    IEnumerator reducirVida()
    {
        while (resVida>0)
        {
            resVida --;
            sliderVida.value -= 1f;
            if (sliderVida.value <= sliderVida.maxValue/2 && sliderVida.value > 25)
            {
                GameObject.Find("Fill").GetComponent<Image>().color = vidaMedia;
            }
            else if (sliderVida.value <= 25)
            {
                GameObject.Find("Fill").GetComponent<Image>().color = vidaBaja;
            }
            else
            {
                GameObject.Find("Fill").GetComponent<Image>().color = vidaAlta;
            }

            yield return new WaitForSeconds(0.03f);
        }
    }
    
   
}

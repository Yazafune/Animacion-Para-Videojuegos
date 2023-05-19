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

    public void Damage(float value)
    {
        resVida = value;
        StartCoroutine("reducirVida");
    }
    
    public void Salud(float value)
    {
        sumVida = value;
        StartCoroutine("restaurarVida");
    }

    IEnumerator reducirVida()
    {
        while (resVida>0)
        {
            resVida--;
            sliderVida.value -= 0.01f;
            if (sliderVida.value <= sliderVida.maxValue/2 && sliderVida.value > 0.25)
            {
                GameObject.Find("Fill").GetComponent<Image>().color = vidaMedia;
            }
            else if (sliderVida.value <= 0.25)
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
    
    IEnumerator restaurarVida()
    {
        while (sumVida>0)
        {
            sumVida--;
            sliderVida.value += 1f;
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

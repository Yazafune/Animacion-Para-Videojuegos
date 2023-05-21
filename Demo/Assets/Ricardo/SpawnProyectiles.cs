using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnProyectiles : MonoBehaviour
{
    [SerializeField] REvents ataque1, ataque2, ataque3;
    [SerializeField] GameObject proyectil1, proyectil2, proyectil3;
    [SerializeField] float delay1, delay2, delay3;
    [SerializeField] Transform pos1, pos2, pos3;

    private void Start()
    {
        ataque1.GEvent += Proyectil1;
        ataque2.GEvent += Proyectil2;
        ataque3.GEvent += Proyectil3;
    }
    void Proyectil1()
    {
        StartCoroutine(SpawnProyectil(proyectil1,delay1,pos1));
    }
    void Proyectil2()
    {
        StartCoroutine(SpawnProyectil(proyectil2, delay2, pos2));
    }
    void Proyectil3()
    {
        StartCoroutine(SpawnProyectil(proyectil3, delay3, pos3));
    }
    IEnumerator SpawnProyectil(GameObject proyectil, float delay,Transform pos)
    {
        yield return new WaitForSeconds(delay);
        Instantiate(proyectil, pos);
    }
    private void OnDestroy()
    {
        ataque1.GEvent -= Proyectil1;
        ataque2.GEvent -= Proyectil2;
        ataque3.GEvent -= Proyectil3;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DesactivarObjetoEnSpawn : MonoBehaviour
{
    // El objeto que quieres que desaparezca
    public GameObject objetoParaDesaparecer;

    void Start()
    {
        // Asegurarse de que el objeto esté activado al principio
        objetoParaDesaparecer.SetActive(true);
    }

    // Cuando la bola entra al trigger
    void OnTriggerEnter(Collider other)
    {
        // Verificamos que sea la bola que entra
        if (other.CompareTag("Bola"))
        {
            // Desactivamos el objeto cuando la bola entra completamente en el spawn
            objetoParaDesaparecer.SetActive(false);
        }
    }

    // Cuando la bola sale del trigger
    void OnTriggerExit(Collider other)
    {
        // Verificamos que sea la bola que sale
        if (other.CompareTag("Bola"))
        {
            // Activamos el objeto cuando la bola sale del spawn
            objetoParaDesaparecer.SetActive(true);
        }
    }
}


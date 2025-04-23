using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bola : MonoBehaviour
{
    private bool yaTocoInterruptor = false;

    void Start()
    {
        Invoke("Finalizar", 5f); 
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Interruptor") && !yaTocoInterruptor)
        {
            yaTocoInterruptor = true;
            GameGoldberg.instancia.TerminarTirada(true);
            Destroy(gameObject);
        }
    }

    void Finalizar()
    {
        if (!yaTocoInterruptor)
        {
            GameGoldberg.instancia.TerminarTirada(false);
            Destroy(gameObject);
        }
    }
}




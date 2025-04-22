using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interruptor : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Bola"))
        {
            GameGoldberg.instancia.ActivarInterruptor();
        }
    }
}


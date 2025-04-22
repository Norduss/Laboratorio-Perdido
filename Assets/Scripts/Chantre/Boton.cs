using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boton : MonoBehaviour
{
    public GameObject prefabBola;
    public Transform puntoDeSpawn;

    public void LanzarBola()
    {
        if (GameGoldberg.instancia.QuedanIntentos())
        {
            Instantiate(prefabBola, puntoDeSpawn.position, Quaternion.identity);
        }
        else
        {
            Debug.Log("No hay más intentos o el interruptor ya fue activado.");
        }
    }
}


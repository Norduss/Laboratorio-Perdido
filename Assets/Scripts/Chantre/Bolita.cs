using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bola : MonoBehaviour
{
    void Start()
    {
        if (GameGoldberg.instancia != null)
        {
            GameGoldberg.instancia.RegistrarTirada();
        }

        Destroy(gameObject, 10f); // para evitar que se acumulen
    }
}


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RestaurarPosicionJugador : MonoBehaviour
{
    void Start()
    {
        Transform jugador = GameObject.FindGameObjectWithTag("Player").transform;

        // Solo restaurar si la posición guardada no es (0,0,0)
        Vector3 posicionGuardada = GameStateManager.Instance.posicionJugador;

        if (posicionGuardada != Vector3.zero)
        {
            jugador.position = posicionGuardada;
        }
    }
}

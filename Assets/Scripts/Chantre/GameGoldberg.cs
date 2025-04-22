using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameGoldberg : MonoBehaviour
{
    public static GameGoldberg instancia;

    public GameObject puerta;
    public int intentosMaximos = 3;
    public int intentosActuales = 0;
    private bool interruptorActivado = false;

    void Awake()
    {
        if (instancia == null) instancia = this;
        else Destroy(gameObject);
    }

    public void RegistrarTirada()
    {
        intentosActuales++;

        UIManager.instancia.ActualizarIntentos(intentosActuales, intentosMaximos);

        if (intentosActuales >= intentosMaximos && !interruptorActivado)
        {
            Debug.Log("Fallaste las 3 tiradas.");
            UIManager.instancia.MostrarMensajeFinal(false);
            UIManager.instancia.MostrarBotonReiniciar(true);
        }
    }

    public void ActivarInterruptor()
    {
        if (!interruptorActivado)
        {
            interruptorActivado = true;
            Debug.Log("¡Interruptor tocado! Puerta abierta");
            puerta.SetActive(false);

            UIManager.instancia.MostrarMensajeFinal(true);
            UIManager.instancia.MostrarBotonReiniciar(true);
        }
    }

    public bool QuedanIntentos()
    {
        return intentosActuales < intentosMaximos && !interruptorActivado;
    }
}



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

    private void Awake()
    {
        if (instancia == null)
            instancia = this;
        else
            Destroy(gameObject);
    }

    public void RegistrarTirada()
    {
        intentosActuales++;
        UIManager.instancia.ActualizarIntentos(intentosActuales, intentosMaximos);
    }

    public void TerminarTirada(bool acerto)
    {
        if (acerto)
        {
            interruptorActivado = true;
            puerta.SetActive(false);
            UIManager.instancia.MostrarMensajeFinal(true);
            UIManager.instancia.MostrarBotonReintentar(false);
        }
        else
        {
            if (intentosActuales >= intentosMaximos)
            {
                UIManager.instancia.MostrarMensajeFinal(false);
                UIManager.instancia.MostrarBotonReintentar(false);
            }
            else
            {
                UIManager.instancia.MostrarBotonReintentar(true);
            }
        }
    }

    public bool PuedeLanzar()
    {
        return intentosActuales < intentosMaximos && !interruptorActivado;
    }
}





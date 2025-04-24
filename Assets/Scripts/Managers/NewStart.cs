using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NewStart : MonoBehaviour
{
    public void ReiniciarEscena()
    {
        CodigoNumerico.codigoCorrecto = false;

        //Reiniciar la posición del jugador guardada
        GameStateManager.Instance.posicionGuardada = false;
        GameStateManager.Instance.posicionJugador = Vector3.zero;

        //Reiniciar contador si existe
        if (Contador.Instance != null)
        {
            Contador.Instance.ReiniciarContador();
        }

        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

}

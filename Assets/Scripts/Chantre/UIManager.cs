using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
    public static UIManager instancia;

    public TextMeshProUGUI textoIntentos;
    public GameObject botonReintentar;

    private bool interruptorActivado = false; // Control de si el interruptor fue activado
    private int intentosMaximos = 3; // El número máximo de intentos

    void Awake()
    {
        if (instancia == null) instancia = this;
        else Destroy(gameObject);

        MostrarBotonReintentar(false);
    }

    public void ActualizarIntentos(int actuales)
    {
        textoIntentos.text = $"Tiradas: {actuales} / {intentosMaximos}";

        // Esperar hasta que todos los intentos se hayan completado
        if (actuales == intentosMaximos)
        {
            StartCoroutine(EsperarFinDeTirada());  // Esperar a que termine la última tirada
        }
    }

    // Coroutine para esperar a que termine la tirada antes de mostrar el mensaje
    private IEnumerator EsperarFinDeTirada()
    {
        // Esperamos un pequeño tiempo para asegurar que el interruptor haya tenido la oportunidad de ser tocado
        yield return new WaitForSeconds(10f);

        // Mostrar mensaje de fallo solo si el interruptor no fue activado
        if (!interruptorActivado)
        {
            MostrarMensajeFinal(false); // Mostrar el mensaje de fallo al final de los intentos
        }
    }

    public void MostrarMensajeFinal(bool gano)
    {
        if (gano)
        {
            textoIntentos.text = "¡Puerta abierta!";
        }
        else
        {
            textoIntentos.text = "Fallaste las 3 tiradas.";
        }
    }

    public void MostrarBotonReintentar(bool estado)
    {
        botonReintentar.SetActive(estado);
    }

    // Método para marcar si el interruptor fue activado
    public void ActivarInterruptor()
    {
        interruptorActivado = true;
        MostrarMensajeFinal(true); // Cambiar el mensaje a "Puerta abierta"
    }

    // Método para reiniciar la partida y el estado del interruptor
    public void ReiniciarEstado()
    {
        interruptorActivado = false;
        textoIntentos.text = "Tiradas: 0 / 3"; // Resetea el contador de intentos
    }
}

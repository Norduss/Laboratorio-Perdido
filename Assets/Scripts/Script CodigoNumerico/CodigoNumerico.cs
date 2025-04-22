using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CodigoNumerico : MonoBehaviour
{
    public Text entradaTexto;
    public string respuestaCorrecta;
    public GameObject[] botonesNumericos; // para ocultarlos cuando acierte
    public GameObject canvasUI;
    public GameObject congratulation;
    public GameObject objetoINTECTACTUABLE;
    public GameObject puertas;

    private string entradaJugador = "";

    public void BotonNumero(string numero)
    {
        if (entradaJugador.Length < 4)
        {
            entradaJugador += numero;
            entradaTexto.text = entradaJugador;
        }
    }

    public void BotonClear()
    {
        entradaJugador = "";
        entradaTexto.text = "";
    }

    public void BotonOK()
    {
        if (entradaJugador == respuestaCorrecta)
        {
            Debug.Log("¡Código correcto!");
            congratulation.SetActive(true);
            entradaTexto.gameObject.SetActive(false);

            foreach (GameObject boton in botonesNumericos)
                boton.SetActive(false);

            StartCoroutine(CerrarCanvasDespuesDeDelay());
        }
        else
        {
            Debug.Log("Código incorrecto.");
            entradaJugador = "";
            entradaTexto.text = "";
        }
    }

    IEnumerator CerrarCanvasDespuesDeDelay()
    {
        yield return new WaitForSeconds(2f);
        Destroy(objetoINTECTACTUABLE);
        Destroy(puertas);
        canvasUI.SetActive(false);

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        // Aquí puedes volver a activar movimiento del jugador si lo habías desactivado
    }
}
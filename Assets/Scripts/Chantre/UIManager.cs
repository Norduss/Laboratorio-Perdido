using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public static UIManager instancia;

    public TextMeshProUGUI textoIntentos;
    public GameObject botonReiniciar;

    void Awake()
    {
        if (instancia == null) instancia = this;
        else Destroy(gameObject);

        MostrarBotonReiniciar(false);
    }

    public void ActualizarIntentos(int actuales, int maximos)
    {
        textoIntentos.text = $"Tiradas: {actuales} / {maximos}";
    }

    public void MostrarMensajeFinal(bool gano)
    {
        textoIntentos.text = gano ? "¡Puerta abierta!" : "Fallaste. Reinicia.";
    }

    public void MostrarBotonReiniciar(bool estado)
    {
        botonReiniciar.SetActive(estado);
    }
}

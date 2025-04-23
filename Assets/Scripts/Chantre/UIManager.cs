using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
    public static UIManager instancia;

    public TextMeshProUGUI textoIntentos;
    public GameObject botonReintentar;

    void Awake()
    {
        if (instancia == null) instancia = this;
        else Destroy(gameObject);

        MostrarBotonReintentar(false);
    }

    public void ActualizarIntentos(int actuales, int maximos)
    {
        textoIntentos.text = $"Tiradas: {actuales} / {maximos}";
    }

    public void MostrarMensajeFinal(bool gano)
    {
        textoIntentos.text = gano ? "¡Puerta abierta!" : "Fallaste las 3 tiradas.";
    }

    public void MostrarBotonReintentar(bool estado)
    {
        botonReintentar.SetActive(estado);
    }
}




using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement; 

public class UIManager : MonoBehaviour
{
    public static UIManager instancia;

    public TextMeshProUGUI textoIntentos;
    public GameObject botonReintentar;

    private bool interruptorActivado = false; 
    private int intentosMaximos = 3; 

    void Awake()
    {
        if (instancia == null) instancia = this;
        else Destroy(gameObject);

        MostrarBotonReintentar(false);
    }

    public void ActualizarIntentos(int actuales)
    {
        textoIntentos.text = $"Tiradas: {actuales} / {intentosMaximos}";

   
        if (actuales == intentosMaximos)
        {
            StartCoroutine(EsperarFinDeTirada());  
        }
    }


    private IEnumerator EsperarFinDeTirada()
    {
        yield return new WaitForSeconds(10f);


        if (!interruptorActivado)
        {
            MostrarMensajeFinal(false); 
        }
    }

    public void MostrarMensajeFinal(bool gano)
    {
        if (gano)
        {
            textoIntentos.text = "¡Puerta abierta!";
            CargarEscenaFinal(); 
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

    public void ActivarInterruptor()
    {
        interruptorActivado = true;
        MostrarMensajeFinal(true); 
    }

    public void ReiniciarEstado()
    {
        interruptorActivado = false;
        textoIntentos.text = "Tiradas: 0 / 3"; 
    }

    public void CargarEscenaFinal()
    {
        
        SceneManager.LoadScene("EscenaFinal");  
    }
}

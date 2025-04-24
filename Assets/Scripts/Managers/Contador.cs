using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Contador : MonoBehaviour
{
    public static Contador Instance;

    public float contadorTiempo = 120;
    [SerializeField] private int danioBomba = 100;

    public Text tiempoTexto;

    private bool exploto = false;
    private float tiempoInicial; // <- Guardamos el valor original

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); //No destruir al cambiar de escena
            tiempoInicial = contadorTiempo; //Guardamos el tiempo original
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Update()
    {
        if (!CodigoNumerico.codigoCorrecto || exploto) return;

        contadorTiempo -= Time.deltaTime;

        // Buscar el texto nuevamente si no está asignado
        if (tiempoTexto == null)
        {
            GameObject textoGO = GameObject.Find("TextoContador");
            if (textoGO != null)
                tiempoTexto = textoGO.GetComponent<Text>();
        }

        MostrarTiempoEnPantalla(contadorTiempo);

        if (contadorTiempo <= 0f)
        {
            autoDestroy();
        }
    }

    void MostrarTiempoEnPantalla(float tiempo)
    {
        if (tiempoTexto == null) return;

        tiempo = Mathf.Max(0f, tiempo);

        int minutos = Mathf.FloorToInt(tiempo / 60);
        int segundos = Mathf.FloorToInt(tiempo % 60);
        tiempoTexto.text = minutos.ToString("00") + ":" + segundos.ToString("00");
    }

    void autoDestroy()
    {
        exploto = true;

        GameObject jugador = GameObject.FindWithTag("Player");
        if (jugador != null)
        {
            PlayerManager player = jugador.GetComponent<PlayerManager>();
            if (player != null)
            {
                player.GetDamage(danioBomba);
            }
        }

        Debug.Log("¡Bomba explotó!");
    }

    //Método público para reiniciar el contador
    public void ReiniciarContador()
    {
        contadorTiempo = tiempoInicial;
        exploto = false;

        if (tiempoTexto == null)
        {
            GameObject textoGO = GameObject.Find("TextoContador");
            if (textoGO != null)
                tiempoTexto = textoGO.GetComponent<Text>();
        }

        MostrarTiempoEnPantalla(contadorTiempo);
    }

}

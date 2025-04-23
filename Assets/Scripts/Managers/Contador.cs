using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Contador : MonoBehaviour
{
    public float contadorTiempo = 120;
    [SerializeField] private int danioBomba = 100;

    public Text tiempoTexto;

    void MostrarTiempoEnPantalla(float tiempo)
    {
        tiempo = Mathf.Max(0f, tiempo);

        int minutos = Mathf.FloorToInt(tiempo / 60);
        int segundos = Mathf.FloorToInt(tiempo % 60);
        tiempoTexto.text = minutos.ToString("00") + ":" + segundos.ToString("00");
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!CodigoNumerico.codigoCorrecto) return; // si aún no se activa, no hacer nada

        contadorTiempo -= Time.deltaTime;

        MostrarTiempoEnPantalla(contadorTiempo);

        if (contadorTiempo <= 0)
        {
            autoDestroy();
        }
    }

    void autoDestroy()
    {
        GameObject jugador = GameObject.FindWithTag("Player"); // o el tag que uses
        PlayerManager player = jugador.GetComponent<PlayerManager>();

        player.GetDamage(danioBomba);
        Destroy(gameObject);
    }
}

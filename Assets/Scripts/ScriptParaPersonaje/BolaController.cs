using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BolaController : MonoBehaviour
{
    public Transform posicionInicial;
    public Rigidbody rbBola;
    public GameObject puerta;
    public AudioSource audioSource;
    public AudioClip sonidoExito;
    public AudioClip sonidoFallo;
    public int intentosMaximos = 3;
    private int intentosActuales = 0;
    private bool puedeReintentar = true;

    private void Start()
    {
        ReiniciarBola();
    }

    public void ReiniciarBola()
    {
        rbBola.velocity = Vector3.zero;
        rbBola.angularVelocity = Vector3.zero;
        rbBola.transform.position = posicionInicial.position;
        rbBola.transform.rotation = Quaternion.identity;
        puedeReintentar = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Interruptor") && puedeReintentar)
        {
            audioSource.PlayOneShot(sonidoExito);
            puerta.SetActive(false); // o animación
            puedeReintentar = false;
        }
    }

    private void Update()
    {
        // Si la bola cae fuera del rango, se reinicia
        if (rbBola.transform.position.y < -5f && puedeReintentar)
        {
            intentosActuales++;
            if (intentosActuales < intentosMaximos)
            {
                audioSource.PlayOneShot(sonidoFallo);
                ReiniciarBola();
            }
            else
            {
                Debug.Log("¡Se acabaron los intentos!");
                // Aquí puedes reiniciar todo o bloquear la puerta
            }
        }
    }
}


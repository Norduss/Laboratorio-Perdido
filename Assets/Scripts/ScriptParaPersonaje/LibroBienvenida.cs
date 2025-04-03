using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LibroBienvenida : MonoBehaviour
{
    public GameObject Mensaje;
    public GameObject libro;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Mensaje.SetActive(true);

            StartCoroutine(DesactivarMensajeConRetraso());
        }
    }

    private IEnumerator DesactivarMensajeConRetraso()
    {
        yield return new WaitForSeconds(3.5f);
        Mensaje.SetActive(false);
    }
}

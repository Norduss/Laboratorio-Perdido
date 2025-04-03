using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LibroBienvenida : MonoBehaviour
{
    public GameObject Mensaje;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("libroInicio"))
        {
            Mensaje.SetActive(true);

            StartCoroutine(DesactivarMensajeConRetraso());
        }
    }

    private IEnumerator DesactivarMensajeConRetraso()
    {
        yield return new WaitForSeconds(5f);
        Mensaje.SetActive(false);
    }

}

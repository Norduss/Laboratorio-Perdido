using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class InteraccionPuerta : MonoBehaviour
{
    public GameObject textoUI; 

    private void Update()
    {
        Ray ray = new Ray(Camera.main.transform.position, Camera.main.transform.forward);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, 3f)) 
        {
            if (hit.collider.CompareTag("Puerta"))
            {
                // Activar texto
                textoUI.SetActive(true);

                if (Input.GetKeyDown(KeyCode.E))
                {
                    SceneManager.LoadScene("Goldberg - Chantre");
                }
            }
            else
            {
                textoUI.SetActive(false); 
            }
        }
        else
        {
            textoUI.SetActive(false);
        }
    }
}


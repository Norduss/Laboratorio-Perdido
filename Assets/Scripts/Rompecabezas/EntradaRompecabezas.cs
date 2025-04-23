using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EntradaRompecabezas : MonoBehaviour
{
    public string puzzleSceneName = "Juego";
    public float interactionDistance = 3f;
    public GameObject interactionPrompt; // Asigna aquí el Canvas (la letra "E") en el Inspector

    private Transform player;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;

        if (interactionPrompt != null)
        {
            interactionPrompt.SetActive(false); // Oculta el prompt al inicio
        }
    }

    void Update()
    {
        float distance = Vector3.Distance(transform.position, player.position);

        if (distance <= interactionDistance)
        {
            if (interactionPrompt != null)
                interactionPrompt.SetActive(true);

            if (Input.GetKeyDown(KeyCode.E))
            {
                SceneManager.LoadScene(puzzleSceneName);
            }
        }
        else
        {
            if (interactionPrompt != null)
                interactionPrompt.SetActive(false);
        }
    }
}

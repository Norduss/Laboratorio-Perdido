using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EntradaRompecabezas : MonoBehaviour
{
    public string puzzleSceneName = "Juego";
    public float interactionDistance = 3f;
    public GameObject interactionPrompt; // Asignamos el canvas aquí y en el texto ponemos "E" para interactuar

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
                // Guardamos la posición actual del jugador
                if (GameStateManager.Instance != null)
                {
                    GameStateManager.Instance.posicionJugador = player.position;
                }

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

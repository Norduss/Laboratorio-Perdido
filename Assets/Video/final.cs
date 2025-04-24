using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

public class FinalSceneManager : MonoBehaviour
{
    public VideoPlayer videoPlayer; // Asigna el Video Player en el Inspector

    // Llamar a este método cuando el interruptor se active
    public void ActivarEscenaFinal()
    {
        // Reproducir video
        videoPlayer.Play();

        // Aquí, si necesitas cargar una escena después del video, puedes usar:
        // SceneManager.LoadScene("FinalScene");
    }
}

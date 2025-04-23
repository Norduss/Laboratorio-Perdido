using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NewStart : MonoBehaviour
{
    public void ReiniciarEscena()
    {
        CodigoNumerico.codigoCorrecto = false;

        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ReturnToMainScene : MonoBehaviour
{
    public string mainSceneName = "Principal Scene"; 

    public void ReturnToMain()
    {
        SceneManager.LoadScene(mainSceneName);
    }
}

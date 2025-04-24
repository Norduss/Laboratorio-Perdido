using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class CinematicText : MonoBehaviour
{
    public Text cinematicText; 
    public string[] messages;  
    public float textSpeed = 0.05f; 
    public float timeBetweenMessages = 1f; 
    public string sceneToLoad = "Principal Scene"; 

    private int currentMessageIndex = 0;

    void Start()
    {
        StartCoroutine(ShowText());
    }

    IEnumerator ShowText()
    {
        
        while (currentMessageIndex < messages.Length)
        {
            cinematicText.text = ""; 
            string currentMessage = messages[currentMessageIndex];
            foreach (char letter in currentMessage)
            {
                cinematicText.text += letter;
                yield return new WaitForSeconds(textSpeed);
            }

            
            currentMessageIndex++;
            yield return new WaitForSeconds(timeBetweenMessages);
        }

        
        SceneManager.LoadScene(sceneToLoad);
    }
}


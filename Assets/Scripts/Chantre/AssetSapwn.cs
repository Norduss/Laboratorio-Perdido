using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DesactivarObjetoEnSpawn : MonoBehaviour
{

    public GameObject objetoParaDesaparecer;

    void Start()
    {
        
        objetoParaDesaparecer.SetActive(true);
    }

    
    void OnTriggerEnter(Collider other)
    {
        
        if (other.CompareTag("Bola"))
        {
           
            objetoParaDesaparecer.SetActive(false);
        }
    }


    void OnTriggerExit(Collider other)
    {
        
        if (other.CompareTag("Bola"))
        {
            
            objetoParaDesaparecer.SetActive(true);
        }
    }
}


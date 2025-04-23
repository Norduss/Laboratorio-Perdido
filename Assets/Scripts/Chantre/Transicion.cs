using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CambiarCamaraBoton : MonoBehaviour
{
    public CinemachineVirtualCamera camara1;
    public CinemachineVirtualCamera camara2;

    public void CambiarCamara()
    {
        camara1.Priority = 5;
        camara2.Priority = 10;
    }
}


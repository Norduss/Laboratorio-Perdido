using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIBombaPersistente : MonoBehaviour
{
    void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorControl : MonoBehaviour
{
    void Start()
    {
        // Desbloquear el cursor y hacerlo visible
        Cursor.lockState = CursorLockMode.None;  // Esto asegura que el cursor no esté bloqueado
        Cursor.visible = true;  // Asegura que el cursor sea visible
    }

    void Update()
    {
        // Opcional: Si quieres que el cursor se bloquee al presionar una tecla (por ejemplo, Escape)
        if (Input.GetKeyDown(KeyCode.Escape))  // Usamos Escape como ejemplo
        {
            Cursor.lockState = CursorLockMode.Locked;  // Bloquea el cursor
            Cursor.visible = false;  // Hace que el cursor sea invisible
        }
    }
}

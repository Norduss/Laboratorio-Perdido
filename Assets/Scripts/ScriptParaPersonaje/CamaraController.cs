using System.Collections;
using System.Collections.Generic;
using System.Transactions;
using UnityEngine;

public class CamaraController : MonoBehaviour
{
    public float velocidadMovimiento = 4f;
    public float velocidadCorrer = 5.2f; // Velocidad al correr
    public float sensibilidadMouse = 2f;
    public Transform camara; // Arrastra la cámara principal aquí en el Inspector
    public Animator anim; // Asigna el Animator del personaje en el Inspector

    private float rotacionX = 0f;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked; // Oculta y bloquea el cursor al centro de la pantalla
        if (anim == null)
        {
            anim = GetComponent<Animator>();
        }
    }

    void Update()
    {
        Movimiento();
        Rotacion();
    }

    void Movimiento()
    {
        float movimientoX = Input.GetAxis("Horizontal"); // A y D
        float movimientoZ = Input.GetAxis("Vertical");   // W y S

        bool corriendo = Input.GetKey(KeyCode.LeftShift) && movimientoZ > 0; // Corre solo si Shift está presionado y se mueve hacia adelante
        float velocidadActual = corriendo ? velocidadCorrer : velocidadMovimiento;

        // Aplicar animaciones correctas
        anim.SetBool("SlowRun", corriendo);
        anim.SetFloat("Walk", corriendo ? 0 : Mathf.Abs(movimientoZ));

        Vector3 mover = transform.right * movimientoX + transform.forward * movimientoZ;
        transform.position += mover * velocidadActual * Time.deltaTime;
    }

    void Rotacion()
    {
        float mouseX = Input.GetAxis("Mouse X") * sensibilidadMouse;
        float mouseY = Input.GetAxis("Mouse Y") * sensibilidadMouse;

        rotacionX -= mouseY;
        rotacionX = Mathf.Clamp(rotacionX, -66f, 80f); // Limita la rotación de la cámara

        camara.localRotation = Quaternion.Euler(rotacionX, 0f, 0f);
        transform.Rotate(Vector3.up * mouseX);
    }
}

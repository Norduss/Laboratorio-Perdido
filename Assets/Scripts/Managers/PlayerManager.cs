using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerManager : MonoBehaviour
{
    public int salud = 100;
    public GameObject GameOver;

    public void GetDamage(int dmg)
    {
        salud -= dmg;
        if (salud < 0)
        {
            salud = 0;
        }
        Die();
    }
   
    public void Die()
    {
        if (salud <= 0)
        {
            GameOver.SetActive(true);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (GameOver.activeSelf)
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
    }
}

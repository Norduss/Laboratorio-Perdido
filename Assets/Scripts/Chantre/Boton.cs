using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject prefabBola;
    public Transform[] puntosDeSpawn;
    public float retrasoLanzamiento = 2f; // Tiempo para esperar antes de lanzar

    public void LanzarBola()
    {
        StartCoroutine(EsperarYLanzar());
    }

    private IEnumerator EsperarYLanzar()
    {
        yield return new WaitForSeconds(retrasoLanzamiento);

        if (GameGoldberg.instancia.PuedeLanzar())
        {
            int indice = Random.Range(0, puntosDeSpawn.Length);
            Vector3 posicionElegida = puntosDeSpawn[indice].position;

            GameObject bola = Instantiate(prefabBola, posicionElegida, Quaternion.identity);
            GameGoldberg.instancia.RegistrarTirada();
            UIManager.instancia.MostrarBotonReintentar(false);
        }
    }
}





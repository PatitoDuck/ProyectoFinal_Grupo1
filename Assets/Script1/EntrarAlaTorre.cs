using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EntrarAlaTorre : MonoBehaviour
{
    [Header("Configuraci�n de transici�n")]
    public string sceneToLoad;            // Nombre de la escena a la que quieres ir
    public string spawnPointName;         // Nombre del punto donde el jugador aparecer� en esa escena

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // Guardamos el punto de entrada para la pr�xima escena
            SceneData.spawnPoint = spawnPointName;

            // Cargamos la nueva escena
            SceneManager.LoadScene(sceneToLoad);
        }
    }
}
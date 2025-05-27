using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Creditos : MonoBehaviour
{
    public float velocidad = 30f;  // Velocidad de movimiento hacia arriba
    public float limiteY = 1200f;  // Valor Y para considerar que los cr�ditos terminaron (ajusta seg�n tu UI)

    void Update()
    {
        // Mueve el objeto hacia arriba
        transform.Translate(Vector3.up * velocidad * Time.deltaTime);

        // Salir con ESC
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Debug.Log("Cr�ditos saltados por el jugador");

            SalirDeCreditos();
        }

        // Si ya pas� el l�mite superior de la pantalla
        if (transform.position.y >= limiteY)
        {
            Debug.Log("Se acabaron los creditos");

            SalirDeCreditos();
        }
    }

    void SalirDeCreditos()
    {
        Debug.Log("Cr�ditos terminados o salidos manualmente. Cargando men�...");
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;

        SceneManager.LoadScene("InicioEcenaFinal");
        
    }
}

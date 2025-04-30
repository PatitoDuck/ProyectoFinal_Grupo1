using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectibleBehaivior : MonoBehaviour
{

    //public string ColorPocion;
    public GameObject ParticulaRecolectado;
    // Start is called before the first frame update  
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            try
            {
                Instantiate(ParticulaRecolectado, other.transform.position, transform.rotation);
            }
            catch(System.Exception ex)
            {
                Debug.Log("error: " + ex.Message);
            }
        }

        
       /*     switch(ColorPocion.ToLower())
            {
                case "azul":
                    Debug.Log("Poci�n de defensa a�adida.");
                    Destroy(this.gameObject);
                    break;

                case "rojo":
                    Debug.Log("Poci�n de vida a�adida.");
                    Destroy(this.gameObject);
                    break;

                case "verde":
                    Debug.Log("Poci�n de ataque a�adida.");
                    Destroy(this.gameObject);
                    break;

                case "oro":
                    Debug.Log("Encontraste 1 pieza de oro.");
                    Destroy(this.gameObject);
                    break;
                case "cafe":
                    Debug.Log("Encontraste una bolsa con 50 de oro.");
                    Destroy(this.gameObject);
                    break;

            }

        }*/
    }



}

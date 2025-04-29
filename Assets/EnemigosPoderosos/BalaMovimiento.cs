using UnityEngine;

public class BalaMovimiento : MonoBehaviour
{
    public float velocidad = 40f; // Velocidad de la bala
    private Vector3 direccion;   // Direcci�n hacia el jugador
    public float tiempoDeVida = 5f; // Tiempo que la bala tarda en destruirse

    private ParticleSystem particulaBala; // Para referirse al sistema de part�culas

    void Start()
    {
        // Obtener la referencia al sistema de part�culas
        particulaBala = GetComponent<ParticleSystem>();
    }

    public void Inicializar(Vector3 objetivo)
    {
        direccion = (objetivo - transform.position).normalized; // Apunta hacia el jugador
        Invoke("DestruirBala", tiempoDeVida); // Llama a DestruirBala() despu�s de 3 segundos
    }

    void Update()
    {
        // Mueve la bala en la direcci�n deseada a la velocidad establecida
        transform.position += direccion * velocidad * Time.deltaTime;
    }

    private void DestruirBala()
    {
        // Detenemos las part�culas antes de destruir la bala
        if (particulaBala != null)
        {
            particulaBala.Stop(true, ParticleSystemStopBehavior.StopEmittingAndClear);
        }

        Destroy(gameObject, 0.5f); // Espera un poco para destruir la bala y dar tiempo a que las part�culas desaparezcan
    }

    private void OnTriggerEnter(Collider other)
    {
        // Aqu� puedes poner qu� pasa cuando la bala toca algo
        if (other.CompareTag("Player"))
        {
            // L�gica de da�o al jugador
            Destroy(gameObject); // Destruye la bala al impactar
        }
        else if (other.CompareTag("Pared") || other.CompareTag("Obstaculo"))
        {
            Destroy(gameObject); // Destruye si choca con otra cosa
        }
    }
}

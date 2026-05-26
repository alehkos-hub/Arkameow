using UnityEngine;

public class SecretLevelTrigger : MonoBehaviour
{
    [Tooltip("El GameObject que contiene todo el nivel secreto.")]
    public GameObject nivelSecreto;

    private void OnTriggerEnter(Collider other)
    {
        // Asegúrate de que el jugador tenga el tag "Player"
        if (other.CompareTag("Player"))
        {
            // Activar el nivel secreto
            if (nivelSecreto != null)
            {
                nivelSecreto.SetActive(true);
            }
            // Opcional: Desactivar este trigger para que no se ejecute dos veces
            gameObject.SetActive(false);
        }
    }
}
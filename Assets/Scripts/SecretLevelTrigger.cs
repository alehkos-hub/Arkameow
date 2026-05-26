using UnityEngine;

public class SecretLevelTrigger : MonoBehaviour
{
    [Tooltip("El GameObject que contiene todo el nivel secreto.")]
    public GameObject nivelSecreto;

    [Tooltip("Objeto opcional (como un muro) que se desactivará al entrar al secreto.")]
    public GameObject obstaculoASacar;

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

            // Desactivar el obstáculo/muro si existe
            if (obstaculoASacar != null)
            {
                obstaculoASacar.SetActive(false);
            }

            // Opcional: Desactivar este trigger para que no se ejecute dos veces
            gameObject.SetActive(false);
        }
    }
}
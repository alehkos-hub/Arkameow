using UnityEngine;

public class GestorBloques : MonoBehaviour
{
    [Tooltip("El GameObject que se activará cuando no queden bloques.")]
    public GameObject objetoAActivar;

    [Tooltip("Etiqueta (Tag) que tienen todos tus bloques.")]
    public string tagBloque = "Bloque";

    void Update()
    {
        // Busca todos los objetos con la etiqueta especificada
        GameObject[] bloquesRestantes = GameObject.FindGameObjectsWithTag(tagBloque);

        // Si no queda ninguno, activamos el GameObject
        if (bloquesRestantes.Length == 0)
        {
            if (objetoAActivar != null)
            {
                objetoAActivar.SetActive(true);
            }
        }
    }
}
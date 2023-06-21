using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// Este script controla el comportamiento de la pacasita.
/// </summary>
public class Pacasita : MonoBehaviour
{
    /// <summary>
    /// Se llama cuando otro collider entra en contacto con este collider.
    /// </summary>
    /// <param name="other">El collider con el que se produjo la colisión.</param>
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            // Al colisionar con el jugador, se devuelve al jugador a la escena de juego desde el principio
            SceneManager.LoadScene("Juego");
        }
    }
}
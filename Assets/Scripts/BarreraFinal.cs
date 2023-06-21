using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// Esta clase representa el final en el juego que carga una escena cuando el jugador colisiona con ella.
/// </summary>
public class BarreraFinal : MonoBehaviour
{
   
    /// </summary>
    /// <param name="other">El collider con el que se produjo la colisión.</param>
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            // Carga la escena especificada (cambia el número de escena según sea necesario)
            SceneManager.LoadScene(3);
        }
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// Este script gestiona el cambio de escenas en el juego
/// </summary>
public class MainMenu : MonoBehaviour
{
    public bool pasarNivel;  // Indica si se debe pasar al siguiente nivel
    public int indiceNivel;  // Índice del nivel al que se debe cambiar

    // Update is called once per frame
    void Update()
    {
        if (pasarNivel)
        {
            CambiarNivel(indiceNivel);
        }
    }

    /// <summary>
    /// Cambia al nivel especificado.
    /// </summary>
    /// <param name="indice">El índice del nivel al que se debe cambiar.</param>
    public void CambiarNivel(int indice)
    {
        SceneManager.LoadScene(indice);
    }

    /// <summary>
    /// Sale de la aplicación.
    /// </summary>
    public void Salir()
    {
        Application.Quit();
    }
}
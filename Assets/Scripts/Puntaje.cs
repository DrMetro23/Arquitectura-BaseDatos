using UnityEngine;
using TMPro;
using System.Collections.Generic;

public class Puntaje : MonoBehaviour
{
    public float puntos; // Puntuaci�n actual
    public TextMeshProUGUI textMesh; // Referencia al componente TextMeshProUGUI para mostrar la puntuaci�n
    private float puntuacionMaxima; // Puntuaci�n m�xima

    // Diccionario para almacenar los objetos Flyweight de puntuaci�n m�xima
    private Dictionary<string, TextMeshProUGUI> flyweightDict;

    private void Start()
    {
        textMesh = GetComponent<TextMeshProUGUI>(); // Obtiene el componente TextMeshProUGUI del objeto
        puntuacionMaxima = PlayerPrefs.GetFloat("PuntuacionMaxima", 0f); // Obtiene la puntuaci�n m�xima guardada en PlayerPrefs (o 0 si no existe)
        flyweightDict = new Dictionary<string, TextMeshProUGUI>();
        ActualizarTexto(); // Actualiza el texto con la puntuaci�n actual y la puntuaci�n m�xima
    }

    private void Update()
    {
        // Actualiza el texto mostrando la puntuaci�n actual y la puntuaci�n m�xima
        textMesh.text = "Puntuaci�n: " + puntos.ToString("0") + "\n" +
                        "Puntuaci�n m�xima: " + puntuacionMaxima.ToString("0");
    }

    /// <summary>
    /// Suma puntos a la puntuaci�n actual y actualiza la puntuaci�n m�xima si es necesario.
    /// </summary>
    /// <param name="puntosEntrada">La cantidad de puntos a sumar.</param>
    public void SumarPuntos(float puntosEntrada)
    {
        puntos += puntosEntrada;

        if (puntos > puntuacionMaxima)
        {
            puntuacionMaxima = puntos;
            PlayerPrefs.SetFloat("PuntuacionMaxima", puntuacionMaxima); // Guarda la nueva puntuaci�n m�xima en PlayerPrefs
            PlayerPrefs.Save(); // Guarda los cambios en PlayerPrefs
        }
    }

    private void ActualizarTexto()
    {
        // Verifica si ya existe un objeto Flyweight para la puntuaci�n m�xima actual
        if (flyweightDict.TryGetValue(puntuacionMaxima.ToString(), out TextMeshProUGUI flyweightText))
        {
            textMesh.text = "Puntuaci�n: " + puntos.ToString("0") + "\n" +
                            "Puntuaci�n m�xima: ";
            textMesh.text += flyweightText.text; // Agrega el texto del objeto Flyweight
        }
        else
        {
            // Crea un nuevo objeto Flyweight para la puntuaci�n m�xima
            GameObject flyweightGO = new GameObject("Flyweight" + puntuacionMaxima);
            flyweightText = flyweightGO.AddComponent<TextMeshProUGUI>(); // A�ade el componente TextMeshProUGUI
            flyweightText.font = textMesh.font; // Asigna la misma fuente que el componente TextMeshProUGUI principal
            flyweightText.fontSize = textMesh.fontSize; // Asigna el mismo tama�o de fuente que el componente TextMeshProUGUI principal
            flyweightText.color = textMesh.color; // Asigna el mismo color de texto que el componente TextMeshProUGUI principal
            flyweightText.alignment = textMesh.alignment; // Asigna la misma alineaci�n de texto que el componente TextMeshProUGUI principal
            flyweightText.transform.SetParent(textMesh.transform.parent); // Establece el padre del objeto Flyweight
            flyweightText.text = puntuacionMaxima.ToString("0"); // Asigna la puntuaci�n m�xima al texto del objeto Flyweight
            flyweightDict.Add(puntuacionMaxima.ToString(), flyweightText); // Agrega el objeto Flyweight al diccionario
            ActualizarTexto(); // Actualiza el texto
        }
    }
}

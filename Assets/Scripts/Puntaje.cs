using UnityEngine;
using TMPro;
using System.Collections.Generic;

public class Puntaje : MonoBehaviour
{
    public float puntos; // Puntuación actual
    public TextMeshProUGUI textMesh; // Referencia al componente TextMeshProUGUI para mostrar la puntuación
    private float puntuacionMaxima; // Puntuación máxima

    // Diccionario para almacenar los objetos Flyweight de puntuación máxima
    private Dictionary<string, TextMeshProUGUI> flyweightDict;

    private void Start()
    {
        textMesh = GetComponent<TextMeshProUGUI>(); // Obtiene el componente TextMeshProUGUI del objeto
        puntuacionMaxima = PlayerPrefs.GetFloat("PuntuacionMaxima", 0f); // Obtiene la puntuación máxima guardada en PlayerPrefs (o 0 si no existe)
        flyweightDict = new Dictionary<string, TextMeshProUGUI>();
        ActualizarTexto(); // Actualiza el texto con la puntuación actual y la puntuación máxima
    }

    private void Update()
    {
        // Actualiza el texto mostrando la puntuación actual y la puntuación máxima
        textMesh.text = "Puntuación: " + puntos.ToString("0") + "\n" +
                        "Puntuación máxima: " + puntuacionMaxima.ToString("0");
    }

    /// <summary>
    /// Suma puntos a la puntuación actual y actualiza la puntuación máxima si es necesario.
    /// </summary>
    /// <param name="puntosEntrada">La cantidad de puntos a sumar.</param>
    public void SumarPuntos(float puntosEntrada)
    {
        puntos += puntosEntrada;

        if (puntos > puntuacionMaxima)
        {
            puntuacionMaxima = puntos;
            PlayerPrefs.SetFloat("PuntuacionMaxima", puntuacionMaxima); // Guarda la nueva puntuación máxima en PlayerPrefs
            PlayerPrefs.Save(); // Guarda los cambios en PlayerPrefs
        }
    }

    private void ActualizarTexto()
    {
        // Verifica si ya existe un objeto Flyweight para la puntuación máxima actual
        if (flyweightDict.TryGetValue(puntuacionMaxima.ToString(), out TextMeshProUGUI flyweightText))
        {
            textMesh.text = "Puntuación: " + puntos.ToString("0") + "\n" +
                            "Puntuación máxima: ";
            textMesh.text += flyweightText.text; // Agrega el texto del objeto Flyweight
        }
        else
        {
            // Crea un nuevo objeto Flyweight para la puntuación máxima
            GameObject flyweightGO = new GameObject("Flyweight" + puntuacionMaxima);
            flyweightText = flyweightGO.AddComponent<TextMeshProUGUI>(); // Añade el componente TextMeshProUGUI
            flyweightText.font = textMesh.font; // Asigna la misma fuente que el componente TextMeshProUGUI principal
            flyweightText.fontSize = textMesh.fontSize; // Asigna el mismo tamaño de fuente que el componente TextMeshProUGUI principal
            flyweightText.color = textMesh.color; // Asigna el mismo color de texto que el componente TextMeshProUGUI principal
            flyweightText.alignment = textMesh.alignment; // Asigna la misma alineación de texto que el componente TextMeshProUGUI principal
            flyweightText.transform.SetParent(textMesh.transform.parent); // Establece el padre del objeto Flyweight
            flyweightText.text = puntuacionMaxima.ToString("0"); // Asigna la puntuación máxima al texto del objeto Flyweight
            flyweightDict.Add(puntuacionMaxima.ToString(), flyweightText); // Agrega el objeto Flyweight al diccionario
            ActualizarTexto(); // Actualiza el texto
        }
    }
}

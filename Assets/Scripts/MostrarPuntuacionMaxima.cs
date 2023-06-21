using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MostrarPuntuacionMaxima : MonoBehaviour
{
    public TextMeshProUGUI textoPuntuacionMaxima; // Referencia al componente TextMeshProUGUI para mostrar la puntuación máxima
    private int puntuacionMaxima; // Variable que almacena la puntuación máxima

    private Dictionary<string, TextMeshProUGUI> flyweightDict;

    void Start()
    {
        puntuacionMaxima = PlayerPrefs.GetInt("PuntuacionMaxima", 0); // Obtiene la puntuación máxima guardada en PlayerPrefs (o 0 si no existe)
        flyweightDict = new Dictionary<string, TextMeshProUGUI>();
        CrearTextoPuntuacionMaxima(); // Crea el objeto de texto para mostrar la puntuación máxima
    }

    void CrearTextoPuntuacionMaxima()
    {
        // Verifica si ya existe un objeto Flyweight para la puntuación máxima actual
        if (flyweightDict.TryGetValue(puntuacionMaxima.ToString(), out TextMeshProUGUI flyweightText))
        {
            textoPuntuacionMaxima.text = "Mejor puntuación: ";
            textoPuntuacionMaxima.text += flyweightText.text; // Agrega el texto del objeto Flyweight
        }
        else
        {
            // Crea un nuevo objeto Flyweight para la puntuación máxima
            GameObject flyweightGO = new GameObject("Flyweight" + puntuacionMaxima);
            flyweightText = flyweightGO.AddComponent<TextMeshProUGUI>(); // Añade el componente TextMeshProUGUI
            flyweightText.font = textoPuntuacionMaxima.font; // Asigna la misma fuente que el componente TextMeshProUGUI principal
            flyweightText.fontSize = textoPuntuacionMaxima.fontSize; // Asigna el mismo tamaño de fuente que el componente TextMeshProUGUI principal
            flyweightText.color = textoPuntuacionMaxima.color; // Asigna el mismo color de texto que el componente TextMeshProUGUI principal
            flyweightText.alignment = textoPuntuacionMaxima.alignment; // Asigna la misma alineación de texto que el componente TextMeshProUGUI principal
            flyweightText.transform.SetParent(textoPuntuacionMaxima.transform.parent); // Establece el padre del objeto Flyweight
            flyweightText.text = puntuacionMaxima.ToString(); // Asigna la puntuación máxima al texto del objeto Flyweight
            flyweightDict.Add(puntuacionMaxima.ToString(), flyweightText); // Agrega el objeto Flyweight al diccionario
            textoPuntuacionMaxima.text = "Mejor puntuación: ";
            textoPuntuacionMaxima.text += flyweightText.text; // Agrega el texto del objeto Flyweight
        }
    }
}
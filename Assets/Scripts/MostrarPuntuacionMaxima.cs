using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MostrarPuntuacionMaxima : MonoBehaviour
{
    public TextMeshProUGUI textoPuntuacionMaxima; // Referencia al componente TextMeshProUGUI para mostrar la puntuaci�n m�xima
    private int puntuacionMaxima; // Variable que almacena la puntuaci�n m�xima

    private Dictionary<string, TextMeshProUGUI> flyweightDict;

    void Start()
    {
        puntuacionMaxima = PlayerPrefs.GetInt("PuntuacionMaxima", 0); // Obtiene la puntuaci�n m�xima guardada en PlayerPrefs (o 0 si no existe)
        flyweightDict = new Dictionary<string, TextMeshProUGUI>();
        CrearTextoPuntuacionMaxima(); // Crea el objeto de texto para mostrar la puntuaci�n m�xima
    }

    void CrearTextoPuntuacionMaxima()
    {
        // Verifica si ya existe un objeto Flyweight para la puntuaci�n m�xima actual
        if (flyweightDict.TryGetValue(puntuacionMaxima.ToString(), out TextMeshProUGUI flyweightText))
        {
            textoPuntuacionMaxima.text = "Mejor puntuaci�n: ";
            textoPuntuacionMaxima.text += flyweightText.text; // Agrega el texto del objeto Flyweight
        }
        else
        {
            // Crea un nuevo objeto Flyweight para la puntuaci�n m�xima
            GameObject flyweightGO = new GameObject("Flyweight" + puntuacionMaxima);
            flyweightText = flyweightGO.AddComponent<TextMeshProUGUI>(); // A�ade el componente TextMeshProUGUI
            flyweightText.font = textoPuntuacionMaxima.font; // Asigna la misma fuente que el componente TextMeshProUGUI principal
            flyweightText.fontSize = textoPuntuacionMaxima.fontSize; // Asigna el mismo tama�o de fuente que el componente TextMeshProUGUI principal
            flyweightText.color = textoPuntuacionMaxima.color; // Asigna el mismo color de texto que el componente TextMeshProUGUI principal
            flyweightText.alignment = textoPuntuacionMaxima.alignment; // Asigna la misma alineaci�n de texto que el componente TextMeshProUGUI principal
            flyweightText.transform.SetParent(textoPuntuacionMaxima.transform.parent); // Establece el padre del objeto Flyweight
            flyweightText.text = puntuacionMaxima.ToString(); // Asigna la puntuaci�n m�xima al texto del objeto Flyweight
            flyweightDict.Add(puntuacionMaxima.ToString(), flyweightText); // Agrega el objeto Flyweight al diccionario
            textoPuntuacionMaxima.text = "Mejor puntuaci�n: ";
            textoPuntuacionMaxima.text += flyweightText.text; // Agrega el texto del objeto Flyweight
        }
    }
}
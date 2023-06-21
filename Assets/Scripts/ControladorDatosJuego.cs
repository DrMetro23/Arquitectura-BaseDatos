using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

/// <summary>
/// Este script maneja los datos del juego, incluyendo la carga y guardado de la posición del jugador.
/// </summary>
public class ControladorDatosJuego : MonoBehaviour
{
    // Referencia al jugador
    /// <summary>
    /// Referencia al objeto del jugador en el juego.
    /// </summary>
    public GameObject jugador;

    /// <summary>
    /// Ruta del archivo de guardado de datos.
    /// </summary>
    public string archivoDeGuardado;

    /// <summary>
    /// Datos del juego que se guardarán y cargarán.
    /// </summary>
    public DatosJuego datosJuego = new DatosJuego();

    private Vector3 posicionRelativa;

    private void Start()
    {
        posicionRelativa = transform.position - jugador.transform.position;
    }

    private void Awake()
    {
        archivoDeGuardado = Application.dataPath + "/datosJuego.json";

        jugador = GameObject.FindGameObjectWithTag("Player");

        // Con esto hacemos que el juego empiece por donde lo dejamos la ultima vez
        CargarDatos();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            CargarDatos();
        }
        if (Input.GetKeyDown(KeyCode.G))
        {
            GuardarDatos();
        }
    }

    private void CargarDatos()
    {
        if (File.Exists(archivoDeGuardado))
        {
            string contenido = File.ReadAllText(archivoDeGuardado);
            datosJuego = JsonUtility.FromJson<DatosJuego>(contenido);

            Debug.Log("Posicion Jugador : " + datosJuego.posicion);

            jugador.transform.position = datosJuego.posicion;
        }
        else
        {
            Debug.Log("El archivo no existe");
        }
    }

    private void GuardarDatos()
    {
        DatosJuego nuevosDatos = new DatosJuego()
        {
            posicion = jugador.transform.position
        };

        string cadenaJSON = JsonUtility.ToJson(nuevosDatos);

        File.WriteAllText(archivoDeGuardado, cadenaJSON);

        Debug.Log("Archivo Guardado");
    }

    private void LateUpdate()
    {
        transform.position = jugador.transform.position + posicionRelativa;
    }
}
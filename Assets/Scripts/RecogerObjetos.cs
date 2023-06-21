using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Este script se utiliza para recoger objetos en el juego y sumar puntos 
/// </summary>
public class RecogerObjetos : MonoBehaviour
{
    [SerializeField] private float cantidadPuntos;  // Cantidad de puntos que se sumarán al recoger el objeto

    [SerializeField] private Puntaje puntaje;  // Referencia al script de Puntaje para sumar los puntos

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            puntaje.SumarPuntos(cantidadPuntos);  // Suma los puntos al puntaje del jugador utilizando el script de Puntaje
            Destroy(gameObject);  // Destruye el objeto recolectado
        }
    }
}









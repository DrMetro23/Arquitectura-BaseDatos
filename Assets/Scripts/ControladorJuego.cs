using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

/// <summary>
/// Comando para activar el temporizador.
/// </summary>
public class ActivarTemporizadorCommand
{
    private ControladorJuego controladorJuego;

    public ActivarTemporizadorCommand(ControladorJuego controladorJuego)
    {
        this.controladorJuego = controladorJuego;
    }

    public void Execute()
    {
        controladorJuego.ActivarTemporizador();
    }
}

/// <summary>
/// Comando para desactivar el temporizador.
/// </summary>
public class DesactivarTemporizadorCommand
{
    private ControladorJuego controladorJuego;

    public DesactivarTemporizadorCommand(ControladorJuego controladorJuego)
    {
        this.controladorJuego = controladorJuego;
    }

    public void Execute()
    {
        controladorJuego.DesactivarTemporizador();
    }
}

/// <summary>
/// Este script controla el juego, incluyendo el temporizador y la transición de escenas.
/// </summary>
public class ControladorJuego : MonoBehaviour
{
    [SerializeField] private float tiempoMaximo;  // El tiempo máximo permitido
    [SerializeField] private Slider slider;  // Referencia al componente Slider para mostrar el tiempo restante

    private float tiempoActual;  // El tiempo actual que va disminuyendo

    private bool tiempoActivado = false;  // Indica si el temporizador está activado

    private ActivarTemporizadorCommand activarTemporizadorCommand;
    private DesactivarTemporizadorCommand desactivarTemporizadorCommand;

    private void Start()
    {
        activarTemporizadorCommand = new ActivarTemporizadorCommand(this);
        desactivarTemporizadorCommand = new DesactivarTemporizadorCommand(this);

        ActivarTemporizador();  // Inicia el temporizador
    }

    private void Update()
    {
        if (tiempoActivado)
        {
            CambiarContador();  // Actualiza el contador de tiempo
        }
    }

    /// <summary>
    /// Cambia el contador de tiempo y verifica si se ha agotado.
    /// </summary>
    private void CambiarContador()
    {
        tiempoActual -= Time.deltaTime;

        if (tiempoActual >= 0)
        {
            slider.value = tiempoActual;  // Actualiza el valor del Slider para reflejar el tiempo restante
        }

        if (tiempoActual <= 0)
        {
            Debug.Log("Fin de la partida");
            desactivarTemporizadorCommand.Execute();  // Desactiva el temporizador utilizando el comando
            SceneManager.LoadScene("Final");  // Carga la escena "Final"
        }
    }

    /// <summary>
    /// Activa el temporizador y establece los valores iniciales.
    /// </summary>
    public void ActivarTemporizador()
    {
        tiempoActual = tiempoMaximo;  // Establece el tiempo actual al máximo
        slider.maxValue = tiempoMaximo;  // Establece el valor máximo del Slider al tiempo máximo
        tiempoActivado = true;  // Activa el temporizador
    }

    /// <summary>
    /// Desactiva el temporizador.
    /// </summary>
    public void DesactivarTemporizador()
    {
        tiempoActivado = false;  // Desactiva el temporizador
    }
}
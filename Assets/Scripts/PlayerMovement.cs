using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Controla el movimiento y comportamiento del jugador.
/// Implementa el patrón Singleton para asegurar que solo haya una instancia de PlayerMovement en el juego.
/// </summary>
public class PlayerMovement : MonoBehaviour
{
    public float speed = 5f; // Velocidad de movimiento del jugador
    public float jumpForce = 5f; // Fuerza del salto

    private Rigidbody2D rb;
    private Transform playerTransform; // Referencia al Transform del jugador
    private bool isJumping = false; // Bandera para verificar si el jugador está saltando

    public int health = 1; // Puntos de vida del enemigo

    private static PlayerMovement instancia; // Variable estática privada para almacenar la única instancia de la clase

    // Propiedad estática para acceder a la instancia del Singleton
    public static PlayerMovement Instance
    {
        get
        {
            if (instancia == null)
            {
                instancia = FindObjectOfType<PlayerMovement>();
                if (instancia == null)
                {
                    Debug.LogError("No se encontró ninguna instancia de PlayerMovement en la escena.");
                }
            }
            return instancia;
        }
    }

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        playerTransform = transform;
    }

    private void Update()
    {
        // Movimiento horizontal
        float moveHorizontal = Input.GetAxis("Horizontal");
        Vector2 movement = new Vector2(moveHorizontal * speed, rb.velocity.y);
        rb.velocity = movement;

        // Salto
        if (Input.GetButtonDown("Jump") && !isJumping)
        {
            rb.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);
            isJumping = true;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Verificar si el jugador ha aterrizado en el suelo
        if (collision.gameObject.CompareTag("Ground"))
        {
            isJumping = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Verifica si la colisión es con una bala
        if (collision.CompareTag("Enemy"))
        {
            // Reduce la salud del enemigo para eliminarlo
            health--;

            // Destruye la bala(si la hubiera)
            Destroy(collision.gameObject);

            // Verifica si el enemigo ha perdido toda su salud
            if (health <= 0)
            {
                // Elimina el enemigo
                Destroy(gameObject);
            }
        }
    }
}
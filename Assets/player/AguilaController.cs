
using UnityEngine;
using TMPro;
using UnityEngine.InputSystem;

public class AguilaController : MonoBehaviour
{
    public float velocidad = 5f;
    [SerializeField] private int puntosGema = 10;
    [SerializeField] private int puntosCereza = -5;
    [SerializeField] private TMP_Text textoPuntaje;

    private int puntaje = 0;
    private Rigidbody2D rb;
    private Vector2 direccion;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        ActualizarTextoPuntaje();
    }

    void Update()
    {
        if (Keyboard.current == null) return;

        float x = 0f;
        float y = 0f;

        // Movimiento con WASD
        if (Keyboard.current.wKey.isPressed) y = 1f;
        if (Keyboard.current.sKey.isPressed) y = -1f;
        if (Keyboard.current.aKey.isPressed) x = -1f;
        if (Keyboard.current.dKey.isPressed) x = 1f;

        direccion = new Vector2(x, y).normalized;
    }

    void FixedUpdate()
    {
        rb.linearVelocity = direccion * velocidad;
    }

    void OnTriggerEnter2D(Collider2D otro)
    {
        if (otro.CompareTag("Gema"))
        {
            CambiarPuntaje(puntosGema);
            Destroy(otro.gameObject);
        }
        else if (otro.CompareTag("Cereza"))
        {
            CambiarPuntaje(puntosCereza);
            Destroy(otro.gameObject);
        }
    }

    void CambiarPuntaje(int cantidad)
    {
        puntaje += cantidad;
        Debug.Log("Puntaje: " + puntaje);
        ActualizarTextoPuntaje();
    }

    void ActualizarTextoPuntaje()
    {
        if (textoPuntaje != null)
        {
            textoPuntaje.text = "Tu puntaje: " + puntaje;
        }
    }
}

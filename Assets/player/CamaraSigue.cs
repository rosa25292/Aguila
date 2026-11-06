using UnityEngine;

public class CamaraSigue : MonoBehaviour
{
    [SerializeField] private Transform objetivo;   // el águila (arrástrala en el Inspector)
    [SerializeField] private float suavizado = 5f; // float: qué tan suave sigue la cámara

    // LateUpdate se ejecuta después de que el águila ya se movió (evita temblores)
    void LateUpdate()
    {
        if (objetivo == null) return;

        // Mantiene la Z de la cámara (-10) y solo copia X e Y del águila
        Vector3 destino = new Vector3(objetivo.position.x, objetivo.position.y, transform.position.z);
        transform.position = Vector3.Lerp(transform.position, destino, suavizado * Time.deltaTime);
    }
}
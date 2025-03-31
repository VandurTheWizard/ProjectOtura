using UnityEngine;

public class MovimientoCamara : MonoBehaviour
{
    [Header("Configuración de la cámara")]
    public Transform target;
    public float velocidad;

    public void Update()
    {
        Vector3 nuevaPosicion = new Vector3(target.position.x, target.position.y, target.position.z);
        transform.position = Vector3.Lerp(transform.position, nuevaPosicion, velocidad * Time.deltaTime);
    }
}
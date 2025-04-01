using UnityEngine;

public class MovimientoCamara : MonoBehaviour
{
    [Header("Configuración de la cámara")]
    public float velocidadMin = 1;
    public float velocidadMax = 5;
    public float aceleracion = 0.5f;
    public Transform caminoInicio;
    public Transform caminoOpciones;

    private Transform target;

    private float velocidad;

    void Start()
    {
        velocidad = velocidadMin;
        CamaraInicio();   
    }


    public void Update()
    {
        if(velocidad < velocidadMax){
            velocidad += aceleracion * Time.deltaTime;
        }

        Vector3 nuevaPosicion = new Vector3(target.position.x, target.position.y, target.position.z);
        transform.position = Vector3.Lerp(transform.position, nuevaPosicion, velocidad * Time.deltaTime);
        
        Quaternion nuevaRotacion = target.rotation;
        transform.rotation = Quaternion.Lerp(transform.rotation, nuevaRotacion, velocidad * Time.deltaTime);
    }

    public void Camaraopciones(){
        target = caminoOpciones;
    }

    public void CamaraInicio(){
        target = caminoInicio;
    }
}
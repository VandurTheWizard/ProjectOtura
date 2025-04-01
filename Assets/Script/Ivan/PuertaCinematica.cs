using UnityEngine;

public class PuertaCinematica : MonoBehaviour
{
    [Header("Configuración de las puertas")]
    public float rotatioDoor1;
    public float rotatioDoor2;
    public float velocidadMin = 0.1f;
    public float velocidadMax = 1;
    public float aceleracion = 0.2f;
    public GameObject door1;
    public GameObject door2;

    private float x1;
    private float y1;
    private float x2;
    private float y2;

    private float velocidad;



    void Start()
    {
        velocidad = velocidadMin;
        x1 = door1.transform.eulerAngles.x;
        y1 = door1.transform.eulerAngles.y;
        x2 = door2.transform.eulerAngles.x;
        y2 = door2.transform.eulerAngles.y;
    }

    // Update is called once per frame
    void Update()
    {
        if (velocidad < velocidadMax)
        {
            velocidad += aceleracion * Time.deltaTime;
        }
        Quaternion door1Rotation = Quaternion.Euler(x1, y1, rotatioDoor1);
        Quaternion door2Rotation = Quaternion.Euler(x2, y2, rotatioDoor2);

        door1.transform.rotation = Quaternion.Lerp(door1.transform.rotation, door1Rotation, velocidad * Time.deltaTime);
        door2.transform.rotation = Quaternion.Lerp(door2.transform.rotation, door2Rotation, velocidad * Time.deltaTime);
        
    }
}

using UnityEngine;

public class PuertaCinematica : MonoBehaviour
{
    [Header("Configuración de las puertas")]
    public float rotatioDoor1;
    public float rotatioDoor2;
    public float velocidad = 1;
    public GameObject door1;
    public GameObject door2;

    private float x1;
    private float y1;
    private float x2;
    private float y2;



    void Start()
    {
        x1 = door1.transform.rotation.x;
        y1 = door1.transform.rotation.y;
        x2 = door2.transform.rotation.x;
        y2 = door2.transform.rotation.y;
    }

    // Update is called once per frame
    void Update()
    {
        Quaternion door1Rotation = Quaternion.Euler(x1, y1, rotatioDoor1);
        Quaternion door2Rotation = Quaternion.Euler(x2, y2, rotatioDoor2);

        door1.transform.rotation = Quaternion.Lerp(door1.transform.rotation, door1Rotation, velocidad * Time.deltaTime);
        door2.transform.rotation = Quaternion.Lerp(door2.transform.rotation, door2Rotation, velocidad * Time.deltaTime);
        
    }
}

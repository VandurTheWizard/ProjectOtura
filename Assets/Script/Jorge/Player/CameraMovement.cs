using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public int sensitivity = 200;

    private float xRotation = 15f;
    private float yRotation = 0f;
    
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {

        float mouseX = Input.GetAxis("Mouse X") * sensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * sensitivity * Time.deltaTime;


        xRotation -= mouseY;
        yRotation += mouseX;
        xRotation = Mathf.Clamp(xRotation, -30f, 30f);

        transform.rotation = Quaternion.Euler(xRotation, yRotation, 0f);

    }

}
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public int sensitivity = 200;

    public Camera mainCamera;

    private float xRotation = 20f;
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
        xRotation = Mathf.Clamp(xRotation, 0f, 30f);

        transform.rotation = Quaternion.Euler(0f, yRotation, 0f);
        mainCamera.transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);

    }

}
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public int velocity;
    // Update is called once per frame
    void Update()
    {
        Vector3 forward = transform.forward;
        Vector3 right = transform.right;

        forward.y = 0;
        right.y = 0;

        forward.Normalize();
        right.Normalize();

        transform.Translate(Input.GetAxis("Vertical") * velocity * Time.deltaTime  * forward, Space.World);
        transform.Translate(Input.GetAxis("Horizontal") * velocity * Time.deltaTime * right, Space.World);
    }
}

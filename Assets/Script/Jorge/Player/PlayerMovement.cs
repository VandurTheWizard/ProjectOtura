using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public int velocity;
    // Update is called once per frame
    void Update()
    {
        transform.Translate(Input.GetAxis("Vertical") * velocity * Time.deltaTime  * Vector3.forward);
        transform.Translate(Input.GetAxis("Horizontal") * velocity * Time.deltaTime * Vector3.right);
    }
}

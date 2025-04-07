using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class DyingScript : MonoBehaviour
{
    public string sceneLose;
    public void onDying()
    {
        Cursor.lockState = CursorLockMode.None;
        SceneManager.LoadScene(sceneLose);
    }
}

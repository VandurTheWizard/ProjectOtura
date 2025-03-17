using UnityEngine;
using UnityEngine.SceneManagement;

public class DyingScript : MonoBehaviour
{
    public string sceneLose;
    public void onDying()
    {
        SceneManager.LoadScene(sceneLose);
    }
}

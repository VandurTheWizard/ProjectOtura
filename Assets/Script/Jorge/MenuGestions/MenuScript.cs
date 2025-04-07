using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuScript : MonoBehaviour
{
   public void MoveOnScene(string scene)
    {
        SceneManager.LoadScene(scene);
    }


    public void ExitOnGame()
    {
        Application.Quit();
    }
}

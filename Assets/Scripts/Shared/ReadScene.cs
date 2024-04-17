using UnityEngine;
using UnityEngine.SceneManagement;

public class ReadScene : MonoBehaviour
{
    public void LoadScene(string scene)
    {
        SceneManager.LoadScene(scene);
    }
}

using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class MainLogic : MonoBehaviour
{
    public void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
}

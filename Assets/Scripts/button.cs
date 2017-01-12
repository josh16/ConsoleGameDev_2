using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class button : MonoBehaviour
{
    public void ChangeScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }


}

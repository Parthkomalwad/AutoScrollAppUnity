using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public void LoadNextScene()
    {
        SceneManager.LoadScene(1);
    }
    public void LoadFirstScene()
    {
        SceneManager.LoadScene(0);
    }
}

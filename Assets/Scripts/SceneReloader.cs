using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneReloader : MonoBehaviour
{
    public static SceneReloader instance;

    private void Awake()
    {
        instance = this;
    }
    public void ReloadScene()
    {
        SceneManager.LoadScene("SampleScene");
    }
}

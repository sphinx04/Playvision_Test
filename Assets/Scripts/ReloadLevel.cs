﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ReloadLevel : MonoBehaviour
{
    // Start is called before the first frame update
    private void OnCollisionEnter(Collision collision)
    {
        print("HELLO");
        if (collision.gameObject.CompareTag("Player"))
        {
            SceneReloader.instance.ReloadScene();
        }
    }
}

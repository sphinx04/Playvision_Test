using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
    public Transform Player;

    void LateUpdate()
    {
        transform.position = Player.position;
    }
}

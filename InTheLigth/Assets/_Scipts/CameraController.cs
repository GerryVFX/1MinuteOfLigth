using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] Transform targetPlayer;

    void Update()
    {
        transform.position = new Vector3(targetPlayer.position.x, targetPlayer.position.y + 1.5f, targetPlayer.position.z-1);
        transform.LookAt(targetPlayer);
    }
}

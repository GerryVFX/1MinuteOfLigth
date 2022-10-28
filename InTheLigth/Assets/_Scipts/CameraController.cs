using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] Transform targetPlayer;

    void Update()
    {
        transform.position = new Vector3(targetPlayer.position.x, targetPlayer.position.y + 8, targetPlayer.position.z-3);
        transform.LookAt(targetPlayer);
    }
}

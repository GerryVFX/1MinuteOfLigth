using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
    GameManager _gameManager;
    Lamp _lamp;

    void Start()
    {
        _gameManager = FindObjectOfType<GameManager>();
        _lamp = FindObjectOfType<Lamp>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Pilar") && _gameManager.haveLamp == false)
        {
            _gameManager.inDanger = false;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Pilar") && _gameManager.haveLamp == false)
        {
            _gameManager.inDanger = false;
        }
    }
}

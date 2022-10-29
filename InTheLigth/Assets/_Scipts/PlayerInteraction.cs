using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
    GameManager _gameManager;

    void Start()
    {
        _gameManager = FindObjectOfType<GameManager>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("SafeZone"))
        {
            if(_gameManager.haveLamp == false)
            _gameManager.inDanger = false;
        }
    }


    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("SafeZone"))
        {
            if (_gameManager.timeLigth > 0)
                _gameManager.inDanger = false;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("SafeZone"))
        {
            if (_gameManager.haveLamp == false || _gameManager.timeLigth < 60) 
            _gameManager.inDanger = true;
        }
    }
}

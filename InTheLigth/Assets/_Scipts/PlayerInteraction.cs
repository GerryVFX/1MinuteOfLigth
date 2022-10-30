using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
    GameManager _gameManager;

    void Start()
    {
        _gameManager = FindObjectOfType<GameManager>();
        if (InfoPartida.saveExist) Load();

    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("SafeZone"))
        {
            if(_gameManager.haveLamp == false || _gameManager.timeLigth > 0)
            {
                _gameManager.safe = true;
            }
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("SafeZone"))
        {
            if (_gameManager.timeLigth > 0)
            {
                _gameManager.safe = true;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("SafeZone"))
        {
            _gameManager.safe = false;
        }
    }

    public void Save()
    {
        InfoPartida.saveExist = true;
        InfoPartida.player.position = transform.position;
    }

    public void Load()
    {
        transform.position = InfoPartida.player.position;
    }
}

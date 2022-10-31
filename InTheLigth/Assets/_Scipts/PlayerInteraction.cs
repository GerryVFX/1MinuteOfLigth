using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
    GameManager _gameManager;
    public bool canSave;
    private void Awake()
    {
        if (InfoPartida.saveExist) Load();
    }

    void Start()
    {
        _gameManager = FindObjectOfType<GameManager>();
        
    }

    private void Update()
    {
        if (canSave)
        {
            if (Input.GetButtonDown("Jump")) Save();
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("SafeZone"))
        {
            if(_gameManager.haveLamp == false || _gameManager.timeLigth > 0)
            {
                _gameManager.safe = true;
                _gameManager.canSave = true;
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
            _gameManager.canSave = false;
            Save();
        }
    }

    public void Save()
    {
        InfoPartida.saveExist = true;
        InfoPartida.player.playerPosition = transform.position;
        Debug.Log("saveOK");

    }

    public void Load()
    {
        transform.position = InfoPartida.player.playerPosition;
        //_gameManager.haveLamp = false;
    }
}

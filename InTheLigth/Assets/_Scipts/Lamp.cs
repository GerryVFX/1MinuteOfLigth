using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lamp : MonoBehaviour
{
    GameManager _gameManager;
    [SerializeField] GameObject playerPoint;
    [SerializeField] GameObject player;
    [SerializeField] GameObject pilar;
    [SerializeField] Light lifeLigth;

    
    
    public bool onPilar, canTake, canPut;

    public Vector3 savePosLamp;
    public Vector3 savePosPlayer;

    private void Start()
    {
        _gameManager = FindObjectOfType<GameManager>();
        player = GameObject.FindGameObjectWithTag("Player");
        _gameManager.haveLamp = false;
        if (InfoPartida.saveExist) Load();
    }


    private void Update()
    {
        lifeLigth.range = _gameManager.timeLigth / 10;
        lifeLigth.intensity = _gameManager.timeLigth / 10;

        if (_gameManager.timeLigth > 60) _gameManager.timeLigth = 60;
        if (_gameManager.timeLigth < 0) _gameManager.timeLigth = 0;

        if (!onPilar && _gameManager.timeLigth > 0) _gameManager.timeLigth -= Time.deltaTime;



        PickUpLigth();
        ChargeLigth();

    }

    private void OnTriggerEnter(Collider other)
    {
        if (_gameManager.haveLamp == false)
        {
            if (other.CompareTag("Player"))
            {
                onPilar = true;
                canTake = true;
            }
        }
        else
        {
            if (other.CompareTag("Pilar"))
            {
                pilar = other.gameObject;
                onPilar = false;
                canPut = true;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Pilar")) canPut = false;
        if (other.CompareTag("Player")) canTake = false;
    }

    public void ChargeLigth()
    {
        if (onPilar)
        {
            if(_gameManager.timeLigth < 60)
            {
                _gameManager.timeLigth += Time.deltaTime * 4;
            }
        }
    }

    public void PickUpLigth()
    {
        if (!onPilar && canPut)
        {
            if (Input.GetButtonDown("Fire1"))
            {
                transform.SetParent(pilar.transform);
                transform.position = new Vector3(pilar.transform.position.x, 1.2f, pilar.transform.position.z);
                transform.rotation = pilar.transform.rotation;

                InfoPartida.lamp.lampPosition = transform.position;
                InfoPartida.saveExist = true;
                _gameManager.haveLamp = false;
            }
        }
        else if(onPilar && canTake)
        {
            if (Input.GetButtonDown("Fire1"))
            {
                transform.SetParent(playerPoint.transform);
                transform.position = playerPoint.transform.position;
                transform.rotation = playerPoint.transform.rotation;
                _gameManager.haveLamp = true;
            }
        }
    }

    //public void Save()
    //{
    //    InfoPartida.lamp.position = transform.position;
    //}

    public void Load()
    {
        transform.position = InfoPartida.lamp.lampPosition;
        _gameManager.haveLamp = false;
        _gameManager.timeLigth = 60;
    }

    //IEnumerator SavePref()
    //{
    //    InfoPartida.player.position = player.transform.position;
    //    Debug.Log(InfoPartida.player.position);
    //    yield return
    //}
}

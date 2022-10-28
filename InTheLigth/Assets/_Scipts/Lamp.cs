using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lamp : MonoBehaviour
{
    GameManager _gameManager;
    [SerializeField] GameObject player;
    [SerializeField] GameObject pilar;
    [SerializeField] Light lifeLigth;

    public float timeLigth = 60f;

    
    public bool onPilar, canTake, canPut;
    

    private void Start()
    {
        _gameManager = FindObjectOfType<GameManager>();
    }


    private void Update()
    {
        lifeLigth.range = timeLigth / 10;
        lifeLigth.intensity = timeLigth / 10;

        if (timeLigth > 60) timeLigth = 60;
        if (timeLigth < 0) timeLigth = 0;

        if (!onPilar && timeLigth > 0) timeLigth -= Time.deltaTime;

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
            if(timeLigth < 60)
            {
                timeLigth += Time.deltaTime * 4;
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
                _gameManager.haveLamp = false;
            }
        }
        else if(onPilar && canTake)
        {
            if (Input.GetButtonDown("Fire1"))
            {
                transform.SetParent(player.transform);
                transform.position = player.transform.position;
                transform.rotation = player.transform.rotation;
                _gameManager.haveLamp = true;
            }
        }
    }
}

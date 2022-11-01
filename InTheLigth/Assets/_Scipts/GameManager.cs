using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    [Header("Estados")]
    public bool haveLamp;
    public bool inDanger;
    public bool alert;
    public bool safe;
    public bool canSave;

    [Header("Información de juego")]
    public float timeLigth = 60;

    public GameObject playerGO;
    public GameObject lampGO;
    public Vector3 currentPlayerposition;
    

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        if (playerGO == null) playerGO = GameObject.FindGameObjectWithTag("Player");
        if (lampGO == null) lampGO = GameObject.FindGameObjectWithTag("Lamp");

        if (canSave) currentPlayerposition = playerGO.transform.position;


        if (timeLigth <= 0) inDanger=true;

    }

    private void LateUpdate()
    {
        if (playerGO == null) playerGO = GameObject.FindGameObjectWithTag("Player");
        if (lampGO == null) lampGO = GameObject.FindGameObjectWithTag("Lamp");
    }

    public void SavePlayer()
    {
        InfoPartida.saveExist = true;
        InfoPartida.player.playerPosition = playerGO.transform.position;
    }

    public void SaveLamp()
    {
        InfoPartida.saveExist = true;
        InfoPartida.lamp.lampPosition = lampGO.transform.position;
    }

}

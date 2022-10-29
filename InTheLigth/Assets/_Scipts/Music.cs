using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Music : MonoBehaviour
{
    public AudioSource ambienMusic;
    public AudioSource ambienMusicDanger;
    public AudioSource breathing;
    public AudioSource hurt;

    public bool inDanger, changeTrack;
    GameManager _gameManager;

    void Start()
    {
        _gameManager = FindObjectOfType<GameManager>();
        changeTrack = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (_gameManager.timeLigth > 0) inDanger = false;
        if (_gameManager.timeLigth < 0) inDanger = true;
        if(!inDanger) ambienMusic.volume = _gameManager.timeLigth / 100;


        if (!inDanger && !changeTrack)
        {
            ambienMusic.Play();
            ambienMusicDanger.Stop();
            breathing.Play();
            hurt.Stop();
            changeTrack = true;
        }
        else if(inDanger && changeTrack)
        {

            ambienMusic.Stop();
            ambienMusicDanger.Play();
            breathing.Stop();
            hurt.Play();
            changeTrack = false;
        }
    }
}

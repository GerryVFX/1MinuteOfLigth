using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    AudioSource soundSource;
    [SerializeField] AudioClip[] sounds;
    [SerializeField] LigthLife ligth;

    private void Start()
    {
        soundSource = GetComponent<AudioSource>();
        ligth = FindObjectOfType<LigthLife>();
    }

    private void Update()
    {
      if(ligth.timeLigth > 0)
        {
            soundSource.clip = sounds[0];
            
        }

        if (ligth.timeLigth < 0)
        {
            soundSource.clip = sounds[1];
        }
    }


    public void musicLigth()
    {

    }
}

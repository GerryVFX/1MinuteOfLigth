using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LigthLife : MonoBehaviour
{
    [SerializeField] Light myLigth;
    public float timeLigth;
    public float life;
    [SerializeField] Image lifeLigth;
    [SerializeField] Image lifebar;
    //[SerializeField] AudioSource[] sounds;
    //[SerializeField] AudioClip monster;

    float maxLigth= 60;
    float maxLfe= 30;
    public bool outSafeZone;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        lifeLigth.fillAmount = timeLigth / maxLigth;
        lifebar.fillAmount = life / maxLfe;

        if (life <= 0) SceneManager.LoadScene(0);

        if (outSafeZone && timeLigth > 0)
        {
            timeLigth -= Time.deltaTime;
            myLigth.intensity = timeLigth/100 *2;
            //sounds[0].volume = timeLigth / 100;
        }
        

        if (timeLigth <= 0)
        {
            life -= Time.deltaTime;
            //sounds[1].PlayOneShot(monster);
        }



        //if (timeLigth > 60) timeLigth = 60;

        //if (timeLigth < 60) myLigth.intensity = 1;
        //if (timeLigth < 50)
        //{
        //    myLigth.intensity = 0.8f;
        //    
        //}
        
        //if (timeLigth < 30) myLigth.intensity = 0.5f;
        //if (timeLigth < 10) myLigth.intensity = 0.3f;
        //if (timeLigth < 0) myLigth.intensity = 0;
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("SafeZone"))
        {
            outSafeZone = false;
            if (timeLigth <= 0 || timeLigth < 60)
            {
                timeLigth += Time.deltaTime * 5;
                //sounds[0].volume = timeLigth / 100;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("SafeZone"))
        {
            outSafeZone = true;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    [SerializeField] GameObject player;
    [SerializeField] GameObject lamp;

    [Header("Estados")]
    public bool haveLamp;
    public bool inDanger;
    public bool alert;
    public bool safe;

    [Header("Información de juego")]
    public float timeLigth = 60;

    public Vector3 currentLampPosition;

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

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if (timeLigth <= 0) inDanger=true;
    }

    

    
}

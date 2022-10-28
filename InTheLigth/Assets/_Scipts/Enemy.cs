using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] GameObject playerRef;
    public float speed;
    Vector3 posinicial;
    float distance;
    // Start is called before the first frame update
    void Start()
    {
        posinicial = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        Physics.IgnoreLayerCollision(0, 6);
        transform.LookAt(playerRef.transform);

        if (playerRef.GetComponent<LigthLife>().timeLigth < 50 && playerRef.GetComponent<LigthLife>().timeLigth > 20) distance = 4;
        if (playerRef.GetComponent<LigthLife>().timeLigth < 20 && playerRef.GetComponent<LigthLife>().timeLigth > 0) distance = 2;
        


        if (Vector3.Distance(transform.position, playerRef.transform.position) > distance &&
            playerRef.GetComponent<LigthLife>().outSafeZone)
        {
            transform.position = Vector3.MoveTowards(transform.position, playerRef.transform.position, speed * Time.deltaTime);
        }

        if (Vector3.Distance(transform.position, playerRef.transform.position) < distance ||
                 playerRef.GetComponent<LigthLife>().outSafeZone == false)
        {
            transform.position = Vector3.MoveTowards(transform.position, posinicial, speed * Time.deltaTime);
        }

        if (playerRef.GetComponent<LigthLife>().timeLigth < 10) speed = 10;
        else speed = 4.5f;
            
    }
}

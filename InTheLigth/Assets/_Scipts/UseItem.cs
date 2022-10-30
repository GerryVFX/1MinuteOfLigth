using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UseItem : MonoBehaviour
{
    bool canPut;
    bool canReset;

    [SerializeField] Transform seedSpawnPoint;
    [SerializeField] GameObject ligthSeed;
    [SerializeField] GameObject poolSeed;
    public int ligthSeedPool = 50;
    //[SerializeField] TMP_Text seedCount;

    void Update()
    {
        //seedCount.text = ligthSeedPool.ToString();

        if (canPut) PutSeed();
        if (canReset) ResetSeed(); 
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("SafeZone"))
        {
            canReset = true;
            canPut = false;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("SafeZone"))
        {
            canPut = true;
            canReset = false;
        }
    }

    void PutSeed()
    {
        if (Input.GetButtonDown("Fire2") && ligthSeedPool > 0)
        {
            Instantiate(ligthSeed, seedSpawnPoint.position, Quaternion.identity, parent: poolSeed.transform);

            ligthSeedPool -= 1;
        }
    }

    void ResetSeed()
    {
        if (Input.GetButtonDown("Jump") && ligthSeedPool < 100)
        {
            for (int i = 0; i < poolSeed.transform.childCount; i++)
            {
                ligthSeedPool += 1;
                Destroy(poolSeed.transform.GetChild(i).gameObject);
            }
        }
    }
}

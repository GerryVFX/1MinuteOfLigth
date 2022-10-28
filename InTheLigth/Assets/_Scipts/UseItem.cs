using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UseItem : MonoBehaviour
{
    [SerializeField] GameObject ligthSeed;
    [SerializeField] GameObject poolSeed;
    public int ligthSeedPool = 50;
    public List<GameObject> seedsCreated = new List<GameObject>();
    [SerializeField] TMP_Text seedCount;

    
    void Update()
    {
        seedCount.text = ligthSeedPool.ToString();

        if (Input.GetKeyDown(KeyCode.Joystick1Button1) && ligthSeedPool > 0)
        {
            Vector3 ofsetCreate = new Vector3(transform.position.x, transform.position.y-1, transform.position.z - 1f);
            Instantiate(ligthSeed, ofsetCreate, Quaternion.identity, parent:poolSeed.transform);
            
            ligthSeedPool -= 1;
        }

        
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("SafeZone"))
        {
            if (Input.GetKey(KeyCode.Joystick1Button0) && ligthSeedPool < 100)
            {
                for(int i=0; i < poolSeed.transform.childCount; i++)
                {
                    ligthSeedPool += 1;
                    Destroy(poolSeed.transform.GetChild(i).gameObject);
                }
                
            }
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AIEnemyBase : MonoBehaviour
{
    [SerializeField] Transform target;
    [SerializeField] Vector3 myPos;

    NavMeshAgent navMesh;

    [SerializeField] float distance;
    [SerializeField] float rangeDistance = 6;

    // Start is called before the first frame update
    private void Awake()
    {
        myPos = transform.position;
    }

    void Start()
    {
        navMesh = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        distance = Vector3.Distance(transform.position, target.position);

        if (distance > 7)
        {
            navMesh.isStopped = false;
            navMesh.speed = 3.5f;
            navMesh.SetDestination(target.position);
        }
        else
        {
            navMesh.isStopped = true;
        }
        if (distance < 3.5f)

        {
            navMesh.isStopped = false;
            navMesh.speed = 10;
            navMesh.SetDestination(transform.position * 2);
        }

    }
}

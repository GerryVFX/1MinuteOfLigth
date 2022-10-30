using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AIEnemyBase : MonoBehaviour
{
    GameManager _gameManager;

    [SerializeField] Transform target;
    [SerializeField] Vector3 myPos;
    [SerializeField] float distance;
    NavMeshAgent navMesh;

    public float maxDistance;
    public float minDistance;
    public float attackDistance;

    void Start()
    {
        myPos = transform.position;
        navMesh = GetComponent<NavMeshAgent>();
        _gameManager = FindObjectOfType<GameManager>();
    }

    void Update()
    {
        distance = Vector3.Distance(transform.position, target.position);

        if (_gameManager.safe == false && _gameManager.haveLamp) Alert();
        if (_gameManager.safe == false)
        {
            if (_gameManager.haveLamp == false || _gameManager.timeLigth <= 0) Attack();
        }
        if (_gameManager.safe) Back();
    }

    void Alert()
    {
        _gameManager.alert = true;

        if (distance >  maxDistance)
        {
            navMesh.isStopped = false;
            navMesh.speed = 3.5f;
            navMesh.SetDestination(target.position);
        }
        else
        {
            navMesh.isStopped = true;
        }

        if (distance < minDistance)
        {
            navMesh.isStopped = false;
            navMesh.speed = 10;
            navMesh.SetDestination(myPos);
        }
    }

    void Attack()
    {
        _gameManager.inDanger = true;
        _gameManager.alert = false;

        if (distance > attackDistance)
        {
            navMesh.isStopped = false;
            navMesh.speed = 5;
            navMesh.SetDestination(target.position);
        }
        else
        {
            navMesh.isStopped = true;
        }
    }

    void Back()
    {
        _gameManager.alert = false;
        _gameManager.inDanger = false;

        navMesh.isStopped = false;
        navMesh.speed = 10;
        navMesh.SetDestination(myPos);
    }
}

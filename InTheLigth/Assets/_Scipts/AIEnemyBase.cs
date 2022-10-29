using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AIEnemyBase : MonoBehaviour
{
    GameManager _gameManager;

    [SerializeField] Transform target;
    [SerializeField] Vector3 myPos;

    NavMeshAgent navMesh;

    [SerializeField] float distance;
    [SerializeField] float rangeDistance;
    [SerializeField] float minDistance= 3.5f;

    public bool radyForAttack;

    private void Awake()
    {
        myPos = transform.position;
    }

    void Start()
    {
        navMesh = GetComponent<NavMeshAgent>();
        _gameManager = FindObjectOfType<GameManager>();
    }

    void Update()
    {
        RangeForDistance();

        distance = Vector3.Distance(transform.position, target.position);

        if (_gameManager.haveLamp == false || _gameManager.timeLigth <= 0)
        {
            radyForAttack = true;
        }
        else radyForAttack = false;


        if (_gameManager.timeLigth > 0)
        {
            if (distance > rangeDistance && _gameManager.inDanger)
            {
                navMesh.isStopped = false;
                navMesh.speed = 2.5f;
                navMesh.SetDestination(target.position);
            }
            else
            {
                navMesh.isStopped = true;
            }
        }

        if(_gameManager.inDanger == false)
        {
            navMesh.isStopped = false;
            navMesh.speed = 10;
            navMesh.SetDestination(myPos);
        }

        if(_gameManager.haveLamp && _gameManager.timeLigth > 0)
        {
            if (distance < minDistance)
            {
                navMesh.isStopped = false;
                navMesh.speed = 10;
                navMesh.SetDestination(myPos);
            }
        }
    }

    void RangeForDistance()
    {
        if (_gameManager.timeLigth <= 60) rangeDistance = 8;

        if (_gameManager.timeLigth <= 40) rangeDistance = 6;

        if (_gameManager.timeLigth <= 20) rangeDistance = 4;

        if (radyForAttack)
        {
            navMesh.speed = 7;
            rangeDistance = 2;
        }
    }
}

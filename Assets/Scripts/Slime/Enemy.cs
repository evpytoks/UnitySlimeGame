using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using GameUtils;

public class Enemy : MonoBehaviour
{
    private NavMeshAgent navMeshAgent;

    [SerializeField] private State starting;
    [SerializeField] private float distanceMin = 300f;
    [SerializeField] private float distanceMax = 700f;
    [SerializeField] private float walkingIterationTime = 4f;
    private Vector3 startingPoint;
    private State state;
    private float walkingTimeLeft;
    private Vector3 goalPoint;


    private enum State 
    {
        Idle, 
        Walking
    }


    private void Awake()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        navMeshAgent.updateRotation = false;
        navMeshAgent.updateUpAxis = false;
        state = starting;
    }

    private void Update()
    {
        switch (state) 
        {
            default:
            case State.Idle:
                break;
            case State.Walking:
                walkingTimeLeft -= Time.deltaTime;
                if (walkingTimeLeft < 0) 
                {
                    Walking();
                    walkingTimeLeft = walkingIterationTime;
                }
                break;
        }
    }

    private void Walking() 
    {
        startingPoint = transform.position;
        goalPoint = GetGoalPoint();
        Turn(startingPoint, goalPoint);
        navMeshAgent.SetDestination(goalPoint);
    }

    private void Turn(Vector3 position, Vector3 goalPoint) 
    {
        if (position.x > goalPoint.x) 
        {
            transform.rotation = Quaternion.Euler(0, -180, 0);
        } else 
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }
    }

    private Vector3 GetGoalPoint() 
    {
        return startingPoint + Utils.RandomDirection() * UnityEngine.Random.Range(distanceMin, distanceMax);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            SlimeCounter.Instance.AddSlime();
            Destroy(gameObject);
        }
    }
}

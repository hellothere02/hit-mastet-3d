using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]

public class CharacterController : MonoBehaviour
{
    private NavMeshAgent agent;
    public NavMeshAgent Agent
    {
        get => agent;
    }
    private bool isShootingMode;

    public bool IsShootingMode
    { get => isShootingMode; }
    [SerializeField] private GameObject[] waypoints;
    [SerializeField] private int currentWaypoint;


    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        isShootingMode = true;
        SetDestination(0);
    }

    private void Update()
    {
        if (CheckEnemiesOnScene.IsEnemiesOnScene == false && agent.remainingDistance == 0)
        {
            isShootingMode = false;
            SetDestination(currentWaypoint);
            currentWaypoint++;
        }
        else
        {
            isShootingMode = true;
        }

        if (currentWaypoint > waypoints.Length)
        {
            SceneController.RestartScene();
        }
    }

    public void SetDestination(int waypoint)
    {
        if (currentWaypoint >= waypoints.Length)
        {
            return;
        }
        agent.destination = waypoints[waypoint].transform.position;
    }
}

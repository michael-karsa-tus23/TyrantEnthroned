using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.InputSystem;

public class MoveTo : MonoBehaviour
{
    private NavMeshAgent agent;
    public List<Transform> patrolArea = new List<Transform>();
    private Transform targetDestination;
    private int patrolPoint = 0;
    private SphereCollider detectCollider;
    public bool chase = false;
    public float regularSpeed;

    [Header("Chase Attributes")]
    public float elapsedTimeSec;        //timer to make enemy give up
    public float chaseTimeSec;          //required time to make enemy give up
    public float ChaseSpeed;
    public float ChaseStartDistance;
    public float ChaseGiveUpDistance;
    public GameObject chaseTarget;      //this will be the player

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //detectCollider = GetComponent<SphereCollider>();
        //detectCollider.radius = ChaseStartDistance;
        agent = GetComponent<NavMeshAgent>();
        agent.speed = regularSpeed;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //patrol
        if (chase)
        {
            targetDestination = chaseTarget.transform;    //if the enemy is chasing, their destination is the player

            //if the enemy is chasing for too long, it will give up
            elapsedTimeSec = elapsedTimeSec + Time.deltaTime;
            if (elapsedTimeSec > chaseTimeSec)
            {
                elapsedTimeSec = 0;
                chase = false;
            }
        }
        else    //otherwise, just patrol around the area
        {
            if (!agent.pathPending && agent.remainingDistance <= agent.stoppingDistance)
            {
                patrolPoint++;
                if (patrolPoint >= patrolArea.Count)
                {
                    patrolPoint = 0;
                }
            }
            targetDestination = patrolArea[patrolPoint];
        }
        agent.SetDestination(targetDestination.position);

    }
    /*
    //if the player is near, begin chase
    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<CharacterController>() != null)
        {
            chaseTarget = other.gameObject;
            chase = true;
            detectCollider.radius = ChaseGiveUpDistance;
            agent.speed = ChaseSpeed;
        }
    }
    //if the player is too far, give up
    private void OnTriggerExit(Collider other)
    {
        if (other.GetComponent<CharacterController>() != null)
        {
            chase = false;
            detectCollider.radius = ChaseStartDistance;
            agent.speed = regularSpeed;
        }
    }

    private void OnDrawGizmos()
    {
        foreach (Transform t in patrolArea)
        {
            Gizmos.DrawWireCube(t.position, Vector3.one);
        }
    }
    */
}
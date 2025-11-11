using UnityEngine;
using UnityEngine.AI;

public class LightDetect : MonoBehaviour
{
    public MoveTo moveTo;
    public NavMeshAgent agent;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        moveTo = GetComponentInParent<MoveTo>();
        agent = GetComponentInParent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    //if the player is near, begin chase
    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Rigidbody>() != null)
        {
            moveTo.chaseTarget = other.gameObject;
            moveTo.chase = true;
            //detectCollider.radius = ChaseGiveUpDistance;
            agent.speed = moveTo.ChaseSpeed;
        }
    }/*
    //if the player is too far, give up
    private void OnTriggerExit(Collider other)
    {
        if (other.GetComponent<Rigidbody>() != null)
        {
            moveTo.chase = false;
            //detectCollider.radius = ChaseStartDistance;
            agent.speed = moveTo.regularSpeed;
        }
    }
    */
}

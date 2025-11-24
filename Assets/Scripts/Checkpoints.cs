using UnityEngine;
using UnityEngine.AI;

public class Checkpoints : MonoBehaviour
{
    public GameObject lastCheckpoint = null;
    public GameObject playerController;
    void Teleport()
    {
        Debug.Log("Teleported");
        
        playerController.transform.position = lastCheckpoint.transform.position;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Checkpoint")
        {
            lastCheckpoint = other.gameObject;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponent<NavMeshAgent>() != null)
        {
            Debug.Log("Enemy hit me, TELEPORT MEEEEE");
            Teleport();
        }
    }
}

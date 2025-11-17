using UnityEngine;

public class PlayerRespawn : MonoBehaviour
{
    private Checkpoints theCheckpoint;
    private void Start()
    {
        theCheckpoint = GetComponent<Checkpoints>();
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            transform.position = theCheckpoint.lastCheckpoint.transform.position;
        }
    }
}

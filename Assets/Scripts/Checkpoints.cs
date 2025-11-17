using UnityEngine;

public class Checkpoints : MonoBehaviour
{
    public GameObject lastCheckpoint = null;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Checkpoint")
        {
            lastCheckpoint = other.gameObject;
        }
    }
}

using UnityEngine;

public class KillTheKing : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "KING")
        {
            Destroy(collision.gameObject);
        }
    }
}

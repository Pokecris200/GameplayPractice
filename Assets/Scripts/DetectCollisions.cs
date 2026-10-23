using UnityEngine;

public class DetectCollisions : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player")) 
        {
            Destroy(gameObject);
            Destroy(other.gameObject); 
        }
    }
}

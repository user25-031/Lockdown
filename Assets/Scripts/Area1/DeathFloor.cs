using UnityEngine;

public class DeathFloor : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Kill Player");
        }
    }
}

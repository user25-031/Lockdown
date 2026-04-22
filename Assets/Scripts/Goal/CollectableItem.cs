using UnityEngine;

public class CollectableItem : MonoBehaviour
{
    private int value = 1;
    void Update()
    {
        transform.Rotate(0f, 180f * Time.deltaTime, 0f, Space.World);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Messenger<int>.Broadcast(GameEvent.PICKUP_BATTERY, value);
            GetComponent<Collider>().enabled = false;
            GetComponent<MeshRenderer>().enabled = false;
            Destroy(gameObject);
        }
    }
}

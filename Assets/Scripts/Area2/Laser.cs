using UnityEngine;

public class Laser : MonoBehaviour
{
    public float speed = 10f;
    [SerializeField] private Rigidbody rb;
    void FixedUpdate()
    {
        Vector3 movement = transform.forward * speed * 100 * Time.deltaTime;
        rb.linearVelocity = movement;
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Ground"))
        {
            return;
        }
        PlayerCharacter player = other.GetComponent<PlayerCharacter>();
        if (player != null)
        {
            player.Hit();
        }
        Destroy(this.gameObject);
    }
}
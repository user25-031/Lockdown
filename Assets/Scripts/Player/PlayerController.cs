using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] CharacterController controller;
    [SerializeField] Transform groundCheck;
    [SerializeField] LayerMask groundMask;
    [SerializeField] Animator anim;
    [SerializeField] UIManager uiMan;
    float speed = 20f;
    float gravity = -9.81f;
    float jumpHeight = 10f;
    float groundDistance = 0.4f;
    Vector3 velocity;
    bool isGrounded;
    int battery = 0;
    private void Awake()
    {
        Messenger<int>.AddListener(GameEvent.PICKUP_BATTERY, this.OnPickupBattery);
    }
    private void OnDestroy()
    {
        Messenger<int>.RemoveListener(GameEvent.PICKUP_BATTERY, this.OnPickupBattery);
    }
    public void OnPickupBattery(int value)
    {
        battery += value;
        uiMan.UpdateScore(battery);
        controller.enabled = false;
        transform.position = Vector3.zero;
        controller.enabled = true;
    }
    void Update()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);
        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");
        Vector3 forward = transform.forward;
        forward.y = 0f;
        forward.Normalize();

        Vector3 right = transform.right;
        right.y = 0f;
        right.Normalize();

        Vector3 move = right * x + forward * z;
        move = Vector3.ClampMagnitude(move, 1.0f);
        controller.Move(move * speed * Time.deltaTime);
        anim.SetFloat("MoveX", x, 0.1f, Time.deltaTime);
        anim.SetFloat("MoveZ", z, 0.1f, Time.deltaTime);
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }
        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
    }
    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if (hit.moveDirection.y < -0.5f)
        {
            FallingTile tile = hit.gameObject.GetComponent<FallingTile>();
            if (tile != null)
            {
                tile.TriggerTile();
            }
        }
    }
}

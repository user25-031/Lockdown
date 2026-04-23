using UnityEngine;
using System.Collections;

public class Area3DoorController : MonoBehaviour
{
    [SerializeField] Animator animator;
    float interval = 3f;
    bool isOpen = false;
    bool playerInside = false;
    void Start()
    {
        StartCoroutine(DoorLoop());
    }
    IEnumerator DoorLoop()
    {
        while (true)
        {
            isOpen = !isOpen;
            animator.SetBool("character_nearby", isOpen);
            if (!isOpen && playerInside)
            {
                KillPlayer();
            }
            yield return new WaitForSeconds(interval);
        }
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerInside = true;
        }
    }
    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerInside = false;
        }
    }
    void KillPlayer()
    {
        Messenger.Broadcast(GameEvent.PLAYER_DEAD);
    }
}
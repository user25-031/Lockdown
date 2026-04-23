using UnityEngine;

public class PlayerCharacter : MonoBehaviour
{
    private int health;
    private int maxHealth = 5;
    void Start()
    {
        health = maxHealth;
    }
    public void Hit()
    {
        health -= 1;
        float healthPercent = (float)health / maxHealth;
        Messenger<float>.Broadcast(GameEvent.HEALTH_CHANGED, healthPercent);
        Debug.Log("Health: " + health);
        if (health <= 0)
        {
            Messenger.Broadcast(GameEvent.PLAYER_DEAD);
        }
    }
}
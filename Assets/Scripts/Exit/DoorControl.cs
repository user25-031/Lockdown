using UnityEngine;

public class DoorControl : MonoBehaviour
{
    [SerializeField] Animator anim;
    int batteryCount = 0;
    [SerializeField] LevelCompletedPopup LevelCompletedPopup;
    private void Awake()
    {
        Messenger<int>.AddListener(GameEvent.PICKUP_BATTERY, OnBatteryPicked);
    }
    private void OnDestroy()
    {
        Messenger<int>.RemoveListener(GameEvent.PICKUP_BATTERY, OnBatteryPicked);
    }
    void Start()
    {
        anim.SetBool("character_nearby", false);
    }
    void OnBatteryPicked(int value)
    {
        batteryCount += value;
        if (batteryCount >= 3)
        {
            anim.SetBool("character_nearby", true);
        }
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            LevelCompletedPopup.Open();
        }
    }
}

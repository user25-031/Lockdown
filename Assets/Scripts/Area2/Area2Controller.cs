using UnityEngine;

public class Area2Controller : MonoBehaviour
{
    [SerializeField] private GameObject enemyPrefab;
    private GameObject enemy;
    private Vector3 spawnPoint = new Vector3(-240, -39, 0);
    GameObject[] enemies = new GameObject[5];
    bool allNull;
    bool hasTriggered = false;
    [SerializeField] GameObject battery;
    private void Start()
    {
        for (int i = 0; i < enemies.Length; i++) { 
            enemy = Instantiate(enemyPrefab);
            enemy.transform.position = spawnPoint;
            float angle = Random.Range(0, 360);
            enemy.transform.Rotate(0, angle, 0);
            enemies[i] = enemy;
        }
    }
    private void Update()
    {
        if (hasTriggered) return;
        allNull = true;
        for (int i = 0; i < enemies.Length; i++)
        {
            if (enemies[i] != null)
            {
                allNull = false;
                break;
            }
        }
        if (allNull)
        {
            GameObject pickupItem = Instantiate(battery);
            pickupItem.transform.position = spawnPoint;
            float angle = Random.Range(0, 360);
            pickupItem.transform.Rotate(0, angle, 0);
            hasTriggered = true;
        }
    }
}

using UnityEngine;
public enum EnemyStates { alive, dead };
public class WanderingAI : MonoBehaviour
{
    private float enemySpeed = 5f;
    private float obstacleRange = 5.0f;
    private float sphereRadius = 0.75f;
    private EnemyStates state;
    [SerializeField] private GameObject laserbeamPrefab;
    public float fireRate = 2.0f;
    private float nextFire = 0.0f;
    [SerializeField] Animator anim;
    void Start()
    {
        state = EnemyStates.alive;
        anim.SetBool("Walk_Anim", true);
    }
    void Update()
    {
        if (state == EnemyStates.alive)
        {
            transform.Translate(Vector3.forward * enemySpeed * Time.deltaTime);
            Vector3 origin = transform.position + Vector3.up * 1.8f;
            Ray ray = new Ray(origin, transform.forward);

            if (Physics.SphereCast(ray, sphereRadius, out RaycastHit hit, 10f))
            {
                if (hit.distance < obstacleRange)
                {
                    float turnAngle = Random.Range(-110, 110);
                    transform.Rotate(0, turnAngle, 0);
                }
            }
            if (Time.time > nextFire)
            {
                nextFire = Time.time + fireRate;
                Vector3 spawnPos = transform.position
                    + transform.forward * 10f
                    + Vector3.up * 3f;
                GameObject laser = Instantiate(laserbeamPrefab, spawnPos, transform.rotation);
            }
        }
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Vector3 rangeTest = transform.position + transform.forward * obstacleRange;
        Debug.DrawLine(transform.position, rangeTest);
        Gizmos.DrawWireSphere(rangeTest, sphereRadius);
    }
}
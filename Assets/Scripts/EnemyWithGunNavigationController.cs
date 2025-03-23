using UnityEngine;
using UnityEngine.AI;

public class EnemyWithGunNavigationController : MonoBehaviour
{
    [SerializeField] private GameObject[] enemyNavigationPoints;
    [SerializeField] private GameObject character;
    [SerializeField] private float minTimeToWalk;
    [SerializeField] private float maxTimeToWalk;
    [SerializeField] private float timeToWalkIfCharacterDetected;
    [SerializeField] private float visible;
    private float distance;
    private NavMeshAgent enemy;
    private float timeToWalk;
    private int randomPoint;

    public bool IsMoving => enemy.velocity.magnitude > 0;
    public bool CharacterDetected => distance <= visible;
    public bool IsRotated => enemy.transform.rotation.y < 0;

    private void Awake()
    {
        enemy = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        distance = Vector3.Distance(transform.position, character.transform.position);

        if(distance <= visible)
        {
            enemy.stoppingDistance = visible - 3;
            enemy.destination = character.transform.position;
            timeToWalk = timeToWalkIfCharacterDetected;
        }
        else
        {
            enemy.stoppingDistance = 0;
            if (enemy.stoppingDistance <= 1)
            {
                timeToWalk -= Time.deltaTime;
                if (timeToWalk <= 0)
                {
                    timeToWalk = Random.Range(minTimeToWalk, maxTimeToWalk);
                    randomPoint = Random.Range(0, enemyNavigationPoints.Length);
                    enemy.destination = enemyNavigationPoints[randomPoint].transform.position;
                }
            }
        }
    }
}

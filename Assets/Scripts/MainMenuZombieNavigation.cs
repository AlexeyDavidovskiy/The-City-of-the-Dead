using UnityEngine;
using UnityEngine.AI;

public class MainMenuZombieNavigation : MonoBehaviour
{
    [SerializeField] private GameObject[] zombiePoints;
    [SerializeField] private float minTimeToWalk;
    [SerializeField] private float maxTimeToWalk;
    private NavMeshAgent zombie;
    private int randomPoint;
    private float timeToWalk;
    public bool isWalking => zombie.velocity.magnitude > 0;

    private void Start()
    {
        zombie = GetComponent<NavMeshAgent>();

        randomPoint = Random.Range(0, zombiePoints.Length);
        zombie.destination = zombiePoints[randomPoint].transform.position;
        timeToWalk = Random.Range(minTimeToWalk, maxTimeToWalk);
    }

    private void Update()
    {
        if (zombie.stoppingDistance <= 3)
        {
            timeToWalk -= Time.deltaTime;
            if (timeToWalk <= 0)
            {
                timeToWalk = Random.Range(minTimeToWalk, maxTimeToWalk);
                randomPoint = Random.Range(0, zombiePoints.Length);
                zombie.destination = zombiePoints[randomPoint].transform.position;
            }
        }
    }
}

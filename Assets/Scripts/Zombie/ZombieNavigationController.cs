using UnityEngine;
using UnityEngine.AI;

public class ZombieNavigationController : MonoBehaviour
{
    [SerializeField] private GameObject[] zombieNavigationPoints;
    [SerializeField] private GameObject character;
    [SerializeField] private float minTimeToWalk;
    [SerializeField] private float maxTimeToWalk;
    [SerializeField] private float timeToWalkIfCharacterDetected;
    [SerializeField] private float visible;
    private float distance;
    private NavMeshAgent zombie;
    private float timeToWalk;
    private int randomPoint;
 

    public bool isWalking => zombie.velocity.magnitude > 0;

    private void Awake()
    {
        zombie = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        distance = Vector3.Distance(transform.position,character.transform.position);

        if (distance <= visible)
        {
            zombie.destination = character.transform.position;
            timeToWalk = timeToWalkIfCharacterDetected;
        }
        else 
        {
            if (zombie.stoppingDistance <= 1)
            {
                timeToWalk -= Time.deltaTime;
                if (timeToWalk <= 0)
                {
                    timeToWalk = Random.Range(minTimeToWalk, maxTimeToWalk);
                    randomPoint = Random.Range(0, zombieNavigationPoints.Length);
                    zombie.destination = zombieNavigationPoints[randomPoint].transform.position;
                }
            }
        }

    }  
}

using UnityEngine;
using UnityEngine.AI;

public class ZombieHordeNavigationController : MonoBehaviour
{
    [SerializeField] private GameObject character;
    private NavMeshAgent zombie;
    public bool IsWalking => zombie.velocity.magnitude > 0;

    private void Awake()
    {
        zombie = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        zombie.destination = character.transform.position;
    }
}

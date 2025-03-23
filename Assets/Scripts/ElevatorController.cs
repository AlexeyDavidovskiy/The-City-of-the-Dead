using UnityEngine;

public class ElevatorController : MonoBehaviour
{
    [SerializeField] private GameObject elevator;
    [SerializeField] private Transform roof;
    [SerializeField] private Transform secondLevel;
    [SerializeField] private float speedUp;
    [SerializeField] private float speedDown;
    private Vector2 target;
    private float currentSpeed;

    private void Awake()
    {
        target = roof.position;
        currentSpeed = speedUp;
    }
    private void Update()
    {
        ElevatorMoving();
    }

    private void ElevatorMoving() 
    {
      elevator.transform.position = Vector2.MoveTowards(elevator.transform.position,target, currentSpeed);
    }

    public void ChangeDirectionDown() 
    {
        target = secondLevel.position;
        currentSpeed = speedDown;
    }
    public void ChangeDirectionUp() 
    {
        target = roof.position;
        currentSpeed = speedUp;
    }

}


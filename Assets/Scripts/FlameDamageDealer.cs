using UnityEngine;

public class FlameDamageDealer : MonoBehaviour
{
    [SerializeField] private int damage;
    [SerializeField] private float timeToGiveDamage;
    [SerializeField] private float resTimer;
    [SerializeField] private Health health;
    private bool playerInTheTriggerZone;

    private void Update()
    {
        GiveDamage();
    }

    private void GiveDamage() 
    {
        if(playerInTheTriggerZone == true)
        {
            timeToGiveDamage -= Time.deltaTime;
            if(timeToGiveDamage <= 0) 
            {
                health.TakeDamage(damage);
                timeToGiveDamage = resTimer;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.TryGetComponent<Health>(out var health)) 
        {
            playerInTheTriggerZone = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        playerInTheTriggerZone = false;
    }
}

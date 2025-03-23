using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class ElevatorTriggerZone : MonoBehaviour
{
    [SerializeField] private UnityEvent elevator;
    [SerializeField] private GameObject text;
    private bool playerInTheTriggerZone;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            ElevatorCalling();

            StartCoroutine(TimerForText(text));
        }
    }

    public void ElevatorCalling() 
    {
        if (playerInTheTriggerZone == true)
        {
            elevator?.Invoke();
            Destroy(gameObject,3f);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.TryGetComponent<PlayerInput>(out var playerInput)) 
        {
            playerInTheTriggerZone = true;
            text.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        playerInTheTriggerZone = false;
        text.SetActive(false);
    }

    private IEnumerator TimerForText(GameObject text) 
    {
        yield return new WaitForSeconds(2f);
        text.SetActive(false);
    }
}

using UnityEngine;
using UnityEngine.Events;

public class FinalCutSceneTriggerZone : MonoBehaviour
{
    [SerializeField] private GameObject text;
    [SerializeField] private UnityEvent callHorde;
    private bool playerInTheTriggerZone;

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.E))
        {
            CallHelicopter();
        }
    }
    private void CallHelicopter()
    {
        if(playerInTheTriggerZone == true) 
        {
            callHorde?.Invoke();
            text.SetActive(false);
            Destroy(gameObject);
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
}

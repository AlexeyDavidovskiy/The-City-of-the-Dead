using UnityEngine;
using UnityEngine.Playables;

public class TimeLineController : MonoBehaviour
{
    [SerializeField] private GameObject gun;
    private PlayableDirector timeLine;
    private bool gunIsActive;

    public bool weaponIsActive => gunIsActive == true;

    private void Start()
    {
        timeLine = GetComponent<PlayableDirector>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<PlayerInput>(out var pI))
        {
            timeLine.Play();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        gameObject.SetActive(false);
        gun.SetActive(true);
        gunIsActive = true;
    }
}

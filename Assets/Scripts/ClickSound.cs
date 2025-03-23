using UnityEngine;

public class ClickSound : MonoBehaviour
{
    private AudioSource audioSource;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }
    public void OnClick()
    {
        audioSource.Play();
    }
}

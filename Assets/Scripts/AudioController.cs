using UnityEngine;

public class AudioController : MonoBehaviour
{
    [SerializeField] private AudioClip shotSound;
    [SerializeField] private AudioClip reloadingSound;
    [SerializeField] private AudioClip emtyFireSound;
    [SerializeField] private AudioSource hordeComingEffect;
    [SerializeField] private AudioSource background;
    private AudioSource gunSoundEffects;

    private void Awake()
    {
        gunSoundEffects = GetComponent<AudioSource>();
    }

    private void Start()
    {
        background.Play();
    }

    public void ShotSound()
    {
        gunSoundEffects.clip = shotSound;
        gunSoundEffects.Play();
    }

    public void EmptyFireSound()
    {
        gunSoundEffects.clip = emtyFireSound;
        gunSoundEffects.Play();
    }

    public void ReloadingSound()
    {
        gunSoundEffects.clip = reloadingSound;
        gunSoundEffects.Play();
    }

    public void HordeComingSound()
    {
        hordeComingEffect.Play();
    }
}

using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    [SerializeField] private AudioController audioEffects;
    private PlayerMovement playerMovement;
    private CharacterAnimationController characterAnimationController;
    private Shooter shooter;
    private Ammo ammo;

    private void Awake()
    {
        playerMovement = GetComponent<PlayerMovement>();
        characterAnimationController = GetComponent<CharacterAnimationController>();
        shooter = GetComponent<Shooter>();
        ammo = GetComponent<Ammo>();
    }

    private void Update()
    {
        float horizontalDirection = Input.GetAxis("Horizontal");

        playerMovement.Move(horizontalDirection);
        playerMovement.Rotation(horizontalDirection);


        if (Input.GetKeyDown(KeyCode.Space))
        {
            playerMovement.Jump();
        }

        Shooting();
        Reload();
    }

    private void Shooting()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            characterAnimationController.RunningPerShooting();
            shooter.StartShooting();
        }
    }

    private void Reload() 
    {
        if(Input.GetKeyDown(KeyCode.R))
        {
            ammo.StartReloading();
            audioEffects.ReloadingSound();
        }
    }
}

using UnityEngine;

public class MainMenuZombieAnimator : MonoBehaviour
{
    private Animator animator;
    private MainMenuZombieNavigation nav;

    private void Awake()
    {
        animator = GetComponent<Animator>();
        nav = GetComponent<MainMenuZombieNavigation>();
    }

    private void Update()
    {
        if (nav.isWalking)
        {
            animator.SetBool("IsWalking", true);
        }
        else
        {
            animator.SetBool("IsWalking", false);
        }
    }
}

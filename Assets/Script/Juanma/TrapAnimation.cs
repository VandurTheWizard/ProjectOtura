using UnityEngine;

public class TrapAnimation : MonoBehaviour, TrapAnimationInterface
{
    [SerializeField] Animator animator;
    public void CreateAnim()
    {
        animator = GetComponent<Animator>();
        animator.Play("CreateAnim");
    }

    public void DestroyAnim()
    {
        animator = GetComponent<Animator>();
        animator.Play("EndAnim");
    }
}

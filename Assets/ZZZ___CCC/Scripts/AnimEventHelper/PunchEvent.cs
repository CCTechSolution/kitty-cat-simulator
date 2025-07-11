using UnityEngine;

public class PunchEvent : MonoBehaviour
{
    Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }
    public void AtPunchEnd()
    {
        animator.ResetTrigger("Punch");
        gameObject.SetActive(false); 
    }
}

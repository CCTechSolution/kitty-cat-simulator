using UnityEngine;
using System.Collections;

public class Granny_ChaseState : GrannyState
{

    private float timeSinceLostTarget = 0f;
    private float maxChaseTime = 15f;
    public Granny_ChaseState(Granny granny, Granny_StateMachine stateMachine, Granny_Animator animator) : base(granny, stateMachine, animator) { }

    public override void EnterState()
    {
        if (Sfx_Manager.Instance)
        {
            Sfx_Manager.PlayRandomSound(Sfx_Manager.Instance.dangerSound,0.5f);
        }
        timeSinceLostTarget = 0f;
        granny.WaitAtHitObject();
        animator.GetsAngry();
    }
    public override void UpdateState()
    {
        Debug.Log("Enemy is in chasing update state");

        if (!granny.CanAttackCat())
        {
            granny.ChaseCat();
            timeSinceLostTarget += Time.deltaTime;
        }
        else
        {
            timeSinceLostTarget = 0f;
        }

        if (granny.CanAttackCat())
        {
            Debug.LogWarning("Enemy can attack cat now and is changing state");
            stateMachine.ChangeState(new Granny_AttackState(granny, stateMachine, animator));
            return;
        }

        if (timeSinceLostTarget >= maxChaseTime)
        {
            Debug.Log("Cat is too far, Granny returns to wandering.");
            stateMachine.ChangeState(new Granny_WanderState(granny, stateMachine, animator));
            animator.ChaseToWander();
            return;
        }
    }
}

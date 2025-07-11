using UnityEngine;

public class Granny_AttackState : GrannyState
{
    public Granny_AttackState(Granny granny, Granny_StateMachine stateMachine, Granny_Animator animator) : base(granny, stateMachine, animator){ }

    public override void EnterState()
    {
        granny.AttackCat();
        if(Sfx_Manager.Instance)
        Sfx_Manager.PlayRandomSound(Sfx_Manager.Instance.grannyAttack);
    }

    public override void UpdateState()
    {
        
    }
}

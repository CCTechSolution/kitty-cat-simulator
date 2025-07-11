
public abstract class GrannyState
{
    protected Granny granny;
    protected Granny_StateMachine stateMachine;
    protected Granny_Animator animator;

    public GrannyState(Granny granny, Granny_StateMachine stateMachine, Granny_Animator animator)
    {
        this.granny = granny;
        this.stateMachine = stateMachine;
        this.animator = animator;
    }

    public virtual void EnterState() { }
    public virtual void UpdateState() { }
    public virtual void ExitState() { }
}

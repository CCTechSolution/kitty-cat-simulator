using UnityEngine;

public class Granny_WanderState : GrannyState
{
    private Vector3 destination;
    float stoppingDistance = 0.5f;
    public Granny_WanderState(Granny granny, Granny_StateMachine stateMachine, Granny_Animator animator) : base(granny, stateMachine, animator) { }


    public override void EnterState()
    {
        granny.EnemyCanMove();
        SetNewDestination();
    }
    public override void UpdateState()
    {
        granny.UpdateWalkAnimation();
        MoveToDestination();
       
    }
    private void SetNewDestination()
    {
        if (granny.wayPoints != null && granny.wayPoints.Count > 0)
        {
            int randomIndex = Random.Range(0, granny.wayPoints.Count);
            destination = granny.wayPoints[randomIndex].position;
            granny.navMeshAgent.SetDestination(destination);
        }
    }

    private void MoveToDestination()
    {
        if (!granny.navMeshAgent.pathPending && granny.navMeshAgent.remainingDistance <= stoppingDistance)
        {
            granny.WaitAtPoint();
            SetNewDestination();
        }
    }


}

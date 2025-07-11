using UnityEngine;
using UnityEngine.AI;
using System.Collections;
using System;
using System.Collections.Generic;

public class Granny : MonoBehaviour
{
    public Transform catTransform;
    public NavMeshAgent navMeshAgent { get; private set; }

    [SerializeField] Granny_Animator grannyAnimator;

    private Granny_StateMachine granny_StateMachine;

    public static event Action OnWaitChaseEnd;

    float minDisToAttackCat = 1.3f;

    public List<Transform> wayPoints = new List<Transform>();

    [SerializeField] LayerMask enemyLayer;
    [SerializeField] LayerMask playerLayer;

    bool cond;


    private void OnEnable()
    {
        Invoke(nameof(InitializeWanderState), 0.1f);
        Granny_EventManager.OnGrannyAngry += Granny_EventManager_OnGrannyAngry;
        Granny_Detection.OnPunchHitGranny += Granny_Detection_OnPunchHitGranny;
        Granny_Detection.OnFireBulletHitGranny += Granny_Detection_OnFireBulletHitGranny;
        Granny_Detection.OnBeeBulletHitGranny += Granny_Detection_OnBeeBulletHitGranny;
        Granny_Detection.OnShockBulletHitGranny += Granny_Detection_OnShockBulletHitGranny;
        Granny_Animator.ChangeStateWanderToChase += Granny_Animator_ChangeStateWanderToChase;
    }

    private void Granny_Animator_ChangeStateWanderToChase()
    {
        granny_StateMachine.Initialize(new Granny_ChaseState(this, granny_StateMachine, grannyAnimator));
    }

    void InitializeWanderState()
    {
        granny_StateMachine.Initialize(new Granny_WanderState(this, granny_StateMachine, grannyAnimator));
    }

    private void OnDestroy()
    {
        Granny_EventManager.OnGrannyAngry -= Granny_EventManager_OnGrannyAngry;
        Granny_Detection.OnPunchHitGranny -= Granny_Detection_OnPunchHitGranny;
        Granny_Detection.OnFireBulletHitGranny -= Granny_Detection_OnFireBulletHitGranny;
        Granny_Detection.OnBeeBulletHitGranny -= Granny_Detection_OnBeeBulletHitGranny;
        Granny_Detection.OnShockBulletHitGranny -= Granny_Detection_OnShockBulletHitGranny;
        Granny_Animator.ChangeStateWanderToChase -= Granny_Animator_ChangeStateWanderToChase;
    }
    
    private void Start()
    {

        navMeshAgent = GetComponent<NavMeshAgent>();


        granny_StateMachine = gameObject.GetComponent<Granny_StateMachine>();


    }



    private void Granny_EventManager_OnGrannyAngry()
    {
        granny_StateMachine.ChangeState(new Granny_ChaseState(this, granny_StateMachine, grannyAnimator));
    }


    public void WaitAtPoint()
    {
        StopAgent();
    }
    void StopAgent()
    {
        EnemyCannotMove();
        grannyAnimator.m_Animator.SetLayerWeight(1, 1f);
        Invoke(nameof(ResumeAgent), 4f);
    }

    void ResumeAgent()
    {
        grannyAnimator.m_Animator.SetLayerWeight(1, 0f);
        EnemyCanMove();
    }

    public void UpdateWalkAnimation()
    {

        if (grannyAnimator == null)
        {
            Debug.LogWarning("Granny Animator script is not present");
        }
        if (grannyAnimator.m_Animator != null)
        {
            grannyAnimator.m_Animator.SetFloat("Speed", navMeshAgent.velocity.magnitude);
        }
        else
        {
            Debug.LogError("Can't access memeber of Granny Animator");
        }
    }

    public bool CanAttackCat()
    {
        return Vector3.Distance(transform.position, catTransform.position) < minDisToAttackCat;
    }


    public bool IsCatTooFar(float distanceThreshold)
    {
        float distanceToCat = Vector3.Distance(transform.position, catTransform.position);
        return distanceToCat > distanceThreshold;
    }

    public void ResetGrannyStateToWandering()
    {
        grannyAnimator.ResetAnimatorToWander();
        navMeshAgent.ResetPath();

        if (navMeshAgent.velocity.sqrMagnitude > 0.1f)
        {
            Quaternion targetRotation = Quaternion.LookRotation(navMeshAgent.velocity.normalized);
            transform.rotation = targetRotation;
        }

        granny_StateMachine.ChangeState(new Granny_WanderState(this, granny_StateMachine, grannyAnimator));
    }


    public void ChaseCat()
    {
        if (catTransform == null || navMeshAgent == null)
        {
            Debug.Log("Cat transform or NavMeshAgent is not assigned!");
            return;
        }

        EnemyCanMove();
        navMeshAgent.isStopped = false;
        navMeshAgent.SetDestination(catTransform.position);
        Debug.Log("Enemy is chasing cat");
    }

    public void AttackCat()
    {
        navMeshAgent.ResetPath();
        EnemyCannotMove();
        RotateAwayFromTarget();
        grannyAnimator.AttackCat();
    }

    public void EnemyCanMove()
    {
        navMeshAgent.isStopped = false;
    }
    public void EnemyCannotMove()
    {
        navMeshAgent.isStopped = true;
    }

    public void WaitAtHitObject()
    {
        EnemyCannotMove();
        Invoke((nameof(CanStartChaseAfterHit)), 3.24f);
    }

    public bool CanStartChaseAfterHit()
    {
        return cond;
    }

    void Settrue()
    {
        cond = true;
    }

    public void RotateAwayFromTarget()
    {
        StartCoroutine(RotateSmoothly(catTransform));
    }

    private IEnumerator RotateSmoothly(Transform target)
    {
        if (target == null) yield break;

        Quaternion startRotation = transform.rotation;
        Vector3 directionToTarget = (target.position - transform.position).normalized;
        Quaternion targetRotation = Quaternion.LookRotation(directionToTarget);

        float duration = 0.5f;
        float elapsedTime = 0f;

        while (elapsedTime < duration)
        {
            transform.rotation = Quaternion.Slerp(startRotation, targetRotation, elapsedTime / duration);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        transform.rotation = targetRotation;
    }

    private void Granny_Detection_OnShockBulletHitGranny()
    {
        grannyAnimator.TriggerShock();
    }

    private void Granny_Detection_OnBeeBulletHitGranny()
    {
        grannyAnimator.TriggerBee();
    }

    private void Granny_Detection_OnFireBulletHitGranny()
    {
        grannyAnimator.TriggerFire();
    }

    private void Granny_Detection_OnPunchHitGranny()
    {
        grannyAnimator.TriggerPunch();
    }

    
}

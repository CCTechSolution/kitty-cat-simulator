
using System;
using UnityEngine;

public class Granny_Animator : MonoBehaviour
{
    public Animator m_Animator;
    [SerializeField] Granny grannyController;
    public static event Action ChangeStateWanderToChase;

    public GameObject beeVfx;
    public GameObject shockVfx;
    public GameObject fireVfx;

    public void AttackCat()
    {
        m_Animator.SetBool("Attack", true);
        m_Animator.SetBool("Anger", false);
    }

    public void GetsAngry()
    {
        m_Animator.SetBool("Anger", true);
        m_Animator.SetBool("ReturnWander", false);
    }
    public void ResetAnimatorToWander()
    {
        m_Animator.SetBool("Attack", false);
        m_Animator.SetBool("Anger", false);
        m_Animator.SetBool("ReturnWander", true);
    }

    public void CheckNextAfterAnger()
    {
        if (grannyController.CanAttackCat())
        {
            m_Animator.SetBool("Attack", true);
        }
        else
        {
            m_Animator.SetBool("Anger", false);
        }
    }

    public void ChaseToWander()
    {
        m_Animator.SetBool("ReturnWander", true);
    }
    public void GameFail()
    {
        GameEventManager.Instance.LevelFail();
    }

    public void TriggerFire()
    {
        m_Animator.SetTrigger("Fire");
    }
    public void TriggerPunch()
    {
        m_Animator.SetTrigger("Punch");
    }
    public void TriggerShock()
    {
        m_Animator.SetTrigger("Shock");
    }
    public void TriggerBee()
    {
        m_Animator.SetTrigger("Bee");
    }
    public void ChaseAfterSpecialAttack()
    {
        m_Animator.ResetTrigger("Fire");
        m_Animator.ResetTrigger("Punch");
        m_Animator.ResetTrigger("Shock");
        m_Animator.ResetTrigger("Bee");
        m_Animator.SetTrigger("ReturnSpecial");
        ChangeStateWanderToChase?.Invoke();

    }


    public void Enable_FireVfxGameobject()
    {
        fireVfx.SetActive(true);
    }
    public void Enable_BeeVfxGameobject()
    {
        beeVfx.SetActive(true);
    }
    public void Enable_ShockVfxGameobject()
    {
        shockVfx.SetActive(true);
    }
}

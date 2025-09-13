using UnityEngine;

public class SpecialAttackManager : MonoBehaviour
{
    [Header("Buttons")]
    public GameObject punchButton;
    public GameObject shockButton;
    public GameObject fireButton;
    public GameObject beeButton;

    [Space(10)]
    [Header("Weapons")]
    public GameObject punchRod;
    public GameObject Gun;



    [Space(10)]
    public Animator punchGloveAnimator;
    public GunBulletThrower gunBulletThrower;

    private void OnEnable()
    {
        PlayerCollisionEvents.OnPunchTrigger += PlayerCollisionEvents_OnPunchTrigger;
        PlayerCollisionEvents.OnShockTrigger += PlayerCollisionEvents_OnShockTrigger;
        PlayerCollisionEvents.OnFireTrigger += PlayerCollisionEvents_OnFireTrigger;
        PlayerCollisionEvents.OnBeeTrigger += PlayerCollisionEvents_OnBeeTrigger;
    }



    private void OnDisable()
    {
        PlayerCollisionEvents.OnPunchTrigger -= PlayerCollisionEvents_OnPunchTrigger;
        PlayerCollisionEvents.OnShockTrigger -= PlayerCollisionEvents_OnShockTrigger;
        PlayerCollisionEvents.OnFireTrigger += PlayerCollisionEvents_OnFireTrigger;
        PlayerCollisionEvents.OnBeeTrigger += PlayerCollisionEvents_OnBeeTrigger;
    }


    private void PlayerCollisionEvents_OnPunchTrigger()
    {
        if (!punchRod.activeSelf && !Gun.activeSelf) // Check if both are inactive
        {
            punchButton.SetActive(true);
            punchRod.SetActive(true);
            if (Sfx_Manager.Instance)
            {
                Sfx_Manager.PlayRandomSound(Sfx_Manager.Instance.diamondCollect);
            }
        }
    }

    private void PlayerCollisionEvents_OnShockTrigger()
    {
        if (!punchRod.activeSelf && !Gun.activeSelf) // Check if both are inactive
        {
            shockButton.SetActive(true);
            Gun.SetActive(true);
            if (Sfx_Manager.Instance)
            {
                Sfx_Manager.PlayRandomSound(Sfx_Manager.Instance.diamondCollect);
            }
        }
    }
    private void PlayerCollisionEvents_OnFireTrigger()
    {
        if (!punchRod.activeSelf && !Gun.activeSelf) // Check if both are inactive
        {
            fireButton.SetActive(true);
            Gun.SetActive(true);
            if (Sfx_Manager.Instance)
            {
                Sfx_Manager.PlayRandomSound(Sfx_Manager.Instance.diamondCollect);
            }
        }
    }

    private void PlayerCollisionEvents_OnBeeTrigger()
    {
        if (!punchRod.activeSelf && !Gun.activeSelf) // Check if both are inactive
        {
            beeButton.SetActive(true);
            Gun.SetActive(true);
            if (Sfx_Manager.Instance)
            {
                Sfx_Manager.PlayRandomSound(Sfx_Manager.Instance.diamondCollect);
            }
        }
    }

    public void OnPunchButtonPressed()
    {
        punchButton.SetActive(false);
        punchGloveAnimator.SetTrigger("Punch");
    }
    public void OnShockButtonPressed()
    {
        shockButton.SetActive(false);
        gunBulletThrower.ShootShockBullet();
        Gun.SetActive(false);
    }

    public void OnFireButtonPressed()
    {
        fireButton.SetActive(false);
        gunBulletThrower.ShootFireBullet();
        Gun.SetActive(false);
    }

    public void OnBeeButtonPressed()
    {
        beeButton.SetActive(false);
        gunBulletThrower.ShootBeeBUllet();
        Gun.SetActive(false);
    }






}

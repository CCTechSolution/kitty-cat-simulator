using UnityEngine;

public class GrannyBeeAttackObjective : BaseObjective
{
    float time;
    public float totalTimerAfterFireBullet;
    bool startTimer;
    public GameObject[] indicatorForObjective;
    protected override void RegisterEvent()
    {
        Granny_Detection.OnBeeBulletHitGranny += Timer;
        GameEventManager.OnLevelFail += GrannyHitCat;
        ToggleIndicators(indicatorForObjective, true);
    }

    protected override void UnregisterEvent()
    {
        Granny_Detection.OnBeeBulletHitGranny -= Timer;
        GameEventManager.OnLevelFail -= GrannyHitCat;
    }
    private void OnDisable()
    {
        ToggleIndicators(indicatorForObjective, false);
    }
    void Timer()
    {
        startTimer = true;
    }

    private void Update()
    {
        if (startTimer)
        {
            time += Time.deltaTime;
            if (time >= totalTimerAfterFireBullet)
            {
                Success();
                time = 0;
                startTimer = false;
            }
        }
    }

    void GrannyHitCat()
    {
        startTimer = false;
        time = 0f;
    }
}

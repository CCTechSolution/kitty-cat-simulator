using UnityEngine;

public class FootBallObjective : BaseObjective
{
    [SerializeField]GameObject[] IndiacatorsGameObjects;
    protected override void RegisterEvent()
    {
        ToggleIndicators(IndiacatorsGameObjects, true);
        FootballGoalTrigger.OnFootballEnterGoal += Success;
    }
    protected override void ExtrasWithSuccess()
    {
        if (Sfx_Manager.Instance)
        {
            Sfx_Manager.PlayRandomSound(Sfx_Manager.Instance.goalSound);
        }
    }
    protected override void UnregisterEvent()
    {

        FootballGoalTrigger.OnFootballEnterGoal -= Success;
    }

    private void OnDisable()
    {
        ToggleIndicators(IndiacatorsGameObjects, false);
    }
}

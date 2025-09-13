using UnityEngine;

public class PunchObjective : BaseObjective
{
    [SerializeField] GameObject[] IndiacatorsGameObjects;
    protected override void RegisterEvent()
    {
        ToggleIndicators(IndiacatorsGameObjects,true);
    }

    protected override void UnregisterEvent()
    {
        ToggleIndicators(IndiacatorsGameObjects, false);
    }
}

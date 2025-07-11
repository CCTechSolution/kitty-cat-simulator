using UnityEngine;

public class BreakItemsObjective : BaseObjective
{
    [SerializeField] GameObject[] IndiacatorsGameObjects;
    protected override void RegisterEvent()
    {
        Breakable_Item.OnItemBreak += Success;
        ToggleIndicators(IndiacatorsGameObjects, true);
    }

    protected override void UnregisterEvent()
    {
        Breakable_Item.OnItemBreak -= Success;       
    }

    private void OnDisable()
    {
        ToggleIndicators(IndiacatorsGameObjects, false);
    }
}

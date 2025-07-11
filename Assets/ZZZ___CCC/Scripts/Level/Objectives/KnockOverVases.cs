
using System.Collections.Generic;
using UnityEngine;

public class KnockOverVases : BaseObjective
{

    [SerializeField] GameObject[] IndiacatorsGameObjects;
    protected override void RegisterEvent()
    {
        Grabable_Item.OnVaseHit += Success;
        ToggleIndicators(IndiacatorsGameObjects, true);
    }

    protected override void UnregisterEvent()
    {
        Grabable_Item.OnVaseHit -= Success;
        
    }
    private void OnDisable()
    {
        ToggleIndicators(IndiacatorsGameObjects, false);
    }


}

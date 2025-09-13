using System.Collections.Generic;
using UnityEngine;

public class ThrowKitchenObjects : BaseObjective
{

    [SerializeField] GameObject[] IndiacatorsGameObjects;
    protected override void RegisterEvent()
    {
        Grabable_Item.OnPotHit += Success;
        ToggleIndicators(IndiacatorsGameObjects, true);
    }

    protected override void UnregisterEvent()
    {
        Grabable_Item.OnPotHit -= Success;
       
    }
    private void OnDisable()
    {
        ToggleIndicators(IndiacatorsGameObjects, false);
    }
}

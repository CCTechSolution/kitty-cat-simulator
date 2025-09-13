using System.Collections.Generic;
using UnityEngine;

public class CoffeeAtGranny : BaseObjective
{
    [SerializeField] GameObject[] indicatorsGameobject;
    protected override void RegisterEvent()
    {
        Granny_Detection.OnCoffeeHitGranny += Success;
        SetWayPoints.Instance.ToKitchen();
        ToggleIndicators(indicatorsGameobject, true);
    }

    protected override void UnregisterEvent()
    {
        Granny_Detection.OnCoffeeHitGranny -= Success;
    }

    private void OnDisable()
    {
        ToggleIndicators(indicatorsGameobject, true);
    }
}

using System.Collections.Generic;
using UnityEngine;

public class CollectDiamonds2 : BaseObjective
{


    [SerializeField] GameObject diamondsParent;
    [SerializeField] EnableAllChildGameobjects diamondParentToEnableChild;
    protected override void RegisterEvent()
    {
        PlayerCollisionEvents.OnDiamondHit += Success;
        if (diamondsParent != null)
        {
            diamondsParent.SetActive(true);
        }
        SetWayPoints.Instance.ToKitchen();
    }
    protected override void OnRetry()
    {
        diamondParentToEnableChild.EnableAll();
    }
    protected override void ExtrasWithSuccess()
    {
        UI_Manager.Instance.AddDiamond(10);
    }

    protected override void UnregisterEvent()
    {
        PlayerCollisionEvents.OnDiamondHit -= Success;
        
    }

    private void OnDisable()
    {
        if (diamondsParent != null)
        {
            diamondsParent.SetActive(false);
        }
    }
}

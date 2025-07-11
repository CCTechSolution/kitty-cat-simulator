using System.Collections.Generic;
using UnityEngine;

public class CollectDiamonds3 : BaseObjective
{


    [SerializeField] GameObject diamondsParent;

    protected override void RegisterEvent()
    {
        PlayerCollisionEvents.OnDiamondHit += Success;
        if (diamondsParent != null)
        {
            diamondsParent.SetActive(true);
        }
        SetWayPoints.Instance.ToSecondFloorHalf();
        CatGranPos.Instance.InSecondFloor();
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

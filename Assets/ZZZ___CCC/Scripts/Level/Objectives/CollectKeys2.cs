using System.Collections.Generic;
using UnityEngine;

public class CollectKeys2 : BaseObjective
{
    [SerializeField] GameObject keysParent;
    [SerializeField] EnableAllChildGameobjects keys2ParentToEnableChild;

    protected override void RegisterEvent()
    {
        PlayerCollisionEvents.OnKeyHit += Success;
        if (keysParent != null)
        {
            keysParent.SetActive(true);
        }
        SetWayPoints.Instance.ToSecondFloorHalf();
        CatGranPos.Instance.InSecondFloor();
    }
    protected override void OnRetry()
    {
        keys2ParentToEnableChild.EnableAll();
    }
    protected override void ExtrasWithSuccess()
    {
        UI_Manager.Instance.AddKey(10);
    }

    protected override void UnregisterEvent()
    {
        PlayerCollisionEvents.OnKeyHit -= Success;
        
    }

    private void OnDisable()
    {
        if (keysParent != null)
        {
            keysParent.SetActive(false);
        }
    }
}

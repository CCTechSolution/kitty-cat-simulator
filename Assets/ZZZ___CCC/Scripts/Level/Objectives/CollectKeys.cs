using System.Collections.Generic;
using UnityEngine;

public class CollectKeys : BaseObjective
{

    [SerializeField] GameObject keysParent;
    [SerializeField] EnableAllChildGameobjects keysParentToEnableChild;

    protected override void RegisterEvent()
    {
        PlayerCollisionEvents.OnKeyHit += Success;
        if (keysParent != null)
        {
            keysParent.SetActive(true);
        }
        SetWayPoints.Instance.ToKitchen();
        CatGranPos.Instance.InLivingRoom1stFloor();
    }
    protected override void OnRetry()
    {
        keysParentToEnableChild.EnableAll();
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

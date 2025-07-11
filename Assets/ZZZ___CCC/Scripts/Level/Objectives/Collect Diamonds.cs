using System.Collections.Generic;
using UnityEngine;

public class CollectDiamonds : BaseObjective
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

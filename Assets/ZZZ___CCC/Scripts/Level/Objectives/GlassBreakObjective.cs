using UnityEngine;

public class GlassBreakObjective : BaseObjective
{
    [SerializeField] GameObject[] indicators;
    protected override void RegisterEvent()
    {
        Grabable_Item.OnCupHit += Success;
        Grabable_Item.OnGlassHit+= Success;
        ToggleIndicators(indicators, true);
    }

    protected override void UnregisterEvent()
    {
        Grabable_Item.OnCupHit -= Success;
        Grabable_Item.OnGlassHit -= Success;
    }

    private void OnDisable()
    {
        ToggleIndicators(indicators, false);
    }
}

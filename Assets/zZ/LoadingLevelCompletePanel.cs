using UnityEngine;
using UnityEngine.Events;

public class LoadingLevelCompletePanel : MonoBehaviour
{
    public UnityEvent CallAdsHere;
    public UnityEvent OnLoadingEnd;

    public void ForAds()
    {
        CallAdsHere?.Invoke();
    }

    public void LoadingComplete()
    {
        OnLoadingEnd?.Invoke();  
    }
}

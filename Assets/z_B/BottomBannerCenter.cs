using GoogleMobileAds.Api;
using UnityEngine;

public class BottomBannerCenter : MonoBehaviour
{
    void LoadShow()
    {
        if (AdmobAdsManager.Instance)
            AdmobAdsManager.Instance.Btn_Show_Bottom(AdPosition.Bottom);
    }

    void Hide()
    {
        if (AdmobAdsManager.Instance)
            AdmobAdsManager.Instance.Btn_Hide_Bottom();
    }

    private void OnEnable()
    {
        LoadShow();
    }
    private void OnDisable()
    {
        Hide();
    }
}

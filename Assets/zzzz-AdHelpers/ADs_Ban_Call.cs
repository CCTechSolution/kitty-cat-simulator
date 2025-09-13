using UnityEngine;
using GoogleMobileAds.Api;

public class ADs_Ban_Call : MonoBehaviour
{
    public bool Bottom;
    public bool Bottom_Right;
    public bool Off;


    void OnEnable()
    {
        if (PlayerPrefs.GetInt("Shop") == 1)
        {
            // ADs Off
        }
        else
        {
            //call_hide();
            Invoke(nameof(call_load), 0.1269f);
            //call_load();
        }
    }

    void OnDisable()
    {
        call_hide();
    }

    void call_load()
    {
        if (Bottom == true)
        {
            if (AdmobAdsManager.Instance)
                AdmobAdsManager.Instance.Btn_Show_Bottom(AdPosition.Bottom);
        }
        if (Bottom_Right == true)
        {
            if (AdmobAdsManager.Instance)
                AdmobAdsManager.Instance.Btn_Show_Bottom(AdPosition.BottomRight);
        }
    }

    //void call_show()
    //{
    //    if (Bottom == true)
    //    {
    //        AdmobAdsManager.Instance.Btn_Show_Bottom(AdPosition.Bottom);
    //    }
    //    if (Bottom_Right == true)
    //    {
    //        AdmobAdsManager.Instance.Btn_Show_Bottom(AdPosition.BottomRight);
    //    }
    //}

    void call_hide()
    {
        if (Bottom == true)
        {
            if(AdmobAdsManager.Instance)
                AdmobAdsManager.Instance.Btn_Hide_Bottom();
        }
        if (Bottom_Right == true)
        {
            if (AdmobAdsManager.Instance)
                AdmobAdsManager.Instance.Btn_Hide_Bottom();
        }
        if (Off == true)
        {
            if (AdmobAdsManager.Instance)
                AdmobAdsManager.Instance.Btn_Hide_Bottom();
        }
    }
}
using UnityEngine;
using UnityEngine.UI;

public class new_AD_Call : MonoBehaviour
{
    public int Total_Coins;
    string Coin_Call;
    int Coin;
    public Text[] All_Coin;
    public bool AdoptiveBanner;
    public bool MedRec;
    public bool Interstitial;
    public bool Rew_AD;

    [Header(" . . . Loading . . . ")]
    public bool Load_Ban;
    public bool Load_Med_Rec;
    public bool Load_Rew;
    public bool Load_Int;

    [Header("Reward")]
    public GameObject Reward;
    public bool Game_Pannel;

    [Header(" . . . GamePlay . . . ")]
    public bool Fight;
    public bool Shoot_Transform;

    void OnEnable()
    {
 
        if (AdoptiveBanner == true)
        {
            bann();
        }
        if (MedRec == true)
        {
            mrban();
        }
        if (Interstitial == true)
        {
            AdmobAdsManager.Instance.LoadInterstitial();
            CallShow();
        }
        loAd();
    }

    void CallShow()
    {
        Invoke(nameof(ShowInterstitialAd), 5f);
    }
    void OnDisable()
    {
        if (Interstitial == true)
        {
            AdmobAdsManager.Instance.LoadInterstitial();
        }
        if (MedRec == true)
        {
            AdmobAdsManager.Instance.hideMediumBanner();
        }

        //Data.SaveData();
    }

    public void InT_Now()
    {
        //MUBARIZ

        //MaxAdsManager.Instance.Btn_LS_Int();
    }
    public void MRec_Now()
    {
        mrban();
    }
    void loAd()
    {
        if (Load_Ban == true)
        {
            bann();
        }
    }
   

    void Chk_Coins()
    {

    }

    void ShowInterstitialAd()
    {
        AdmobAdsManager.Instance.ShowInterstitial();
    }


    void bann()
    {
        load_bann();
        if (AdmobAdsManager.Instance.Internet == true)
        {
            AdmobAdsManager.Instance.ShowSmallBanner();
        }
    }


    void load_bann()
    {
        if (AdmobAdsManager.Instance)
            if (AdmobAdsManager.Instance.Internet == true)
            {
                if (!AdmobAdsManager.Instance.IsSmallBannerReady())
                {
                    AdmobAdsManager.Instance.LoadSmallBanner();
                }
            }
    }


    void mrban()
    {
        if (AdmobAdsManager.Instance)
            if (AdmobAdsManager.Instance.Internet == true)
            {
                AdmobAdsManager.Instance.ShowMediumBanner();
            }
    }


}
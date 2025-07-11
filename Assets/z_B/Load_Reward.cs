using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class Load_Reward : MonoBehaviour
{
    public float tIme = 6f;
    public GameObject This_P, Next_P;
    public bool AD;
    public GameObject AD_NAtive;
    void OnEnable()
    {
        if (Application.internetReachability == NetworkReachability.ReachableViaCarrierDataNetwork || Application.internetReachability == NetworkReachability.ReachableViaLocalAreaNetwork)
        {

            /////////////////////////////////// 
            /// 
            ///       COOMENTED ADS
            /// 
            ///////////////////////////////////

            if (PlayerPrefs.GetInt("unlockeverything") == 0)
            {
                //AdmobAdsManager.Instance?.LoadInterstitial();
                task2();
                Invoke(nameof(chk), tIme);
            }
            else
            {
                skip();
            }

        }
        else
        {
            skip();
        }
       
    }

    /////////////////////////////////// 
    /// 
    ///       COOMENTED ADS
    /// 
    ///////////////////////////////////
    void task1()
    {
        //AdmobAdsManager.Instance?.ShowInterstitial();
    }
    void task2()
    {
        //AdmobAdsManager.Instance?.ShowMediumBanner(GoogleMobileAds.Api.AdPosition.BottomLeft);
        AD = true;
    }
    void chk()
    {
        if (AD == true)
        {
            //AdmobAdsManager.Instance?.hideMediumBanner();
        }
        task1();
        This_P.SetActive(false);
        if (Next_P != null)
        {
            Next_P.SetActive(true);
        }
    }
    void skip()
    {
        This_P.SetActive(false);
        if (Next_P != null)
        {
            Next_P.SetActive(true);
        }
    }
    void OnDisable()
    {
        AD = false;
        if(AD_NAtive!=null)
        {
            AD_NAtive.SetActive(true);
        }
    }
}
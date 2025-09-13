using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PreferenceManager
{
    const string Subscription = "Subscription";
    const string _RewardType = "RewardType";
    const string RemoveAds = "RemoveAds";

    public static bool GetAdsStatus()
    {
        //0 means ads enabled and 1 means ads are disabled. so true means ads are enabled and false means ads are disabled.

        if (SubscriptionStatus != 0)
        {
            return false;
        }

        return (PlayerPrefs.GetInt(RemoveAds, 0) == 0);
    }

    public static void SetAdsStatus(int value)
    {
        PlayerPrefs.SetInt(RemoveAds, value);
    }

    public static int SubscriptionStatus
    {
        get
        {
            //return 1;
            return PlayerPrefs.GetInt(Subscription, 0);
        }
        set
        {
            PlayerPrefs.SetInt(Subscription, value);
        }
    }

    //public static void SetRewardStatus(RewardType reward)
    //{
    //    PlayerPrefs.SetInt(_RewardType, (int)reward);
        
    //}
    public static int GetRewardStatus()
    {
        return PlayerPrefs.GetInt(_RewardType);
    }
}

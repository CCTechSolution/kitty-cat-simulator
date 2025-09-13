using UnityEngine;
//using Facebook.Unity;

public static class Logging
{

    static public void Log(object message)
    {
        UnityEngine.Debug.Log(message);

    }
}
public class AdmobGA_Helper : MonoBehaviour
{
    public static void GA_Log(AdmobGAEvents log)
    {

        switch (log)
        {
            //Initalizing
            case AdmobGAEvents.Initializing:
                LogGAEvent("Admob_Initializing");
                break;
            case AdmobGAEvents.Initialized:
                LogGAEvent("Admob_Initialized");
                break;

            //Request
            case AdmobGAEvents.LoadInterstitialHighAd:
                LogGAEvent("Admob_iAd_Request_H_Ecpm");
                break;
            case AdmobGAEvents.LoadInterstitialMediumAd:
                LogGAEvent("Admob_iAd_Request_M_Ecpm");
                break;
            case AdmobGAEvents.LoadInterstitialLowAd:
                LogGAEvent("Admob_iAd_Request_L_Ecpm");
                break;

            case AdmobGAEvents.LoadVideoAd_High_ECPM:
                LogGAEvent("Admob_vAd_Request_H_Ecpm");
                break;
            case AdmobGAEvents.LoadVideoAd_Medium_ECPM:
                LogGAEvent("Admob_vAd_Request_M_Ecpm");
                break;
            case AdmobGAEvents.LoadVideoAd_Low_ECPM:
                LogGAEvent("Admob_vAd_Request_L_Ecpm");
                break;
            case AdmobGAEvents.LoadRewardedAd_H_Ecpm:
                LogGAEvent("Admob_rAd_Request_H_Ecpm");
                break;
            case AdmobGAEvents.LoadRewardedAd_M_Ecpm:
                LogGAEvent("Admob_rAd_Request_M_Ecpm");
                break;
            case AdmobGAEvents.LoadRewardedAd_L_Ecpm:
                LogGAEvent("Admob_rAd_Request_L_Ecpm");
                break;
            case AdmobGAEvents.LoadSmallBanner_H_Ecpm:
                LogGAEvent("Admob_SB_Request_H_Ecpm");
                break;
            case AdmobGAEvents.LoadSmallBanner_M_Ecpm:
                LogGAEvent("Admob_SB_Request_M_Ecpm");
                break;
            case AdmobGAEvents.LoadSmallBanner_L_Ecpm:
                LogGAEvent("Admob_SB_Request_L_Ecpm");
                break;
            case AdmobGAEvents.LoadSmallAdaptiveBanner_H_Ecpm:
                LogGAEvent("Admob_AB_Request_H_Ecpm");
                break;
            case AdmobGAEvents.LoadSmallAdaptiveBanner_M_Ecpm:
                LogGAEvent("Admob_AB_Request_M_Ecpm");
                break;
            case AdmobGAEvents.LoadSmallAdaptiveBanner_L_Ecpm:
                LogGAEvent("Admob_AB_Request_L_Ecpm");
                break;
            case AdmobGAEvents.LoadSmallSmartBanner_H_Ecpm:
                LogGAEvent("Admob_SMB_Request_H_Ecpm");
                break;
            case AdmobGAEvents.LoadSmallSmartBanner_M_Ecpm:
                LogGAEvent("Admob_SMB_Request_M_Ecpm");
                break;
            case AdmobGAEvents.LoadSmallSmartBanner_L_Ecpm:
                LogGAEvent("Admob_SMB_Request_L_Ecpm");
                break;
            case AdmobGAEvents.LoadMediumBanner_H_Ecpm:
                LogGAEvent("Admob_MB_Request_H_Ecpm");
                break;
            case AdmobGAEvents.LoadMediumBanner_M_Ecpm:
                LogGAEvent("Admob_MB_Request_M_Ecpm");
                break;
            case AdmobGAEvents.LoadMediumBanner_L_Ecpm:
                LogGAEvent("Admob_MB_Request_L_Ecpm");
                break;

            //LOADED
            case AdmobGAEvents.InterstitialAdLoadedHigh:
                LogGAEvent("Admob_iAd_Loaded_H_Ecpm");
                break;
            case AdmobGAEvents.InterstitialAdLoadedMedium:
                LogGAEvent("Admob_iAd_Loaded_M_Ecpm");
                break;
            case AdmobGAEvents.InterstitialAdLoadedLow:
                LogGAEvent("Admob_iAd_Loaded_L_Ecpm");
                break;
            case AdmobGAEvents.VideoAdLoaded_H_ECPM:
                LogGAEvent("Admob_vAd_Loaded_H_ECPM");
                break;
            case AdmobGAEvents.VideoAdLoaded_M_ECPM:
                LogGAEvent("Admob_vAd_Loaded_M_ECPM");
                break;
            case AdmobGAEvents.VideoAdLoaded_L_ECPM:
                LogGAEvent("Admob_vAd_Loaded_L_ECPM");
                break;
            case AdmobGAEvents.RewardedAdLoaded_H_Ecpm:
                LogGAEvent("Admob_rAd_Loaded_H_Ecpm");
                break;
            case AdmobGAEvents.SmallBannerLoaded_H_Ecpm:
                LogGAEvent("Admob_SB_Loaded_H_Ecpm");
                break;
            case AdmobGAEvents.SmallBannerLoaded_M_Ecpm:
                LogGAEvent("Admob_SB_Loaded_M_Ecpm");
                break;
            case AdmobGAEvents.SmallBannerLoaded_L_Ecpm:
                LogGAEvent("Admob_SB_Loaded_L_Ecpm");
                break;
            case AdmobGAEvents.SmallAdaptiveBannerLoaded_H_Ecpm:
                LogGAEvent("Admob_AB_Loaded_H_Ecpm");
                break;
            case AdmobGAEvents.SmallAdaptiveBannerLoaded_M_Ecpm:
                LogGAEvent("Admob_AB_Loaded_M_Ecpm");
                break;
            case AdmobGAEvents.SmallAdaptiveBannerLoaded_L_Ecpm:
                LogGAEvent("Admob_AB_Loaded_L_Ecpm");
                break;
            case AdmobGAEvents.SmallSmartBannerLoaded_H_Ecpm:
                LogGAEvent("Admob_SMB_Loaded_H_Ecpm");
                break;
            case AdmobGAEvents.SmallSmartBannerLoaded_M_Ecpm:
                LogGAEvent("Admob_SMB_Loaded_M_Ecpm");
                break;
            case AdmobGAEvents.SmallSmartBannerLoaded_L_Ecpm:
                LogGAEvent("Admob_SMB_Loaded_L_Ecpm");
                break;
            case AdmobGAEvents.MediumBannerLoaded_H_Ecpm:
                LogGAEvent("Admob_MB_Loaded_H_Ecpm");
                break;
            case AdmobGAEvents.MediumBannerLoaded_M_Ecpm:
                LogGAEvent("Admob_MB_Loaded_M_Ecpm");
                break;
            case AdmobGAEvents.MediumBannerLoaded_L_Ecpm:
                LogGAEvent("Admob_MB_Loaded_L_Ecpm");
                break;

            //Show Call
            case AdmobGAEvents.ShowInterstitialAdHigh:
                LogGAEvent("Admob_iAd_ShowCall_H_Ecpm");
                break;
            case AdmobGAEvents.ShowInterstitialAdMedium:
                LogGAEvent("Admob_iAd_ShowCall_M_Ecpm");
                break;
            case AdmobGAEvents.ShowInterstitialAdLow:
                LogGAEvent("Admob_iAd_ShowCall_L_Ecpm");
                break;
            case AdmobGAEvents.ShowVideoAd_H_ECPM:
                LogGAEvent("Admob_vAd_ShowCall_H_Ecpm");
                break;
            case AdmobGAEvents.ShowVideoAd_M_ECPM:
                LogGAEvent("Admob_vAd_ShowCall_M_Ecpm");
                break;
            case AdmobGAEvents.ShowVideoAd_L_ECPM:
                LogGAEvent("Admob_vAd_ShowCall_L_Ecpm");
                break;
            case AdmobGAEvents.ShowRewardedAd_H_Ecpm:
                LogGAEvent("Admob_rAd_ShowCall_H_Ecpm");
                break;
            case AdmobGAEvents.ShowRewardedAd_M_Ecpm:
                LogGAEvent("Admob_rAd_ShowCall_M_Ecpm");
                break;
            case AdmobGAEvents.ShowRewardedAd_L_Ecpm:
                LogGAEvent("Admob_rAd_ShowCall_L_Ecpm");
                break;
            case AdmobGAEvents.ShowSmallBanner_H_Ecpm:
                LogGAEvent("Admob_SB_ShowCall_H_Ecpm");
                break;
            case AdmobGAEvents.ShowSmallBanner_M_Ecpm:
                LogGAEvent("Admob_SB_ShowCall_M_Ecpm");
                break;
            case AdmobGAEvents.ShowSmallBanner_L_Ecpm:
                LogGAEvent("Admob_SB_ShowCall_L_Ecpm");
                break;
            case AdmobGAEvents.ShowSmallAdaptiveBanner_H_Ecpm:
                LogGAEvent("Admob_AB_ShowCall_H_Ecpm");
                break;
            case AdmobGAEvents.ShowSmallAdaptiveBanner_M_Ecpm:
                LogGAEvent("Admob_AB_ShowCall_M_Ecpm");
                break;
            case AdmobGAEvents.ShowSmallAdaptiveBanner_L_Ecpm:
                LogGAEvent("Admob_AB_ShowCall_L_Ecpm");
                break;
            case AdmobGAEvents.ShowSmallSmartBanner_H_Ecpm:
                LogGAEvent("Admob_SMB_ShowCall_H_Ecpm");
                break;
            case AdmobGAEvents.ShowSmallSmartBanner_M_Ecpm:
                LogGAEvent("Admob_SMB_ShowCall_M_Ecpm");
                break;
            case AdmobGAEvents.ShowSmallSmartBanner_L_Ecpm:
                LogGAEvent("Admob_SMB_ShowCall_L_Ecpm");
                break;

            case AdmobGAEvents.ShowMediumBanner_H_Ecpm:
                LogGAEvent("Admob_MB_ShowCall_H_Ecpm");
                break;
            case AdmobGAEvents.ShowMediumBanner_M_Ecpm:
                LogGAEvent("Admob_MB_ShowCall_M_Ecpm");
                break;
            case AdmobGAEvents.ShowMediumBanner_L_Ecpm:
                LogGAEvent("Admob_MB_ShowCall_L_Ecpm");
                break;

            //Will Display
            case AdmobGAEvents.InterstitialAdWillDisplayHigh:
                LogGAEvent("Admob_iAd_WillDisplay_H_Ecpm");
                break;
            case AdmobGAEvents.InterstitialAdWillDisplayMedium:
                LogGAEvent("Admob_iAd_WillDisplay_M_Ecpm");
                break;
            case AdmobGAEvents.InterstitialAdWillDisplayLow:
                LogGAEvent("Admob_iAd_WillDisplay_L_Ecpm");
                break;
            case AdmobGAEvents.VideoAdWillDisplay_H_ECPM:
                LogGAEvent("Admob_vAd_WillDisplay_H_Ecpm");
                break;
            case AdmobGAEvents.VideoAdWillDisplay_M_ECPM:
                LogGAEvent("Admob_vAd_WillDisplay_M_Ecpm");
                break;
            case AdmobGAEvents.VideoAdWillDisplay_L_ECPM:
                LogGAEvent("Admob_vAd_WillDisplay_L_Ecpm");
                break;
            case AdmobGAEvents.RewardedAdWillDisplay_H_Ecpm:
                LogGAEvent("Admob_rAd_WillDisplay_H_Ecpm");
                break;
            case AdmobGAEvents.RewardedAdWillDisplay_M_Ecpm:
                LogGAEvent("Admob_rAd_WillDisplay_M_Ecpm");
                break;
            case AdmobGAEvents.RewardedAdWillDisplay_L_Ecpm:
                LogGAEvent("Admob_rAd_WillDisplay_L_Ecpm");
                break;

            //Displayed
            case AdmobGAEvents.InterstitialAdDisplayedHigh:
                LogGAEvent("Admob_iAd_Displayed_H_Ecpm");
                break;
            case AdmobGAEvents.InterstitialAdDisplayedMedium:
                LogGAEvent("Admob_iAd_Displayed_M_Ecpm");
                break;
            case AdmobGAEvents.InterstitialAdDisplayedLow:
                LogGAEvent("Admob_iAd_Displayed_L_Ecpm");
                break;

            case AdmobGAEvents.VideoAdDisplayed_H_ECPM:
                LogGAEvent("Admob_vAd_Displayed_H_Ecpm");
                break;
            case AdmobGAEvents.VideoAdDisplayed_L_ECPM:
                LogGAEvent("Admob_vAd_Displayed_L_Ecpm");
                break;
            case AdmobGAEvents.VideoAdDisplayed_M_ECPM:
                LogGAEvent("Admob_vAd_Displayed_M_Ecpm");
                break;

            case AdmobGAEvents.RewardedAdDisplayed_H_Ecpm:
                LogGAEvent("Admob_rAd_Displayed_H_Ecpm");
                break;
            case AdmobGAEvents.RewardedAdDisplayed_M_Ecpm:
                LogGAEvent("Admob_rAd_Displayed_M_Ecpm");
                break;
            case AdmobGAEvents.RewardedAdDisplayed_L_Ecpm:
                LogGAEvent("Admob_rAd_Displayed_L_Ecpm");
                break;
            case AdmobGAEvents.SmallBannerDisplayed_H_Ecpm:
                LogGAEvent("Admob_SB_Displayed_H_Ecpm");
                break;
            case AdmobGAEvents.SmallBannerDisplayed_M_Ecpm:
                LogGAEvent("Admob_SB_Displayed_M_Ecpm");
                break;
            case AdmobGAEvents.SmallBannerDisplayed_L_Ecpm:
                LogGAEvent("Admob_SB_Displayed_L_Ecpm");
                break;
            case AdmobGAEvents.SmallAdaptiveBannerDisplayed_H_Ecpm:
                LogGAEvent("Admob_AB_Displayed_H_Ecpm");
                break;
            case AdmobGAEvents.SmallAdaptiveBannerDisplayed_M_Ecpm:
                LogGAEvent("Admob_AB_Displayed_M_Ecpm");
                break;
            case AdmobGAEvents.SmallAdaptiveBannerDisplayed_L_Ecpm:
                LogGAEvent("Admob_AB_Displayed_L_Ecpm");
                break;
            case AdmobGAEvents.SmallSmartBannerDisplayed_H_Ecpm:
                LogGAEvent("Admob_SMB_Displayed_H_Ecpm");
                break;
            case AdmobGAEvents.SmallSmartBannerDisplayed_M_Ecpm:
                LogGAEvent("Admob_SMB_Displayed_M_Ecpm");
                break;
            case AdmobGAEvents.SmallSmartBannerDisplayed_L_Ecpm:
                LogGAEvent("Admob_SMB_Displayed_L_Ecpm");
                break;

            case AdmobGAEvents.MediumBannerDisplayed_H_Ecpm:
                LogGAEvent("Admob_MB_Displayed_H_Ecpm");
                break;
            case AdmobGAEvents.MediumBannerDisplayed_M_Ecpm:
                LogGAEvent("Admob_MB_Displayed_M_Ecpm");
                break;
            case AdmobGAEvents.MediumBannerDisplayed_L_Ecpm:
                LogGAEvent("Admob_MB_Displayed_L_Ecpm");
                break;

            //Rewarded Ad Started
            case AdmobGAEvents.RewardedAdStarted_H_ECPM:
                LogGAEvent("Admob_rAd_Started_H_Ecpm");
                break;
            case AdmobGAEvents.RewardedAdStarted_M_ECPM:
                LogGAEvent("Admob_rAd_Started_M_Ecpm");
                break;
            case AdmobGAEvents.RewardedAdStarted_L_ECPM:
                LogGAEvent("Admob_rAd_Started_L_Ecpm");
                break;

            //Rewarded Ad Give Reward
            case AdmobGAEvents.RewardedAdReward_H_ECPM:
                LogGAEvent("Admob_rAd_Reward_H_Ecpm");
                break;
            case AdmobGAEvents.RewardedAdReward_M_ECPM:
                LogGAEvent("Admob_rAd_Reward_M_Ecpm");
                break;

            case AdmobGAEvents.RewardedAdFailedToShow:
                LogGAEvent("Admob_rAd_RewardFailedToShow");
                break;

            //No Inventory
            case AdmobGAEvents.RewardedAdNoInventory_H_ECPM:
                LogGAEvent("Admob_rAd_NoInventory_H_Ecpm");
                break;
            case AdmobGAEvents.RewardedAdNoInventory_M_ECPM:
                LogGAEvent("Admob_rAd_NoInventory_M_Ecpm");
                break;
            case AdmobGAEvents.RewardedAdNoInventory_L_ECPM:
                LogGAEvent("Admob_rAd_NoInventory_L_Ecpm");
                break;

            case AdmobGAEvents.InterstitialAdNoInventoryHigh:
                LogGAEvent("Admob_iAd_NoInventory_H_Ecpm");
                break;
            case AdmobGAEvents.InterstitialAdNoInventoryMedium:
                LogGAEvent("Admob_iAd_NoInventory_M_Ecpm");
                break;
            case AdmobGAEvents.InterstitialAdNoInventorylow:
                LogGAEvent("Admob_iAd_NoInventory_L_Ecpm");
                break;
            case AdmobGAEvents.VideoAdNoInventory_H_ECPM:
                LogGAEvent("Admob_vAd_NoInventory_H_Ecpm");
                break;
            case AdmobGAEvents.VideoAdNoInventory_M_ECPM:
                LogGAEvent("Admob_vAd_NoInventory_M_Ecpm");
                break;
            case AdmobGAEvents.VideoAdNoInventory_L_ECPM:
                LogGAEvent("Admob_vAd_NoInventory_L_Ecpm");
                break;
            case AdmobGAEvents.SmallBannerNoInventory_H_Ecpm:
                LogGAEvent("Admob_SB_NoInventory_H_Ecpm");
                break;
            case AdmobGAEvents.SmallBannerNoInventory_M_Ecpm:
                LogGAEvent("Admob_SB_NoInventory_M_Ecpm");
                break;
            case AdmobGAEvents.SmallBannerNoInventory_L_Ecpm:
                LogGAEvent("Admob_SB_NoInventory_L_Ecpm");
                break;

            case AdmobGAEvents.SmallAdaptiveBannerNoInventory_H_Ecpm:
                LogGAEvent("Admob_AB_NoInventory_H_Ecpm");
                break;
            case AdmobGAEvents.SmallAdaptiveBannerNoInventory_M_Ecpm:
                LogGAEvent("Admob_AB_NoInventory_M_Ecpm");
                break;
            case AdmobGAEvents.SmallAdaptiveBannerNoInventory_L_Ecpm:
                LogGAEvent("Admob_AB_NoInventory_L_Ecpm");
                break;

            case AdmobGAEvents.SmallSmartBannerNoInventory_H_Ecpm:
                LogGAEvent("Admob_SMB_NoInventory_H_Ecpm");
                break;
            case AdmobGAEvents.SmallSmartBannerNoInventory_M_Ecpm:
                LogGAEvent("Admob_SMB_NoInventory_M_Ecpm");
                break;
            case AdmobGAEvents.SmallSmartBannerNoInventory_L_Ecpm:
                LogGAEvent("Admob_SMB_NoInventory_L_Ecpm");
                break;

            case AdmobGAEvents.MediumBannerNoInventory_H_Ecpm:
                LogGAEvent("Admob_MB_NoInventory_H_Ecpm");
                break;
            case AdmobGAEvents.MediumBannerNoInventory_M_Ecpm:
                LogGAEvent("Admob_MB_NoInventory_M_Ecpm");
                break;
            case AdmobGAEvents.MediumBannerNoInventory_L_Ecpm:
                LogGAEvent("Admob_MB_NoInventory_L_Ecpm");
                break;
            //Ad Close
            case AdmobGAEvents.InterstitialAdClosed_High_ECPM:
                LogGAEvent("Admob_iAd_Closed_H_Ecpm");
                break;
            case AdmobGAEvents.InterstitialAdClosed_Medium_ECPM:
                LogGAEvent("Admob_iAd_Closed_M_Ecpm");
                break;
            case AdmobGAEvents.InterstitialAdClosed_Low_ECPM:
                LogGAEvent("Admob_iAd_Closed_L_Ecpm");
                break;
            case AdmobGAEvents.VideoAdClosed_High_ECPM:
                LogGAEvent("Admob_vAd_Closed_H_Ecpm");
                break;
            case AdmobGAEvents.VideoAdClosed_Medium_ECPM:
                LogGAEvent("Admob_vAd_Closed_M_Ecpm");
                break;
            case AdmobGAEvents.VideoAdClosed_Low_ECPM:
                LogGAEvent("Admob_vAd_Closed_L_Ecpm");
                break;

            case AdmobGAEvents.RewardedAdClosed_H_ECPM:
                LogGAEvent("Admob_rAd_Closed_H_Ecpm");
                break;
            case AdmobGAEvents.RewardedAdClosed_M_ECPM:
                LogGAEvent("Admob_rAd_Closed_M_Ecpm");
                break;
            case AdmobGAEvents.RewardedAdClosed_L_ECPM:
                LogGAEvent("Admob_rAd_Closed_L_Ecpm");
                break;

            //Ad Clicked
            case AdmobGAEvents.InterstitialAdClicked:
                LogGAEvent("Admob_iAd_Clicked");
                break;
            case AdmobGAEvents.VideoAdClicked:
                LogGAEvent("Admob_vAd_Clicked");
                break;
            case AdmobGAEvents.RewardedAdClicked:
                LogGAEvent("Admob_rAd_Clicked");
                break;

            //Adapters Register
            case AdmobGAEvents.AdaptersInitialized:
                LogGAEvent("Admob_Adapters_Initialized");
                break;

            //Adapters Not Register
            case AdmobGAEvents.AdaptersNotInitialized:
                LogGAEvent("Admob_Adapters_NotInitialized");
                break;
            case AdmobGAEvents.InterstialOffline:
                Debug.Log("GG >> Admob_iad_ShowCall_Offline");

                break;


        }
    }

    public static void LogGAEvent(string log)
    {
        Debug.Log(log);
    }


}

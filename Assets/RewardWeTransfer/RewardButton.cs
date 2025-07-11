//using UnityEngine;

//public class RewardButton : MonoBehaviour
//{
//    public GameObject rewardPanel;
//    public GameObject currentRewardedGameobject;

//    private void Start()
//    {
//        Player_Detection.OnInteractWithRewardItem += Player_Detection_OnInteractWithRewardItem;
//    }

//    private void Player_Detection_OnInteractWithRewardItem(object sender, Player_Detection.RewardItemCarry e)
//    {
//        Debug.Log("reward gameobject interacted");
//        currentRewardedGameobject = e.rewardItem;

//    }

//    public void Btn_Reward()
//    {
//        rewardPanel.SetActive(true);
//    }


//    void ActionReward()
//    {
//        currentRewardedGameobject.layer = 6;
//        rewardPanel.SetActive(false);
//        AdmobAdsManager.Instance.RewardGranted();
//    }

//    public void LoadRewardAd()
//    {
//        if (AdmobAdsManager.Instance)
//        {
//            AdmobAdsManager.Instance.LoadRewardedVideo();
//        }
//    }

//    public void ShowReward()
//    {
//        if (AdmobAdsManager.Instance)
//        {
//            AdmobAdsManager.Instance.ShowRewardedVideo(ActionReward);
//        }
//    }
//}




using UnityEngine;
using UnityEngine.UI;

public class ModesAd : MonoBehaviour
{
    [SerializeField] GameObject modeSelectionGameobject;
    [SerializeField] GameObject loadingPanelGameobject;
    [SerializeField] Text coinsText;
    [SerializeField] GameObject notEnoughCoinsPanelPet;
    [SerializeField] GameObject notEnoughCoinsPanelGran;
    public int totalCoins;

    private void OnEnable()
    {
        totalCoins = PlayerPrefs.GetInt("Diamonds", 0);
        UpdateCoins(totalCoins);
    }
    public void func(int a)
    {
        

    }

    void UpdateCoins(int coins)
    {
        coinsText.text = coins.ToString();
    }
    void Call()
    {
        modeSelectionGameobject.SetActive(false);
        loadingPanelGameobject.SetActive(true);

    }

   public void OnWatchRewardAd()
    {
       // if (AdmobAdsManager.Instance)
           // AdmobAdsManager.Instance.ShowRewardedVideo(Ad100Coins);
          // // MaxAdsManager.Instance.Btn_LS_Rew(Ad100Coins);
    }

    void Ad100Coins()
    {
        //Sfx_Mainmenu.PlaySound(Sfx_Mainmenu.Instance.sellPurchase);
        totalCoins += 100;
        PlayerPrefs.SetInt("Diamonds", totalCoins);
        coinsText.text = totalCoins.ToString();
        notEnoughCoinsPanelPet.SetActive(false);
        notEnoughCoinsPanelGran.SetActive(false);
    }

    public void DeductCoins(int coins)
    {
        totalCoins -= coins;
        PlayerPrefs.SetInt("Diamonds", totalCoins);
        coinsText.text = totalCoins.ToString();
    }

    public int CheckCoins()
    {
        return totalCoins;
    }
}

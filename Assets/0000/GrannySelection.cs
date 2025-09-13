using UnityEngine;
using UnityEngine.UI;

public class GrannySelection : MonoBehaviour
{
    public static GrannySelection Instance { get; private set; }
    public GameObject[] grannyPrefabs;
    private GameObject currentGrannyInstance;
    public int currentIndex = 0;
    public GameObject unlockButton;
    public GameObject selectButton;
    public GameObject unlockAllGrans;
    public GameObject rewardCoinsButton;
    public Transform spawnPoint;
    public GameObject notEnoughCoinsPanel;
    public Text reqCoinsText;
    public GameObject reqCoinsGameobject;
    public ModesAd modeAdsHandler;
    public GameObject showAdAndSelectFree;
<<<<<<< HEAD
    public GameObject UnlockGransBtn;
    [SerializeField] GameObject[] greenUI;


    
    private int[] grannyPrices = { 0, 500, 1000,1500 };
=======
    [SerializeField] GameObject[] greenUI;



    private int[] grannyPrices = { 0, 500, 1000 };
>>>>>>> origin/main

    public void DisableGreenUI()
    {
        foreach (var item in greenUI)
        {
            item.SetActive(false);
        }
    }
    private void Awake()
    {
        CheckForNoAds();
    }
    void Start()
<<<<<<< HEAD
    {
        Instance = this;
        DontDestroyOnLoad(this.gameObject);

=======
    {
>>>>>>> origin/main
        currentIndex = PlayerPrefs.GetInt("SelectedGrannyIndex", 0);
    }
    private void OnEnable()
    {
        PlayerPrefs.SetInt("SelectedGrannyIndex", 0);
        currentIndex = PlayerPrefs.GetInt("SelectedGrannyIndex", 0);
        SpawnGranny();
        AtStart();
    }

    public void MoveLeft()
    {

        currentIndex--;
        if (currentIndex < 0)
        {
            currentIndex = grannyPrefabs.Length - 1;
        }
        SpawnGranny();
    }

    public void MoveRight()
    {
        currentIndex++;
        if (currentIndex >= grannyPrefabs.Length)
        {
            currentIndex = 0;
        }
        SpawnGranny();
    }

    public void MoveToIndex(int indexOfGran)
    {
        DisableGreenUI();
        currentIndex = indexOfGran;
        SpawnGranny();
    }

    public void SelectGranny()
    {
        if (IsGrannyUnlocked(currentIndex))
        {
            PlayerPrefs.SetInt("SelectedGrannyIndex", currentIndex);
            PlayerPrefs.Save();
            Debug.Log("Granny " + currentIndex + " selected!");
            Destroy(currentGrannyInstance);
        }
        else
        {
            Debug.Log("This Granny is locked! Unlock her first.");
        }
    }

    public void ShowAdAndSelectGranny()
    {
<<<<<<< HEAD
        AdmobAdsManager.Instance.ShowRewardedVideo(SelectGranny);
=======
//        AdmobAdsManager.Instance.ShowRewardedVideo(SelectGranny);
>>>>>>> origin/main
    }

    public void UnlockGranny()
    {
        //MaxAdsManager.Instance.Btn_LS_Rew(UnlockGrannyAfterAd);
<<<<<<< HEAD
        AdmobAdsManager.Instance.ShowRewardedVideo(UnlockGrannyAfterAd);
=======
      //  AdmobAdsManager.Instance.ShowRewardedVideo(UnlockGrannyAfterAd);
>>>>>>> origin/main
    }

    public void ShowRewardedAd()
    {
<<<<<<< HEAD
        if (AdmobAdsManager.Instance)
        {
            AdmobAdsManager.Instance.ShowRewardedVideo(UnlockGrannyAfterAd);
        }
=======
        //if (AdmobAdsManager.Instance)
        //{
           // AdmobAdsManager.Instance.ShowRewardedVideo(UnlockGrannyAfterAd);
        //}
>>>>>>> origin/main
    }

    void UnlockGrannyAfterAd()
    {
        //Sfx_Mainmenu.PlaySound(Sfx_Mainmenu.Instance.sellPurchase);
        if(Sfx_Manager.Instance)
        Sfx_Manager.PlayRandomSound(Sfx_Manager.Instance.cashSound);
        PlayerPrefs.SetInt("GrannyUnlocked_" + currentIndex, 1);
        PlayerPrefs.Save();
        Debug.Log("Granny " + currentIndex + " unlocked!");
        UpdateButtons();
    }

    void SpawnGranny()
    {
        if (currentGrannyInstance != null)
        {
            Destroy(currentGrannyInstance);
        }
        if(Sfx_Manager.Instance)
        Sfx_Manager.PlayRandomSound(Sfx_Manager.Instance.spawnSound);
        currentGrannyInstance = Instantiate(grannyPrefabs[currentIndex], spawnPoint.position, Quaternion.identity);
        currentGrannyInstance.transform.rotation = Quaternion.Euler(0, 180, 0);
        UpdateButtons();
    }

    void UpdateButtons()
    {
        if (IsGrannyUnlocked(currentIndex))
        {
            showAdAndSelectFree.SetActive(true);
            selectButton.SetActive(true);
            unlockButton.SetActive(false);
            unlockAllGrans.SetActive(false);
            rewardCoinsButton.SetActive(false);
            reqCoinsGameobject.SetActive(false);
            
        }
        else
        {
            showAdAndSelectFree.SetActive(false);
            selectButton.SetActive(false);
            unlockButton.SetActive(true);
            unlockAllGrans.SetActive(true);
            rewardCoinsButton.SetActive(true);
            reqCoinsGameobject.SetActive(true);
        }
        UpdateReqCoinsText(grannyPrices[currentIndex]);
    }

    bool IsGrannyUnlocked(int index)
    {
        if (index == 0) return true;
        return PlayerPrefs.GetInt("GrannyUnlocked_" + index, 0) == 1;
    }

    public void DestroyCurrentGranny()
    {
        Destroy(currentGrannyInstance);
    }

    public void UnlockAllGarns()
<<<<<<< HEAD
    {
        //for (int i = 0; i < grannyPrefabs.Length; i++)
        //{
        //    PlayerPrefs.SetInt("GrannyUnlocked_" + i, 1); // Unlock every pet
        //}
        //PlayerPrefs.Save();
        //Debug.Log("All pets unlocked!");
        //UpdateButtons();

        UnlockGransBtn.SetActive(false);

        PlayerPrefs.SetInt("GrannyUnlocked_" + 0, 1);
        PlayerPrefs.SetInt("GrannyUnlocked_" + 1, 1);
        PlayerPrefs.SetInt("GrannyUnlocked_" + 2, 1);
        PlayerPrefs.SetInt("GrannyUnlocked_" + 3, 1);
        PlayerPrefs.SetInt("GrannyUnlocked_" + 4, 1);
        PlayerPrefs.SetInt("GrannyUnlocked_" + 5, 1);
        PlayerPrefs.Save();
=======
    {
        for (int i = 0; i < grannyPrefabs.Length; i++)
        {
            PlayerPrefs.SetInt("GrannyUnlocked_" + i, 1); // Unlock every pet
        }
        PlayerPrefs.Save();
        Debug.Log("All pets unlocked!");
>>>>>>> origin/main
        UpdateButtons();
    }

    public void BuyNow()
    {
        int playerCoins = PlayerPrefs.GetInt("MyCoins", 0);
        int grannyPrice = grannyPrices[currentIndex];

        if (IsGrannyUnlocked(currentIndex))
        {
            Debug.Log("Granny already unlocked!");
            return;
        }

        if (playerCoins >= grannyPrice)
        {
            playerCoins -= grannyPrice; // Deduct coins
            PlayerPrefs.SetInt("MyCoins", playerCoins); // Fix key from "Coins" to "MyCoins"
            PlayerPrefs.SetInt("GrannyUnlocked_" + currentIndex, 1);
            PlayerPrefs.Save();
            UpdateButtons();
            Sfx_Manager.PlayRandomSound(Sfx_Manager.Instance.cashSound);
            modeAdsHandler.DeductCoins(grannyPrices[currentIndex]);
        }
        else
        {
            //not enough coins
            notEnoughCoinsPanel.SetActive(true);
        }
    }

    void UpdateReqCoinsText(int coins)
    {
        reqCoinsText.text = coins.ToString();
    }

    void CheckForNoAds()
    {
        if (PlayerPrefs.GetInt("noADS") == 1)
        {
            UnlockAllGarns();
        }
    }

    void AtStart()
    {
        DisableGreenUI();
        greenUI[0].SetActive(true);
    }
<<<<<<< HEAD






    public void OnRewardCompleted()
    {
        Debug.Log("----currentIndex : "+ currentIndex);
        PlayerPrefs.SetInt("GrannyUnlocked_" + currentIndex, 1);
        PlayerPrefs.Save();
        UpdateButtons();
    }
=======
>>>>>>> origin/main
}
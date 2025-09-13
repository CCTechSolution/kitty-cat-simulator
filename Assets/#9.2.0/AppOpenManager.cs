using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using GoogleMobileAds;
using GoogleMobileAds.Api;
using GoogleMobileAds.Common;

public class AppOpenManager : MonoBehaviour
{
    public static AppOpenManager Instance;
    public bool Test_Ads;
    public bool Skip_Ads;
    public bool _AppOpen;
    public float _AO_Load;
    public string ADMOB_APP_ID;
    public string[] ADMOB_AppOpen_ID;
    public string ADMOB_AppOpen_ID_Test = "ca-app-pub-3940256099942544/9257395921";
    public Text AppOpenHighText, AppOpenMedText, AppOpenLowText;

    AppOpenAd HighAppOpen;
    AppOpenAd MedAppOpen;
    AppOpenAd LowAppOpen;

    bool isloadHighAppOpen;
    bool isloadMedAppOpen;
    bool isloadLowAppOpen;

    int TestAppOpenHighCounter;
    int TestAppOpenMedCounter;
    int TestAppOpenLowCounter;

    void Awake()
    {
        Instance = this;
    }
    void OnEnable()
    {
        if (Test_Ads == false)
        {
            Debug.Log("App Open ID Orignal");
            // Orignal
        }
        else
        {
            Debug.Log("App Open ID Test");
            ADMOB_AppOpen_ID[0] = ADMOB_AppOpen_ID_Test;
            ADMOB_AppOpen_ID[1] = ADMOB_AppOpen_ID_Test;
            ADMOB_AppOpen_ID[2] = ADMOB_AppOpen_ID_Test;
        }
        Invoke(nameof(LoadAllAppOpen), _AO_Load);
    }
    void Start()
    {

    }
    public void Btn_App_Load()
    {
        LoadAllAppOpen();
    }
    public void Btn_App_Show()
    {
        if (Skip_Ads == true)
        {
            // No ADs
        }
        else
        {
            PrioritySettingAppOpen();
        }
    }

    private void OnApplicationPause(bool isPaused)
    {
        if (!isPaused)
        {
            if (SceneManager.GetActiveScene().buildIndex == 0 || SceneManager.GetActiveScene().buildIndex == 1)
            {
                return;
            }
            if (AdmobAdsManager.ForeGroundedAD == false)
            {
                AdmobAdsManager.ForeGroundedAD = true;
                Btn_App_Show();
                Debug.Log("App Open Loading On Pause");
                Invoke("LoadAllAppOpen", 1f);
            }
            else
            {
                AdmobAdsManager.ForeGroundedAD = false;
            }
        }
    }

    void LoadAllAppOpen()
    {
        _AppOpen = true;
        Debug.Log("App Open Load Yes");
        Invoke(nameof(HighAppOpenLoadAd), 0f);
        Invoke(nameof(MedAppOpenLoadAd), 0.5f);
        Invoke(nameof(LowAppOpenLoadAd), 1.5f);
    }
    void HighAppOpenLoadAd()
    {
        if (HighAppOpen == null)
        {
            if (ADMOB_AppOpen_ID.Length == 0)
            {
                AppOpenHighText.text = "ADMOB_ID.ADMOB_AppOpen_ID " + ADMOB_AppOpen_ID.Length;
                return;
            }
            TestAppOpenHighCounter += 1;
            AdRequest request = new AdRequest();
            AppOpenAd.Load(ADMOB_AppOpen_ID[0], request, (AppOpenAd loadedAd, LoadAdError loadAdError) =>
            {
                if (loadAdError != null)
                {
                    AppOpenHighText.text = "Load Fail High AppOpen " + TestAppOpenHighCounter;
                    isloadHighAppOpen = false;
                    Debug.LogError("App Open Failed to load H 1 Ad: " + loadAdError.GetMessage());
                    return;
                }
                isloadHighAppOpen = true;
                HighAppOpen = loadedAd;
                AppOpenHighText.text = "Loaded High AppOpen " + TestAppOpenHighCounter;
                Debug.Log("App Open Ad loaded successfully. H");
            });
        }
        else
        {
            if (!isloadHighAppOpen)
            {
                TestAppOpenHighCounter += 1;
                if (HighAppOpen != null)
                {
                    HighAppOpen.Destroy();
                    HighAppOpen = null;
                }
                AdRequest request = new AdRequest();
                AppOpenAd.Load(ADMOB_AppOpen_ID[0], request, (AppOpenAd loadedAd, LoadAdError loadAdError) =>
                {
                    if (loadAdError != null)
                    {
                        isloadHighAppOpen = false;
                        AppOpenHighText.text = "Load fail High AppOpen " + TestAppOpenHighCounter;
                        Debug.LogError("App Open Failed to load H 2 Ad: " + loadAdError.GetMessage());
                        return;
                    }
                    isloadHighAppOpen = true;
                    AppOpenHighText.text = "Loaded High AppOpen " + TestAppOpenHighCounter;
                    HighAppOpen = loadedAd;

                });
            }
            else
                AppOpenHighText.text = "Load already High AppOpen " + TestAppOpenHighCounter;
        }
    }
    void MedAppOpenLoadAd()
    {
        if (MedAppOpen == null)
        {
            if (ADMOB_AppOpen_ID.Length == 0)
            {
                AppOpenHighText.text = "ADMOB_ID.ADMOB_AppOpen_ID " + ADMOB_AppOpen_ID.Length;
                return;
            }
            TestAppOpenMedCounter += 1;
            AdRequest request = new AdRequest();
            AppOpenAd.Load(ADMOB_AppOpen_ID[1], request, (AppOpenAd loadedAd, LoadAdError loadAdError) =>
            {
                if (loadAdError != null)
                {
                    isloadMedAppOpen = false;
                    AppOpenMedText.text = "Load fail Med AppOpen " + TestAppOpenMedCounter;
                    Debug.LogError("App Open Failed to load M 1 Ad: " + loadAdError.GetMessage());
                    return;
                }
                isloadMedAppOpen = true;
                AppOpenMedText.text = "Loaded Med AppOpen " + TestAppOpenMedCounter;
                MedAppOpen = loadedAd;
                Debug.Log("App Open Ad loaded successfully. M");
            });
        }
        else
        {
            if (!isloadMedAppOpen)
            {
                TestAppOpenMedCounter += 1;
                if (MedAppOpen != null)
                {
                    MedAppOpen.Destroy();
                    MedAppOpen = null;
                }
                AdRequest request = new AdRequest();
                AppOpenAd.Load(ADMOB_AppOpen_ID[1], request, (AppOpenAd loadedAd, LoadAdError loadAdError) =>
                {
                    if (loadAdError != null)
                    {
                        isloadMedAppOpen = false;
                        AppOpenMedText.text = "Load fail Med AppOpen " + TestAppOpenMedCounter;
                        Debug.LogError("Failed to load M 2 Ad: " + loadAdError.GetMessage());
                        return;
                    }
                    AppOpenMedText.text = "Loaded Med AppOpen " + TestAppOpenMedCounter;
                    isloadMedAppOpen = true;
                    MedAppOpen = loadedAd;

                });
            }
            else
                AppOpenMedText.text = "Load Already Med AppOpen " + TestAppOpenMedCounter;
        }
    }
    void LowAppOpenLoadAd()
    {
        if (LowAppOpen == null)
        {
            if (ADMOB_AppOpen_ID.Length == 0)
            {
                AppOpenHighText.text = "ADMOB_ID.ADMOB_AppOpen_ID " + ADMOB_AppOpen_ID.Length;
                return;
            }
            TestAppOpenLowCounter += 1;
            AdRequest request = new AdRequest();
            AppOpenAd.Load(ADMOB_AppOpen_ID[2], request, (AppOpenAd loadedAd, LoadAdError loadAdError) =>
            {
                if (loadAdError != null)
                {
                    AppOpenLowText.text = "Load fail Low AppOpen " + TestAppOpenLowCounter;
                    isloadLowAppOpen = false;
                    Debug.LogError("App Open Failed to load L 1 Ad: " + loadAdError.GetMessage());
                    return;
                }
                isloadLowAppOpen = true;
                AppOpenLowText.text = "Loaded Low AppOpen " + TestAppOpenLowCounter;
                LowAppOpen = loadedAd;
                Debug.Log("App Open Ad loaded successfully. L");
            });
        }
        else
        {
            if (!isloadLowAppOpen)
            {
                TestAppOpenLowCounter += 1;
                if (LowAppOpen != null)
                {
                    LowAppOpen.Destroy();
                    LowAppOpen = null;
                }
                AdRequest request = new AdRequest();
                AppOpenAd.Load(ADMOB_AppOpen_ID[2], request, (AppOpenAd loadedAd, LoadAdError loadAdError) =>
                {
                    if (loadAdError != null)
                    {
                        isloadLowAppOpen = false;
                        AppOpenLowText.text = "Load fail Low AppOpen " + TestAppOpenLowCounter;
                        Debug.LogError("App Open Failed to load L 2 Ad: " + loadAdError.GetMessage());
                        return;
                    }
                    isloadLowAppOpen = true;
                    LowAppOpen = loadedAd;
                    AppOpenLowText.text = "Loaded Low AppOpen " + TestAppOpenLowCounter;
                });
            }
            else
                AppOpenLowText.text = "Load already low AppOpen " + TestAppOpenLowCounter;
        }
    }
    bool isHighAppOpenLoad()
    {
        if (isloadHighAppOpen)
            return true;
        else
            return false;
    }
    bool isMedAppOpenLoad()
    {
        if (isloadMedAppOpen)
            return true;
        else
            return false;
    }
    bool isLowAppOpenLoad()
    {
        if (isloadLowAppOpen)
            return true;
        else
            return false;
    }
    void PrioritySettingAppOpen()
    {
        if (!SwitchAppOpen(0))
        {
            Debug.Log("App Open Show 0");
            if (!SwitchAppOpen(1))
            {
                Debug.Log("App Open Show 1");
                if (!SwitchAppOpen(2))
                {
                    Debug.Log("App Open Show 2");
                }
            }
        }

        Debug.Log("App Open Loading On After Show");
        Invoke("LoadAllAppOpen", 1f);
    }

    bool SwitchAppOpen(int Priority)
    {
        switch (Priority)
        {
            case 0:
                if (isHighAppOpenLoad())
                {
                    TestAppOpenHighCounter += 1;
                    AdmobAdsManager.ForeGroundedAD = true;
                    AppOpenHighText.text = "Show High AppOpen " + TestAppOpenHighCounter;
                    HighAppOpen.Show();
                    HighAppOpen.OnAdFullScreenContentClosed += EventHighAppOpen;
                    Debug.Log("App Open Switch H Y");
                    return true;
                }
                else
                {
                    Debug.Log("App Open Switch H N");
                    HighAppOpenLoadAd();
                    return false;
                }

            case 1:
                if (isMedAppOpenLoad())
                {
                    TestAppOpenMedCounter += 1;
                    AppOpenMedText.text = "Show Med AppOpen " + TestAppOpenMedCounter;
                    AdmobAdsManager.ForeGroundedAD = true;
                    MedAppOpen.Show();
                    MedAppOpen.OnAdFullScreenContentClosed += EventMedAppOpen;
                    Debug.Log("App Open Switch M Y");
                    return true;
                }
                else
                {
                    Debug.Log("App Open Switch M N");
                    MedAppOpenLoadAd();
                    return false;
                }
            case 2:
                if (isLowAppOpenLoad())
                {
                    TestAppOpenLowCounter = +1;
                    AppOpenLowText.text = "Show Low AppOpen " + TestAppOpenLowCounter;
                    AdmobAdsManager.ForeGroundedAD = true;
                    LowAppOpen.Show();
                    LowAppOpen.OnAdFullScreenContentClosed += EventLowAppOpen;
                    Debug.Log("App Open Switch L Y");
                    return true;
                }
                else
                {
                    Debug.Log("App Open Switch L N");
                    LowAppOpenLoadAd();
                    return false;
                }
            case 99:
                return false;
            default:
                return false;
        }
    }
    void EventHighAppOpen()
    {
        MobileAdsEventExecutor.ExecuteInUpdate(() =>
        {
            Debug.Log("App Open Event H");
            isloadHighAppOpen = false;
            HighAppOpenLoadAd();
        });
    }
    void EventMedAppOpen()
    {
        MobileAdsEventExecutor.ExecuteInUpdate(() =>
        {
            Debug.Log("App Open Event M");
            isloadMedAppOpen = false;
            MedAppOpenLoadAd();
        });
    }
    void EventLowAppOpen()
    {
        MobileAdsEventExecutor.ExecuteInUpdate(() =>
        {
            Debug.Log("App Open Event M");
            isloadLowAppOpen = false;
            LowAppOpenLoadAd();
        });
    }
}
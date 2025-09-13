
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuHandler : MonoBehaviour
{
    public static MainMenuHandler instance;

    [Header("Panels")]
    public GameObject MainMenuPanel;
    public GameObject SettingsPanel;
    public GameObject ExitPanel;
    public GameObject ExitBtn;
    public GameObject ExitLoad;
    public GameObject ModeSelectionPanel;
    public GameObject LevelSelectionPanel;
    public GameObject InAppPanel;
    [Header("Music & Sound")]
    public Button EffectsButton;
    public Button MusicButton;
    public Button VibrationButton;
    public GameObject EffectButtonEnable;
    public GameObject EffectButtonDisable;
    public GameObject MusicButtonEnable;
    public GameObject MusicButtonDisable;
    public GameObject VibrationButtonEnable;
    public GameObject VibrationButtonDisable;
    private bool musicStatus = true;
    private bool effectStatus = true;

    [Header("More Games Link")]
    public string MoreGamesIOS;
    public string MoreGamesAndroid;
    [Header("Rate Us Link")]
    public string RateUsIOS;
    public string RateUsAndroid;
    [Header("About Us Link")]
    public string AboutUs;
    public int _levelunlock;
    public int Mode1;
    [Header("COinsss")]
    public GameObject CoinsBar;
    public Text Coinstext;
    public int coins;

    public GameObject Music;
    public GameObject Music2;
    public GameObject Sounds;
    private void Awake()
    {
        instance = this;
        //AdmobAdsManager.Instance.hideMediumBanner();
    }
   
    void Start()
    {
        Music.SetActive(true);
        //if (AdmobAdsManager.Instance.Internet == true)
        //{
        //    Firebase.Analytics.FirebaseAnalytics.LogEvent("GameStart_MainMenu");
        //}
        //Mode1 = PlayerPrefs.GetInt("Mode1Levels");
        //_levelunlock = Mode1;

        PlayerPrefs.GetInt("Coins");
        //coins = PlayerPrefs.GetInt("Coins");
        //Coinstext.text = coins.ToString();
    }
    void Update()
    {
        //PlayerPrefs.GetInt("Coins");
        //coins = PlayerPrefs.GetInt("Coins");
        //Coinstext.text = coins.ToString();
    }
    public void OnClickPlayBtn()
    {
          ModeSelectionPanel.SetActive(true);
        MainMenuPanel.SetActive(false);
        //TimelineHandling.Instance.StopTimeline();
        //Music.SetActive(false);
        //Music2.SetActive(true);
      //  GameManagerScript.instance.CurrentMode = 0;
        //GameManagerScript.instance.CurrentTask= PlayerPrefs.GetInt("CurrentTask", GameManagerScript.instance.CurrentTask);
        //   LevelsUnLockMode1();
        //  //  LevelSelectionPanel.SetActive(true);
        //   SceneManager.LoadScene("Loading");
        //   Invoke(nameof(WaitForLoadingScrn), 3f);



        //AdmobAdsManager.Instance.hideMediumBanner();

    }
    public void OnClickSettings()
    {
        SettingsPanel.SetActive(true);
        MainMenuPanel.SetActive(false);
    }
    public void OnClickSettingBack()
    {
        //TimelineHandling.Instance.ResumeTimeline();
        MainMenuPanel.SetActive(true);
        SettingsPanel.SetActive(false);
        //AdmobAdsManager.Instance.hideMediumBanner();
    }
    public void OnClickRateUs()
    {
        Application.OpenURL(RateUsAndroid);
    }
    public void OnClickAboutUs()
    {
        Application.OpenURL(AboutUs);
    }
    public void OnClickMoreGames()
    {
        Application.OpenURL(MoreGamesAndroid);
    }
    public void OnClickExitBtn()
    {
        ExitPanel.SetActive(true);
        //ExitBtn.SetActive(false);
        //ExitLoad.SetActive(true);
        Invoke(nameof(ExitCall), 6f);
        MainMenuPanel.SetActive(false);
    }
    private void ExitCall()
    {
       Application.Quit();
    }

    public void OnClickNo()
    {
        //TimelineHandling.Instance.ResumeTimeline();
        ExitPanel.SetActive(false);
        ExitBtn.SetActive(false);
        ExitLoad.SetActive(false);
        MainMenuPanel.SetActive(true);
        //AdmobAdsManager.Instance.hideMediumBanner();

    }
    public void OnClickYes()
    {
        Application.Quit();
    }
    public void OnClickModeBtn(int a)
    {
        GameManagerScript.instance.CurrentMode = a;
        LevelsUnLockMode1();
        //  LevelSelectionPanel.SetActive(true);
        SceneManager.LoadScene("Loading");
        Invoke(nameof(WaitForLoadingScrn), 3f);
    }
    public void LevelsUnLockMode1()
    {

        _levelunlock = PlayerPrefs.GetInt("Mode1Levels");
        if (_levelunlock > 4)
        {
            GameManagerScript.instance.CurrentLevel = 4;
        }
        for (int i = 0; i <= _levelunlock; i++)
        {
            if (i <= _levelunlock)
            {
                GameManagerScript.instance.CurrentLevel = _levelunlock;
            }
        }
    }
    public void WaitForLoadingScrn()
    {
        ModeSelectionPanel.SetActive(false);
        MainMenuPanel.SetActive(false);
    }
    public void OnClickModeBack()
    {
        MainMenuPanel.SetActive(true);
        ModeSelectionPanel.SetActive(false);
        TimelineHandling.Instance.ResumeTimeline();
        Music.SetActive(true);
        Music2.SetActive(false);
    }
    public void OnClickLevelsBtn(int b)
    {
        GameManagerScript.instance.CurrentLevel = b;
        SceneManager.LoadScene("Loading");
    }
    public void OnlickLevelsBack()
    {
        ModeSelectionPanel.SetActive(true);
        LevelSelectionPanel.SetActive(false);
    }
    public void EffectsEnable()
    {
        Sounds.TryGetComponent<AudioSource>(out AudioSource audio);
        effectStatus = !effectStatus;
        if (EffectButtonEnable == null && EffectButtonDisable == null)
            return;
        if (effectStatus)
        {
            EffectButtonEnable.SetActive(true);
            EffectButtonDisable.SetActive(false);
            audio.enabled = true;

        }
        else
        {
            EffectButtonEnable.SetActive(false);
            EffectButtonDisable.SetActive(true);
            audio.enabled = false;
        }
        //Self SoundManager.Instance.EffectsEnabled = effectStatus;
   //     SoundManager.Instance.EffectsEnabled = effectStatus;
        Debug.Log("Effects Status" + effectStatus);
    }

    public void MusicEnable()
    {
        Music.TryGetComponent<AudioSource>(out AudioSource audio);
        musicStatus = !musicStatus;
        if (MusicButtonEnable == null && MusicButtonDisable == null)
            return;
        if (musicStatus)
        {
            MusicButtonEnable.SetActive(true);
            MusicButtonDisable.SetActive(false);
            audio.enabled = true;
        }
        else
        {
            MusicButtonEnable.SetActive(false);
            MusicButtonDisable.SetActive(true);
            audio.enabled = false;
        }
        //Self SoundManager.Instance.MusicEnabled = musicStatus;
     //  SoundManager.Instance.MusicEnabled = musicStatus;
        Debug.Log("Music Status" + musicStatus);
    }
    public void CheckVibration()
    {
        if (!GameManagerScript.instance.VibrationStats)
        {
            Debug.Log(GameManagerScript.instance.VibrationStats);
            GameManagerScript.instance.VibrationStats = true;
            VibrationButtonDisable.SetActive(false);
            VibrationButtonEnable.SetActive(true);
        }
        else if (GameManagerScript.instance.VibrationStats)
        {
            GameManagerScript.instance.VibrationStats = false;
            VibrationButtonDisable.SetActive(true);
            VibrationButtonEnable.SetActive(false);
        }
    }
}

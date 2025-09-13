using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.Tilemaps;


public class UIManager : MonoBehaviour
{
    public static UIManager instance;
    [Header("Panels")]
    public GameObject Ad;
    public GameObject PausePanel;
    public GameObject LevelFailedPanel;
    public GameObject LevelCompletePanel;
    public GameObject BloodImg;

    public GameObject PickBtn;
    public bool pickPressed = false;
    public GameObject DropBtn;
    public GameObject DropBagBtn;
    public bool dropPressed = false;
    public Button HintBtn;
    [HideInInspector]
    public UnityEvent OnLevelComplete;
    public UnityEvent OnLevelFailed;

    [Header("InventoryItems")]
    public GameObject Bag;
    public GameObject Torch;
    public GameObject Key;
    public GameObject Hammer;


    private void Awake()
    {
        instance = this;
        OnLevelComplete.AddListener(delegate
        {
            StartCoroutine(DelayInLevelComplete());
            GamePlayHandler.instance.PlayerControls.SetActive(false);
        });
        OnLevelFailed.AddListener(delegate
        {
            StartCoroutine(DelayInLevelFailed());
            GamePlayHandler.instance.PlayerControls.SetActive(false);
        });
    }
    public void OnClickPickBtn()
    {
        PlayerManager.instance.Dummybag.SetActive(false);
        PlayerManager.instance.DummyTorch.SetActive(false);
        PlayerManager.instance.DummyKey.SetActive(false);
        PlayerManager.instance.DummyHammer.SetActive(false);
        GamePlayHandler.instance.DisableAllAI_NUN();

        if (GameManagerScript.instance.CurrentLevel == 0)
        {
            if (GamePlayHandler.instance.currentObjectiveIndex==2)
            {
                  GamePlayHandler.instance.BagParticle.SetActive(true);
            }

            if (PlayerManager.instance.PrevPickable != null)
            {
                //Debug.LogError("Drop here OnClickPickBtn");
                dropPressed = true;
                PlayerManager.instance.PrevPickable.GetComponent<objPickup>().DropObject();
                PlayerManager.instance.PrevPickable.SetActive(false);
            }

        }//Self
        pickPressed = true;
        PlayerManager.instance.hasReached = false;
        // task cutscene play here 
        if (GameManagerScript.instance.CurrentLevel == 0)
        {
            if (GamePlayHandler.instance.GetActiveCutscene(GamePlayHandler.instance.currentObjectiveIndex))
            {
                GamePlayHandler.instance.EndCinDelay();
            }
            else
            {
                Ad.SetActive(true);

            }
        }
        else
        {
            Ad.SetActive(true);

        }
        PlayerManager.instance.HandlePickables();
        //self
        GamePlayHandler.instance.SetPlayerPos();
        objPickup.instance.PickObject();//self
        PickBtn.SetActive(false);
        objPickup.instance.ActivePickablesHandling();
        GamePlayHandler.instance.ActiveObjectives();//Self
        LevelsHandling.Instance.levelnoHandle();
        InventoryHandling();
        if (GameManagerScript.instance.CurrentLevel == 2)
        {
            LevelsHandling.Instance.Mother.SetActive(true);
        }

        /////////////////////////////////// 
        /// 
        ///       COOMENTED ADS
        /// 
        ///////////////////////////////////
        //if (AdmobAdsManager.Instance.Internet == true)
        //{
        //    Firebase.Analytics.FirebaseAnalytics.LogEvent("Level_" + GameManagerScript.instance.CurrentLevel + "Task_" +GamePlayHandler.instance.currentObjectiveIndex + "DoneTask");
        //}
        //  PlayerManager.instance.HandleLevelCompletion();  // testing....
    }

    public void OnClickDropBtn()
    {
        dropPressed = true;
        GamePlayHandler.instance.SetPlayerPos();
    }
    public void OnClickBagBtn()
    {
        PlayerManager.instance.Dummybag.SetActive(false);
        PlayerManager.instance.DummyTorch.SetActive(false);
        PlayerManager.instance.DummyKey.SetActive(false);
        PlayerManager.instance.DummyHammer.SetActive(false);
        GamePlayHandler.instance.DisableAllAI_NUN();
        HintBtn.interactable = true;
        GamePlayHandler.instance.EndPoint.SetActive(false);
        //  objPickup.instance.DropBag();
        objPickup.instance.DropObject();
        if (GameManagerScript.instance.CurrentLevel == 0)
        {
            if (GamePlayHandler.instance.EndPointIndex == 5)
            {
                if (GamePlayHandler.instance.GetActiveCutscene(7))
                {
                    GamePlayHandler.instance.CallLastCin();

                }
            }
            if (GamePlayHandler.instance.EndPointIndex < 5)
            {
                if (GamePlayHandler.instance.GetActiveCutscene(GamePlayHandler.instance.currentObjectiveIndex))
                {
                    Debug.Log(GamePlayHandler.instance.currentObjectiveIndex);
                    GamePlayHandler.instance.EndCinDelay();
                }
                else
                {
                    Ad.SetActive(true);

                }

            }


        }

        else
        {
            Ad.SetActive(true);

        }
        //  Ad.SetActive(true);

        DropBagBtn.SetActive(false);
        GamePlayHandler.instance.BagParticle.SetActive(false);
        if (GameManagerScript.instance.CurrentLevel == 0)
        {
            if (PlayerManager.instance.PrevPickable != null)
            {
                //Debug.LogError("Drop here OnClickBagBtn");
                dropPressed = true;
                PlayerManager.instance.PrevPickable.GetComponent<objPickup>().DropObject();
                PlayerManager.instance.PrevPickable.SetActive(false);
            }
        }//Self
            GamePlayHandler.instance.SetPlayerPos();

        PlayerManager.instance.HandlePickables();
        //self
        objPickup.instance.ActivePickablesHandling();
        GamePlayHandler.instance.ActiveObjectives();//Self
        LevelsHandling.Instance.levelnoHandle();
        InventoryHandling();

        /////////////////////////////////// 
        /// 
        ///       COOMENTED ADS
        /// 
        ///////////////////////////////////

        //if (AdmobAdsManager.Instance.Internet == true)
        //{
        //    Firebase.Analytics.FirebaseAnalytics.LogEvent("Level_" + GameManagerScript.instance.CurrentLevel + "Task_" + GamePlayHandler.instance.currentObjectiveIndex + "DoneTask");
        //}

    }
    public IEnumerator WaitForAd()
    {
        yield return new WaitForSeconds(2f);
        Ad.SetActive(true);

    }
    public void InventoryHandling()
    {

      if (GamePlayHandler.instance.PIckableIndex == 0)
        {
          //  Bag.SetActive(true);
        }
        if (GamePlayHandler.instance.PIckableIndex == 1)
        {
            Bag.SetActive(true);
          //  Torch.SetActive(true);
        }
        if (GamePlayHandler.instance.PIckableIndex == 2)
        {
            Bag.SetActive(true);
            Torch.SetActive(true);
          //  Key.SetActive(true);
        }
        if (GamePlayHandler.instance.PIckableIndex == 3)
        {
            Bag.SetActive(true);
            Torch.SetActive(true);
            Key.SetActive(true);
          // Hammer.SetActive(true);
        }
        if (GamePlayHandler.instance.PIckableIndex == 4)
        {
            Bag.SetActive(true);
            Torch.SetActive(true);
            Key.SetActive(true);
             Hammer.SetActive(true);
        }
        if (GamePlayHandler.instance.PIckableIndex == 5)
        {
            Bag.SetActive(true);
            Torch.SetActive(true);
            Key.SetActive(true);
            Hammer.SetActive(true);
        }
    }
    public IEnumerator DelayInLevelComplete()
    {

        yield return new WaitForSeconds(0.1f);
        LevelCOmplete();

    }
    public IEnumerator DelayInLevelFailed()
    {
        yield return new WaitForSeconds(4f);
        LevelFailed();

    }
    public void Pause()
    {
        //Self SoundManager.Instance.PlayEffect(AudioClipsSource.Instance.GenericButtonClip);
        Time.timeScale = 1;
        PausePanel.SetActive(true);
        GamePlayHandler.instance.PlayerControls.SetActive(false);
        GamePlayHandler.instance.Player.SetActive(false);
        GamePlayHandler.instance.PlayerCam.SetActive(false);
        GamePlayHandler.instance.DisableEnemy();
    }
    public void Resume()
    {
        //Self SoundManager.Instance.PlayEffect(AudioClipsSource.Instance.GenericButtonClip);
        Time.timeScale = 1;
        GamePlayHandler.instance.PlayerControls.SetActive(true);
        GamePlayHandler.instance.Player.SetActive(true);
        GamePlayHandler.instance.PlayerCam.SetActive(true);
        GamePlayHandler.instance.ActiveEnemies();
        PausePanel.SetActive(false);
    }
    public void Restart()
    {
        //Self SoundManager.Instance.PlayEffect(AudioClipsSource.Instance.GenericButtonClip);
        Time.timeScale = 1;
        GamePlayHandler.instance.currentObjectiveIndex = 0;
       PlayerPrefs.SetInt("CurrentTask", GameManagerScript.instance.CurrentTask);
        GamePlayHandler.instance.EndPointIndex = 0;
        GamePlayHandler.instance.PIckableIndex = 0;
        GamePlayHandler.instance.PlayerPos = 0;
        GameManagerScript.instance.ChangeScene("Loading");
    }
    public void Revive()
    {
        //Self SoundManager.Instance.PlayEffect(AudioClipsSource.Instance.GenericButtonClip);
        Time.timeScale = 1;
        GamePlayHandler.instance.currentObjectiveIndex = PlayerPrefs.GetInt("CurrentTask", GameManagerScript.instance.CurrentTask);
        if (GamePlayHandler.instance.currentObjectiveIndex == 1)
        {
            if (PlayerManager.instance.currentPickable != null)
            {
                PlayerManager.instance.currentPickable.SetActive(false);
            }
            PlayerManager.instance.Dummybag.SetActive(true);
            PlayerManager.instance.DropItem = true;
        }
        if (GamePlayHandler.instance.currentObjectiveIndex == 3)
        {
            if (PlayerManager.instance.currentPickable != null)
            {
                PlayerManager.instance.currentPickable.SetActive(false);
            }
            PlayerManager.instance.DummyTorch.SetActive(true);
            PlayerManager.instance.Itempick = true;

        }
        if (GamePlayHandler.instance.currentObjectiveIndex == 4)
        {
            if (PlayerManager.instance.currentPickable != null)
            {
                PlayerManager.instance.currentPickable.SetActive(false);
            }
            PlayerManager.instance.DummyKey.SetActive(true);
            PlayerManager.instance.DropItem = true;
        }
        if (GamePlayHandler.instance.currentObjectiveIndex == 6)
        {
            if (PlayerManager.instance.currentPickable != null)
            {
                PlayerManager.instance.currentPickable.SetActive(false);
            }
            PlayerManager.instance.DummyHammer.SetActive(true);
            PlayerManager.instance.DropItem = true;
        }

    }
    public void Home()
    {
        //Self SoundManager.Instance.PlayEffect(AudioClipsSource.Instance.GenericButtonClip);
        Time.timeScale = 1;
        GameManagerScript.instance.ChangeScene("MainMenu");
    }
    public void DisAblePlayer()
    {
        GamePlayHandler.instance.Player.SetActive(false);
        GamePlayHandler.instance.PlayerControls.SetActive(false);
    }
    public void LevelCOmplete()
    {
        GamePlayHandler.instance.DisableAllAI_NUN();
        LevelsHandling.Instance.HealthHandle.enabled = false;
        Time.timeScale = 1;

        /////////////////////////////////// 
        /// 
        ///       COOMENTED ADS
        /// 
        ///////////////////////////////////

        //if (AdmobAdsManager.Instance.Internet == true)
        //{
        //    Firebase.Analytics.FirebaseAnalytics.LogEvent("LevelCompleted_" + GameManagerScript.instance.CurrentLevel);
        //}
        LevelCompletePanel.SetActive(true);
        GamePlayHandler.instance.DisableEnemy();
        DisAblePlayer();
        LevelCompletePanel.SetActive(true);
        if (GameManagerScript.instance.CurrentMode == 0)
        {
            if (GameManagerScript.instance.CurrentLevel >= PlayerPrefs.GetInt("Mode1Levels"))
            {
                if (MainMenuHandler.instance)
                {
                    PlayerPrefs.SetInt("Mode1Levels", MainMenuHandler.instance.Mode1 += 1);
                    Debug.Log("Level Unlock............" + PlayerPrefs.GetInt("Mode1Levels"));
                    MainMenuHandler.instance.Mode1 = PlayerPrefs.GetInt("Mode1Levels");
                }

            }
        }

    }
    public void LevelFailed()
    {
        //Self SoundManager.Instance.PlayEffect(AudioClipsSource.Instance.LevelFailedClip);
        DisAblePlayer();
        LevelsHandling.Instance.HealthHandle.enabled = false;
        GamePlayHandler.instance.DisableEnemy();
        LevelFailedPanel.SetActive(true);

        /////////////////////////////////// 
        /// 
        ///       COOMENTED ADS
        /// 
        ///////////////////////////////////

        //if (AdmobAdsManager.Instance.Internet == true)
        //{
        //    Firebase.Analytics.FirebaseAnalytics.LogEvent("LevelFailed_" + GameManagerScript.instance.CurrentLevel);
        //}
        BloodImg.SetActive(false);
        GamePlayHandler.instance.DisableAllAI_NUN();
        Time.timeScale = 1;
    }
    public void NextLevelBtn()
    {
        //Self SoundManager.Instance.PlayEffect(AudioClipsSource.Instance.GenericButtonClip);
        Time.timeScale = 1;
        if (GameManagerScript.instance.CurrentMode == 0)
        {
            if (GameManagerScript.instance.CurrentLevel >= 4)
            {
                GameManagerScript.instance.CurrentLevel = 0;
                GameManagerScript.instance.ChangeScene("MainMenu");
                LevelCompletePanel.SetActive(false);
            }
            else
            {
                GameManagerScript.instance.CurrentLevel++;
                GameManagerScript.instance.CurrentTask = 0;
                PlayerPrefs.SetInt("CurrentTask", GameManagerScript.instance.CurrentTask);
                GameManagerScript.instance.ChangeScene("Loading");
                LevelCompletePanel.SetActive(false);
            }
            Debug.Log("Loading Next Level");

        }
    }
}
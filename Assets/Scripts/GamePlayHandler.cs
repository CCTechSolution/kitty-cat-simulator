using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using System.Net;
using UnityEngine;
using UnityEngine.UI;

public class GamePlayHandler : MonoBehaviour
{
    public static GamePlayHandler instance;
    public GameObject Forest;
    public GameObject Env;
    public Modes[] GameModes;
    public HealthHandling healthHandle;
    public GameTimer timer;
    [Header("Player Objs")]
    public GameObject Player;
    public GameObject PlayerCam;
    public GameObject PlayerControls;
    public int PlayerPos;
    public bool UsingHealth = false;
    [Header("EndPoint")]
    public GameObject EndPoint;
    public int EndPointIndex;
    [Header("Level Objective")]
    public GameObject ObjectivePanel;
    public Text ObjectiveText;
    public int currentObjectiveIndex;
    public int currentFootIndex, current_AI_Index;
    [Header("Level Objs")]
    public GameObject LevelObjs;
    public int PIckableIndex;
    public GameObject BagParticle;
    [Header("Extraaas")]
    public GameObject Skipbtn;
    public GameObject FootStep;
    [Header("Dark Mode")]
    public GameObject[] Terrains;
    public Material DarkMat;
    public Material LightMat;

    private void Awake()
    {
        instance = this;
    }
    private void OnEnable()
    {
        if (GameManagerScript.instance.CurrentLevel == 0)
        {
            Forest.SetActive(true);
        }
        else
        {
            Env.SetActive(true);
        }
    }
    void Start()
    {
        if (GameManagerScript.instance.CurrentLevel == 0)
        {
            if (currentObjectiveIndex==2)
            {
                BagParticle.SetActive(true);
            }
        }
       //     PlayerPos = currentObjectiveIndex;
        healthHandle.enabled = false;
      timer.enabled = false;
       PlayerCam.GetComponent<Camera>().nearClipPlane = 0.003f;
      //  currentObjectiveIndex = 0;
        currentObjectiveIndex = PlayerPrefs.GetInt("CurrentTask", GameManagerScript.instance.CurrentTask);
       //   currentFootIndex = currentObjectiveIndex;
       //    EndPointIndex = 0;
      //     PIckableIndex = 0;
       TaskHandling();
        if (GameManagerScript.instance.CurrentLevel == 0 && EndPointIndex==0)
        {
            StartCinDelay();
            StartCoroutine(ActiveLevel());
        }
        else
        {
            ActiveObjectives();
            ActiveEnv();
            ActivePlayer();
            ActiveEndPoint();
            ActivePickables();
            ActiveEnemies();
            FootStep.SetActive(true);
            timer.enabled = true;
        }
        UIManager.instance.Revive();


        /////////////////////////////////// 
        /// 
        ///       COOMENTED ADS
        /// 
        ///////////////////////////////////

        //AdmobAdsManager.Instance.hideMediumBanner();
        //if (AdmobAdsManager.Instance.Internet == true)
        //{
        //    Firebase.Analytics.FirebaseAnalytics.LogEvent("Gameplay_Start");
        //}
    }
    public void TaskHandling()
    {
        currentObjectiveIndex = PlayerPrefs.GetInt("CurrentTask", GameManagerScript.instance.CurrentTask);
        Debug.Log("My Current Objective is: " + currentObjectiveIndex);
        if (GameManagerScript.instance.CurrentLevel == 0)
        {
            if (currentObjectiveIndex == 0)
            {
                EndPointIndex = 0;
                PlayerPos = 0;
                current_AI_Index = 0;
                PIckableIndex = 0;
                currentFootIndex = 0;              
            }
            if (currentObjectiveIndex == 1)
            {
                EndPointIndex = 1;
                PlayerPos = 0;
                current_AI_Index = 1;
                PIckableIndex = 1;
                currentFootIndex = 1;
            }
            if (currentObjectiveIndex == 2)
            {
                EndPointIndex = 1;
                PlayerPos = 1;
                current_AI_Index = 2;
                PIckableIndex = 1;
                currentFootIndex = 1;
            }
            if (currentObjectiveIndex == 3)
            {
                EndPointIndex = 2;
                PlayerPos = 3;
                current_AI_Index = 3;
                PIckableIndex = 2;
                currentFootIndex = 2;
            }
            if (currentObjectiveIndex == 4)
            {
                EndPointIndex = 3;
                PlayerPos = 3;
                current_AI_Index = 4;
                PIckableIndex = 3;
                currentFootIndex = 4;
            }
            if (currentObjectiveIndex == 5)
            {
                EndPointIndex = 3;
                PlayerPos = 5;
                current_AI_Index = 5;
                PIckableIndex = 3;
                currentFootIndex = 4;
            }
            if (currentObjectiveIndex == 6)
            {
                EndPointIndex = 5;
                PlayerPos = 6;
                current_AI_Index = 6;
                PIckableIndex = 5;
                currentFootIndex = 6;
            }
          UIManager.instance.InventoryHandling();
        }    
    }
    public void ActiveEnv()
    {
        GameModes[GameManagerScript.instance.CurrentMode].GameLevels[GameManagerScript.instance.CurrentLevel].CurrentEnv.SetActive(true);
    }
    public void ActivePlayer()
    {
        if (currentObjectiveIndex == 0)
        {
            Player.transform.position = GameModes[GameManagerScript.instance.CurrentMode].GameLevels[GameManagerScript.instance.CurrentLevel].PlayerPos.transform.position;
            Player.transform.rotation = GameModes[GameManagerScript.instance.CurrentMode].GameLevels[GameManagerScript.instance.CurrentLevel].PlayerPos.transform.rotation;
            Debug.Log("Task 0 "+currentObjectiveIndex);
        }
        else
        {
            Player.transform.position = GameModes[GameManagerScript.instance.CurrentMode].GameLevels[GameManagerScript.instance.CurrentLevel].PlayerPosWithinChapter[PlayerPos].transform.position;
            Player.transform.rotation = GameModes[GameManagerScript.instance.CurrentMode].GameLevels[GameManagerScript.instance.CurrentLevel].PlayerPosWithinChapter[PlayerPos].transform.rotation;
            Debug.Log("Task else "+currentObjectiveIndex);
            Debug.Log("Task PLayerPos " + PlayerPos);
        }  

        Player.SetActive(true);
        PlayerCam.SetActive(true);
        PlayerControls.SetActive(true);
        UsingHealth = true;
        if (GameManagerScript.instance.CurrentLevel == 0)
        {
            if (EndPointIndex == 0)
            {
                ActivePickables();
                PathDrawToTestination.instance.StartPathDraw = true;
            }
            else
            {
                PathDrawToTestination.instance.StartPathDraw = false;
            }
        }
    }

    public void SetPlayerPos()
    {
        if (GameManagerScript.instance.CurrentLevel == 0)
        {
            if (currentObjectiveIndex == 0)
            {
                PlayerPos = 0;
            }
            if (currentObjectiveIndex == 1)
            {
                PlayerPos = 0;
            }
            if (currentObjectiveIndex == 2)
            {
                PlayerPos = 1;
            }
            if (currentObjectiveIndex == 3)
            {
                PlayerPos = 3;
            }
            if (currentObjectiveIndex == 4)
            {
                PlayerPos = 3;
            }
            if (currentObjectiveIndex == 5)
            {
                PlayerPos = 4;
            }
            if (currentObjectiveIndex == 6)
            {
                PlayerPos = 6;
            }
        }
            if (GameModes[GameManagerScript.instance.CurrentMode].GameLevels[GameManagerScript.instance.CurrentLevel].PlayerPosWithinChapter.Length > PlayerPos)
        {
            if (GameModes[GameManagerScript.instance.CurrentMode].GameLevels[GameManagerScript.instance.CurrentLevel].PlayerPosWithinChapter[PlayerPos] != null)
            {
                Player.SetActive(false);
                Player.transform.position = GameModes[GameManagerScript.instance.CurrentMode].GameLevels[GameManagerScript.instance.CurrentLevel].PlayerPosWithinChapter[PlayerPos].transform.position;
                Player.transform.rotation = GameModes[GameManagerScript.instance.CurrentMode].GameLevels[GameManagerScript.instance.CurrentLevel].PlayerPosWithinChapter[PlayerPos].transform.rotation;
                Player.SetActive(true);
                PlayerPos += 1;
              ////  PlayerCam.SetActive(true);
             ////   PlayerControls.SetActive(true);
              //  UsingHealth = true;
            }
        }
    }
    public void ActiveAI_NUN()
    {
        if (!OnCheckDelay)
        {
            OnCheckDelay = true;
            DisableAllAI_NUN();

            if (GameModes[GameManagerScript.instance.CurrentMode].GameLevels[GameManagerScript.instance.CurrentLevel].IA_Nun.Length > current_AI_Index)
            {
                if (GameModes[GameManagerScript.instance.CurrentMode].GameLevels[GameManagerScript.instance.CurrentLevel].IA_Nun[current_AI_Index] != null)//-1
                {
                    GameModes[GameManagerScript.instance.CurrentMode].GameLevels[GameManagerScript.instance.CurrentLevel].IA_Nun[current_AI_Index].SetActive(true);
                    Invoke(nameof(DelayNun), 5);
                }
            }

        }
    }
    void DelayNun()
    {
        OnCheckDelay = false;
        current_AI_Index++;

    }
    bool OnCheckDelay;
    public void DisableAllAI_NUN()
    {
        GameObject[] All_AI = GameModes[GameManagerScript.instance.CurrentMode].GameLevels[GameManagerScript.instance.CurrentLevel].IA_Nun;
        for (int i = 0; i < All_AI.Length; i++)
        {
            if (All_AI[i] != null)
            {
                All_AI[i].SetActive(false);
            }
        }
    }
    public void ActiveFootSteps()
    {
     //   UIManager.instance.HintBtn.interactable = false;  // commented by Rbiaaa 
        DisableAllFootSteps();

        if (GameModes[GameManagerScript.instance.CurrentMode].GameLevels[GameManagerScript.instance.CurrentLevel].FootStepLvl.Length > currentFootIndex)
        {
            if (GameModes[GameManagerScript.instance.CurrentMode].GameLevels[GameManagerScript.instance.CurrentLevel].FootStepLvl[currentFootIndex] != null)//-1
            {
                GameModes[GameManagerScript.instance.CurrentMode].GameLevels[GameManagerScript.instance.CurrentLevel].FootStepLvl[currentFootIndex].SetActive(true);
            }
        }
    }
    public void DisableAllFootSteps()
    {
        GameObject[] footstep = GameModes[GameManagerScript.instance.CurrentMode].GameLevels[GameManagerScript.instance.CurrentLevel].FootStepLvl;
        for (int i = 0; i < footstep.Length; i++)
        {
            if (footstep[i] != null)
            {
                footstep[i].SetActive(false);
            }
        }
    }
    public void ActiveEndPoint()
    {
        if (GameManagerScript.instance.CurrentLevel != 0 || EndPointIndex != 0)
        {
            DisableAllFootSteps();
        }

        if (EndPointIndex < GameModes[GameManagerScript.instance.CurrentMode].GameLevels[GameManagerScript.instance.CurrentLevel].EndPointPos.Length)
        {
            EndPoint.transform.position = GameModes[GameManagerScript.instance.CurrentMode].GameLevels[GameManagerScript.instance.CurrentLevel].EndPointPos[EndPointIndex].transform.position;
            EndPoint.transform.rotation = GameModes[GameManagerScript.instance.CurrentMode].GameLevels[GameManagerScript.instance.CurrentLevel].EndPointPos[EndPointIndex].transform.rotation;
            EndPoint.SetActive(true);
        }
        else
        {
            if (GameModes[GameManagerScript.instance.CurrentMode].GameLevels[GameManagerScript.instance.CurrentLevel].EndCin != null)
            {
                EndCinDelay();
                UIManager.instance.OnLevelComplete.Invoke();
            }
            else
            {
                UIManager.instance.OnLevelComplete.Invoke();
            }
        }
    }
    public void ActiveObjectives()
    {

        if (GameModes[GameManagerScript.instance.CurrentMode].GameLevels[GameManagerScript.instance.CurrentLevel].LevelObjective != null)
        {
            string[] objectives = GameModes[GameManagerScript.instance.CurrentMode].GameLevels[GameManagerScript.instance.CurrentLevel].LevelObjective;
            if (currentObjectiveIndex < objectives.Length)
            {
                ObjectiveText.text = objectives[currentObjectiveIndex];
                ObjectivePanel.SetActive(true);
                GameManagerScript.instance.CurrentTask = currentObjectiveIndex;
                PlayerPrefs.SetInt("CurrentTask", GameManagerScript.instance.CurrentTask);
            }
            else
            {
                Debug.Log("No More Objectivesssss");
                ObjectivePanel.SetActive(false);
            }
        }
    }
    public void ActiveEnemies()
    {
        //if (GameModes[GameManagerScript.instance.CurrentMode].GameLevels[GameManagerScript.instance.CurrentLevel].Enemies != null)
        //{
        //    for (int m = 0; m < GameModes[GameManagerScript.instance.CurrentMode].GameLevels[GameManagerScript.instance.CurrentLevel].Enemies.Length; m++)
        //    {

        //        if (GameModes[GameManagerScript.instance.CurrentMode].GameLevels[GameManagerScript.instance.CurrentLevel].Enemies[m] != null)
        //        {
        //            GameModes[GameManagerScript.instance.CurrentMode].GameLevels[GameManagerScript.instance.CurrentLevel].Enemies[m].SetActive(true);
        //        }

        //    }
        //}

    }
    public void DisableEnemy()
    {
        if (GameModes[GameManagerScript.instance.CurrentMode].GameLevels[GameManagerScript.instance.CurrentLevel].Enemies != null)
        {
            for (int n = 0; n < GameModes[GameManagerScript.instance.CurrentMode].GameLevels[GameManagerScript.instance.CurrentLevel].Enemies.Length; n++)
            {
                if (GameModes[GameManagerScript.instance.CurrentMode].GameLevels[GameManagerScript.instance.CurrentLevel].Enemies[n] != null)
                {
                    GameModes[GameManagerScript.instance.CurrentMode].GameLevels[GameManagerScript.instance.CurrentLevel].Enemies[n].SetActive(false);
                }
            }
        }
    }
    public IEnumerator ActiveStartCin()
    {
        if (GameModes[GameManagerScript.instance.CurrentMode].GameLevels[GameManagerScript.instance.CurrentLevel].StartCin != null)
        {
            GameModes[GameManagerScript.instance.CurrentMode].GameLevels[GameManagerScript.instance.CurrentLevel].StartCin.SetActive(true);
            yield return new WaitForSeconds(GameModes[GameManagerScript.instance.CurrentMode].GameLevels[GameManagerScript.instance.CurrentLevel].StartCinTime);
            GameModes[GameManagerScript.instance.CurrentMode].GameLevels[GameManagerScript.instance.CurrentLevel].StartCin.SetActive(false);
            FootStep.SetActive(true);
        }
    }
    public bool GetActiveCutscene(int value)
    {
        if (GameModes[GameManagerScript.instance.CurrentMode].GameLevels[GameManagerScript.instance.CurrentLevel].EndCin[value] != null)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    public void StartCinDelay()
    {
        FootStep.SetActive(false);
        Skipbtn.SetActive(true);
        StartCoroutine(ActiveStartCin());
    }
    public IEnumerator ActiveEndCin()
    {
        MatHandle();
        if (GameModes[GameManagerScript.instance.CurrentMode].GameLevels[GameManagerScript.instance.CurrentLevel].EndCin != null)
        {
            GameModes[GameManagerScript.instance.CurrentMode].GameLevels[GameManagerScript.instance.CurrentLevel].EndCin[currentObjectiveIndex].SetActive(true);
            yield return new WaitForSeconds(GameModes[GameManagerScript.instance.CurrentMode].GameLevels[GameManagerScript.instance.CurrentLevel].EndCinTime);
            GameModes[GameManagerScript.instance.CurrentMode].GameLevels[GameManagerScript.instance.CurrentLevel].EndCin[currentObjectiveIndex].SetActive(false);
            UIManager.instance.Ad.SetActive(true);
            ActiveNow();

        }
    }
    public void EndCinDelay()
    {
        LevelObjs.SetActive(false);
        Player.SetActive(false);
        PlayerControls.SetActive(false);
        PlayerCam.SetActive(false);
        ObjectivePanel.SetActive(false);
        StartCoroutine(ActiveEndCin());


    }
    public void CallLastCin()
    {
        StartCoroutine(LastCinActive());
    }
    public IEnumerator LastCinActive()
    {
        GameModes[GameManagerScript.instance.CurrentMode].GameLevels[GameManagerScript.instance.CurrentLevel].EndCin[7].SetActive(true);
        yield return new WaitForSeconds(GameModes[GameManagerScript.instance.CurrentMode].GameLevels[GameManagerScript.instance.CurrentLevel].EndCinTime);
        GameModes[GameManagerScript.instance.CurrentMode].GameLevels[GameManagerScript.instance.CurrentLevel].EndCin[7].SetActive(false);
        //   UIManager.instance.Ad.SetActive(true);
        UIManager.instance.OnLevelComplete.Invoke();
    }
    public void ActiveNow()
    {
        LevelObjs.SetActive(true);
        Player.SetActive(true);
        PlayerControls.SetActive(true);
        PlayerCam.SetActive(true);
        ObjectivePanel.SetActive(true);

    }
    public IEnumerator ActiveLevel1LastCin()
    {
        GameModes[GameManagerScript.instance.CurrentMode].GameLevels[GameManagerScript.instance.CurrentLevel].EndCin[currentObjectiveIndex].SetActive(true);
        yield return new WaitForSeconds(GameModes[GameManagerScript.instance.CurrentMode].GameLevels[GameManagerScript.instance.CurrentLevel].EndCinTime);
        GameModes[GameManagerScript.instance.CurrentMode].GameLevels[GameManagerScript.instance.CurrentLevel].EndCin[currentObjectiveIndex].SetActive(false);
        UIManager.instance.Ad.SetActive(true);
        UIManager.instance.LevelCOmplete();

    }
    public void ActivePickables()
    {
        if (GameModes[GameManagerScript.instance.CurrentMode].GameLevels[GameManagerScript.instance.CurrentLevel].Pickable != null)
        {
            if (PIckableIndex < GameModes[GameManagerScript.instance.CurrentMode].GameLevels[GameManagerScript.instance.CurrentLevel].Pickable.Length)
                GameModes[GameManagerScript.instance.CurrentMode].GameLevels[GameManagerScript.instance.CurrentLevel].Pickable[PIckableIndex].SetActive(true);

        }
    }
    public void MatHandle()
    {
        if (GameManagerScript.instance.CurrentMode == 0)
        {
            if (GameManagerScript.instance.CurrentLevel == 0)
            {
                if (currentObjectiveIndex == 3)
                {
                    if (Terrains != null)
                    {
                        for (int m = 0; m < Terrains.Length; m++)
                        {
                            Terrains[m].GetComponent<MeshRenderer>().material = DarkMat;
                        }
                    }
                }
                else
                {
                    if (Terrains != null)
                    {
                        for (int m = 0; m < Terrains.Length; m++)
                        {
                            Terrains[m].GetComponent<MeshRenderer>().material = LightMat;
                        }
                    }
                }
            }
        }


    }
    IEnumerator ActiveLevel()
    {
        yield return new WaitForSeconds(GameModes[GameManagerScript.instance.CurrentMode].GameLevels[GameManagerScript.instance.CurrentLevel].StartCinTime);
        UIManager.instance.Ad.SetActive(true);
        yield return new WaitForSeconds(4f);
        Skipbtn.SetActive(false);
        ActiveObjectives();
        ActiveEnv();
        ActivePlayer();
        ActiveEndPoint();
        ActiveObjectives();
        ActivePickables();
        ActiveEnemies();
        FootStep.SetActive(true);
        ActiveFootSteps();
        timer.enabled = true;
        StartCoroutine(HealthHandling.instance.ActiveAdPanel());
    }
    public void OnClickOkbtn()
    {
        healthHandle.enabled = true;
        GameManagerScript.instance.CurrentTask = PlayerPrefs.GetInt("CurrentTask", GameManagerScript.instance.CurrentTask);
        TaskHandling();
        MatHandle();
        EndPoint.SetActive(true);
        ObjectivePanel.SetActive(false);
        FootStep.SetActive(true);
        PlayerManager.instance.HandleObjectives();
        if (GameManagerScript.instance.CurrentLevel == 0)
        {
            if (currentObjectiveIndex == 1)
            {
                LevelsHandling.Instance.Football.SetActive(true);
                LevelsHandling.Instance.ScareMeTrigger.SetActive(true);
                LevelsHandling.Instance.ScarePlayerTrigger.SetActive(true);
            }
            if (currentObjectiveIndex == 2)
            {
                LevelsHandling.Instance.BoxTrigger.SetActive(true);
                LevelsHandling.Instance.Box.SetActive(true);
                BagParticle.SetActive(true);
            }
            if (currentObjectiveIndex == 3)
            {
                LevelsHandling.Instance.WheelChair.SetActive(true);
                LevelsHandling.Instance.crawlingNun.SetActive(true);
            }
            if (currentObjectiveIndex == 4)
            {
                LevelsHandling.Instance.ChairTrigger.SetActive(true);
                LevelsHandling.Instance.RevolvingChair.SetActive(true);
            }
            if (currentObjectiveIndex == 5)
            {
              LevelsHandling.Instance.HouseTrigger.SetActive(true);
            }
        }
        if (GameManagerScript.instance.CurrentLevel == 1)
        {
            LevelsHandling.Instance.CrawlingGranny.SetActive(true);
        }

        /////////////////////////////////// 
        /// 
        ///       COOMENTED ADS
        /// 
        ///////////////////////////////////

        //if (AdmobAdsManager.Instance.Internet == true)
        //{
        //    Firebase.Analytics.FirebaseAnalytics.LogEvent("Level_" + GameManagerScript.instance.CurrentLevel + "Task_" + currentObjectiveIndex + "Start");
        //}
    }
}
[System.Serializable]
public class Modes
{
    public Levels[] GameLevels;
}
[System.Serializable]
public class Levels
{
    [Header("Level Info")]
    public GameObject CurrentEnv;
    public Transform PlayerPos;
    public Transform[] PlayerPosWithinChapter;
    public Transform[] EndPointPos;
    public string[] LevelObjective;
    public GameObject StartCin;
    public int StartCinTime;
    public GameObject[] EndCin;
    public int EndCinTime;
    public bool[] ItemPickReq, ItemDropReq;
    public GameObject[] Enemies;
    public GameObject[] Pickable;
    public GameObject[] FootStepLvl;
    public GameObject[] IA_Nun;
}

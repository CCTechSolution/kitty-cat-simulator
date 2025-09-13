using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameEventManager : MonoBehaviour
{
    public static GameEventManager Instance { get; private set; }
    public GameObject fadeForLevelFail;
    public GameObject fadeForLevelComplete;
    public GameObject pausePanel;
    public GameObject settingPanel;
    public GameObject failPanel;
    public GameObject completePanel;
    public GameObject gamePlayConrollers;

    [Space(10)]
    [SerializeField] Granny grannyController;
    [SerializeField] ObjectiveManager objectiveManager;
    [SerializeField] Player_Interaction playerInteraction;


    public static event Action OnLevelFail;
    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }

    public void LevelComplete()
    {
        if (Sfx_Manager.Instance)
        {
            Sfx_Manager.PlayRandomSound(Sfx_Manager.Instance.MissionComplete);
        }
        //SceneManager.LoadScene("Gameplay");
        gamePlayConrollers.SetActive(false);
        fadeForLevelComplete.SetActive(true);
        grannyController.ResetGrannyStateToWandering();
        playerInteraction.ResetHoldingState();
        Debug.Log("level complete");
    }

    public void LevelFail()
    {        
        gamePlayConrollers.SetActive(false);
        fadeForLevelFail.SetActive(true);
        OnLevelFail?.Invoke();
    }

    public void Restart()
    {
        Grabable_Item.ResetAllObjects();
        Time.timeScale = 1.0f;
    }

    public void Resume()
    {
        if (Sfx_Manager.Instance)
        {
            Sfx_Manager.PlayRandomSound(Sfx_Manager.Instance.PauseResume);
        }

        pausePanel.SetActive(false);
        gamePlayConrollers.SetActive(true);
        Time.timeScale = 1.0f;
    }

    public void Pause()
    {
        if (Sfx_Manager.Instance)
        {
            Sfx_Manager.PlayRandomSound(Sfx_Manager.Instance.PauseResume);
        }

        gamePlayConrollers?.SetActive(false);
        pausePanel.SetActive(true);
        //Time.timeScale = 0.35f;
    }

    public void NextObjective()
    {

        ObjectiveManager.Instance.StartNextObjective();
    }

    public void Home()
    {
        SceneManager.LoadScene("MainMenu");
        Time.timeScale = 1f;
    }

    public void Setting()
    {
        if (Sfx_Manager.Instance)
        {
            Sfx_Manager.PlayRandomSound(Sfx_Manager.Instance.PauseResume);
        }

        gamePlayConrollers.SetActive(false);
        settingPanel.SetActive(true);
        //Time.timeScale = 0.35f;
    } 
    public void SettingBack()
    {

        gamePlayConrollers.SetActive(true);
        settingPanel.SetActive(false);
        Time.timeScale = 1f;
    }

    public void RetryAtFail()
    {
        if (Sfx_Manager.Instance)
        {
            Sfx_Manager.PlayRandomSound(Sfx_Manager.Instance.PauseResume);
        }

        failPanel.SetActive(false);
        gamePlayConrollers.SetActive(true);
        Grabable_Item.ResetAllObjects();
        grannyController.ResetGrannyStateToWandering();
        objectiveManager.StartNextObjective();
        playerInteraction.ResetHoldingState();
        Time.timeScale = 1.0f;
        //SceneManager.LoadScene("Gameplay");
    }
}

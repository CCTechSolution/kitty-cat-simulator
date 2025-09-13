using System;
using System.Collections.Generic;
using UnityEngine;

public class ObjectiveManager : MonoBehaviour
{
    public static ObjectiveManager Instance { get; private set; }

    public List<BaseObjective> Objectives = new List<BaseObjective>();

    private int currentObjectiveIndex = 0;
    private List<IObjectiveListener> listeners = new List<IObjectiveListener>();
    private const string OBJECTIVE_PROGRESS_KEY = "ObjectiveProgress";
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
            Debug.LogWarning(gameObject.name + " has been destroyed because another instance existed");
        }
    }

    private void Start()
    {

        LoadProgress();

        foreach (var objective in Objectives)
        {
            objective.gameObject.SetActive(false);
        }
    }

    private void OnEnable()
    {
        StartNextObjective();
    }

    public void RegisterListener(IObjectiveListener objectiveListener)
    {
        if (!listeners.Contains(objectiveListener))
        {
            listeners.Add(objectiveListener);
        }
    }

    public void StartNextObjective()
    {
        if (currentObjectiveIndex >= Objectives.Count)
        {
            Debug.Log("All Objectives completed");
            return;
        }
        BaseObjective currentObjective = Objectives[currentObjectiveIndex];
        currentObjective.gameObject.SetActive(true);
        currentObjective.StartObjective();

        NotifyObjectiveUpdated(currentObjective);
    }

    public void OnObjectiveCompleted(BaseObjective completedObjective)
    {
        if (currentObjectiveIndex >= Objectives.Count) return;

        SaveProgress(currentObjectiveIndex);

        completedObjective.gameObject.SetActive(false);
        currentObjectiveIndex++;

        GameEventManager.Instance.LevelComplete();

        //if (currentObjectiveIndex < Objectives.Count)
        //{
        //    StartNextObjective();
        //}
        //else
        //{
        //    Debug.Log("All Objectives Completed! Level Complete!");
        //}
    }

    private void NotifyObjectiveUpdated(BaseObjective objective)
    {
        foreach (var listener in listeners)
        {
            listener.OnObjectiveUpdated(objective);
        }
    }

    private void SaveProgress(int completedIndex)
    {
        PlayerPrefs.SetInt(OBJECTIVE_PROGRESS_KEY, completedIndex + 1);
        PlayerPrefs.Save();
        Debug.Log("Objective progress saved: " + (completedIndex + 1));
    }


    private void LoadProgress()
    {
        currentObjectiveIndex = PlayerPrefs.GetInt(OBJECTIVE_PROGRESS_KEY, 0);
        Debug.Log("Loaded Objective Progress: " + currentObjectiveIndex);
    }


    public void ResetProgress()
    {
        PlayerPrefs.DeleteKey(OBJECTIVE_PROGRESS_KEY);
        PlayerPrefs.Save();
        currentObjectiveIndex = 0;
        Debug.Log("Objective progress reset!");
    }
}

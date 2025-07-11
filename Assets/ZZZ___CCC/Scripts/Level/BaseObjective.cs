using System;
using UnityEngine;

public abstract class BaseObjective : MonoBehaviour
{
    public bool InKitchen;
    public bool InLivingRoom;
    public bool InSecondFloorHalf;
    public bool InSecondFloorFull;

    public string ObjectiveText;
    public string LongObjectiveText;
    public bool IsCompleted {  get; private set; }

    public static event Action<float> OnProgressUpdated;
    public static event Action<int, int> OnProgressCounterUpdate;

    protected Granny granny;

    [SerializeField] protected int totalCount;
    protected int currentCount;

    protected virtual void Awake()
    {
        granny = (Granny)Resources.FindObjectsOfTypeAll(typeof(Granny))[0];
    }

    private void OnEnable()
    {
        RegisterEvent();
        if (InKitchen)
        {
            CatGranPos.Instance.InKitchen1stFloor();
            SetWayPoints.Instance.ToKitchen();
        }
        else if (InLivingRoom)
        {
            CatGranPos.Instance.InLivingRoom1stFloor();
            SetWayPoints.Instance.ToLivingRoom();
        }
        else if (InSecondFloorHalf)
        {
            CatGranPos.Instance.InSecondFloor();
            SetWayPoints.Instance.ToSecondFloorHalf();
        }
        else if (InSecondFloorFull)
        {
            CatGranPos.Instance.InSecondFloor();
            SetWayPoints.Instance.ToSecondFloorFull();
        }
    }

    private void OnDestroy()
    {
        UnregisterEvent();
    }
    


    public void CompleteObjective()
    {
        if (IsCompleted)
        {
            return;
        }
        UI_Manager.Instance.AddDiamond(25);
        GameEventManager.Instance.LevelComplete();
        IsCompleted = true;
        Debug.Log($"Objective Completed: {ObjectiveText}");
        ObjectiveManager.Instance.OnObjectiveCompleted(this);
    }

    public void StartObjective()
    {
        UI_Manager.Instance.UpdateMainQuest(ObjectiveText);
        UI_Manager.Instance.ObjectiveUpdateUI(LongObjectiveText);
        currentCount = 0;
        UpdateProgress(0f);
        OnRetry();
        UpdateProgressCounter(currentCount, totalCount);
        OnObjectiveStarted();
    }


    protected virtual void OnRetry()
    {

    }
    public void Success()
    {
        currentCount++;
        ExtrasWithSuccess();
        float progress = GetCurrentProgress();

        UpdateProgress(progress);
        UpdateProgressCounter(currentCount, totalCount);
        CheckCompletion();
    }

    protected virtual void ExtrasWithSuccess()
    {

    }

    protected virtual void ToggleIndicators(GameObject[] gb, bool condition)
    {
        foreach (GameObject go in gb)
        {
            go.SetActive(condition);
        }
    }

    protected void CheckCompletion()
    {
        if (currentCount >= totalCount)
        {
            CompleteObjective();
        }
    }

    protected void UpdateProgress(float progress)
    {
        OnProgressUpdated?.Invoke(progress);
    }

    protected void UpdateProgressCounter(int current, int total)
    {
        OnProgressCounterUpdate?.Invoke(current, total);
    }

    public float GetCurrentProgress()
    {
        return (float)currentCount / totalCount;
    }

    protected abstract void RegisterEvent();
    protected abstract void UnregisterEvent();
    protected virtual void OnObjectiveStarted() { }


}

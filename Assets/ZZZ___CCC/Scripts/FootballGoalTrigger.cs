using System;
using UnityEngine;

public class FootballGoalTrigger : MonoBehaviour
{
    public static event Action OnFootballEnterGoal;
    bool canGoal = true;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Ball"))
        {
            if (canGoal)
            {
                OnFootballEnterGoal?.Invoke();
                Debug.Log("Event fired for foot ball goal");
                canGoal = false;
                Invoke(nameof(CanGoalTrue), 1f);
            }
            
        }
    }

    void CanGoalTrue()
    {
        canGoal = true;
    }
}

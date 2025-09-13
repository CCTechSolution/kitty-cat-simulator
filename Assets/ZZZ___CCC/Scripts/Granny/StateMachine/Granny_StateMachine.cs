using System;
using UnityEngine;
using UnityEngine.UI;

public class Granny_StateMachine : MonoBehaviour
{
    [Header("Testing")]
    [SerializeField] Text currentStateText;

    private GrannyState currentState;


    public void Initialize(GrannyState startState)
    {
        currentState = startState;
        currentState.EnterState();
        Debug.Log("Player enetered :" + currentState);
        currentStateText.text = "Current state : " + currentState.ToString();
    }

    public void ChangeState(GrannyState newState)
    {
        if (currentState != null)
        {
            currentState.ExitState();
        }
        
        currentState = newState;
        currentState.EnterState();
        Debug.Log("Granny state changed to : "+ currentState);
        currentStateText.text = "Current state : " + currentState.ToString();
    }
    


    // update current state at each frame if its not null
    private void Update()
    {
        if (currentState == null)
        {
            Debug.Log("Current State is null");
            return;
        }
        currentState.UpdateState();
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimerAdHandler : MonoBehaviour
{
    public GameTimer Timer;
    private void OnEnable()
    {
        if(Timer != null)
        {
            Timer.enabled = false;
        }
        else
        {
            Debug.LogWarning("Timer component reference is null!");
        }
    }
    private void OnDisable()
    {
        if (Timer != null)
        {
            Timer.enabled = true;
        }
        else
        {
            Debug.LogWarning("Timer component reference is null!");
        }

    }
}

using System;
using UnityEngine;

public class Granny_EventManager : MonoBehaviour
{
    public static event Action OnGrannyAngry;

    public static void TriggerGrannyAngry()
    {
        OnGrannyAngry?.Invoke();    
    }

}

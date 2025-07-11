using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enable_Off_Disable_On : MonoBehaviour
{
    public GameObject JoyStick;
    private void OnEnable()
    {
        if (JoyStick != null)
            JoyStick.SetActive(false);
    }
    private void OnDisable()
    {
        if (JoyStick != null)
            JoyStick.SetActive(true);
    }
}

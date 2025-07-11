using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerprefsTest : MonoBehaviour
{
    private void Update()
    {
        ResetPlayerPrefs();
    }
   void ResetPlayerPrefs()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            PlayerPrefs.SetInt("L1", 1);
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            PlayerPrefs.SetInt("L2", 1);
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            PlayerPrefs.SetInt("L3", 1);
        }
        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            PlayerPrefs.SetInt("L4", 1);
        }
        if (Input.GetKeyDown(KeyCode.Alpha5))
        {
            PlayerPrefs.SetInt("L5", 1);
        }
        if (Input.GetKeyDown(KeyCode.Alpha6))
        {
            PlayerPrefs.SetInt("L6", 1);
        }
        if (Input.GetKeyDown(KeyCode.Alpha7))
        {
            PlayerPrefs.SetInt("L7", 1);
        }
        if (Input.GetKeyDown(KeyCode.Alpha8))
        {
            PlayerPrefs.SetInt("L8", 1);
        }
        if (Input.GetKeyDown(KeyCode.Alpha9))
        {
            PlayerPrefs.SetInt("L9", 1);
        }

        if (Input.GetKeyDown(KeyCode.KeypadEnter))
        {
            PlayerPrefs.SetInt("Tutorial", 1);
        }
        if (Input.GetKeyDown(KeyCode.Backspace))
        {
            PlayerPrefs.SetInt("Tutorial", 0);
        }
    }
}

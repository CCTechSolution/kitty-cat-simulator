using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AD_Cng_Pos : MonoBehaviour
{
    [Header("On")]
    public GameObject BT;

    [Header("Off")]
    public GameObject BR;

    void OnEnable()
    {
        BT.SetActive(true);
        BR.SetActive(false);
    }
    void OnDisable()
    {
        if (BT == null || BR == null)
        {
            Debug.Log("...");
        }
        else
        {
            BT.SetActive(false);
            BR.SetActive(true);
        }
    }
}
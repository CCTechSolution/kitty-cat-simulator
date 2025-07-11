using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fade_Level_Complete : MonoBehaviour
{
    [SerializeField] GameObject congratsPanel;
    [SerializeField] GameObject gamePlayPanel;

    public void OnFadeStart()
    {
        gamePlayPanel.SetActive(false);
    }

    public void OnFadeComplete()
    {
        gameObject.SetActive(false);
        congratsPanel.SetActive(true);
    }
}

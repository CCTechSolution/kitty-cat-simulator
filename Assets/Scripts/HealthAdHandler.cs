using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthAdHandler : MonoBehaviour
{
    public HealthHandling HealthAd;
    private void OnEnable()
    {
        HealthAd.enabled = false;
    }
    private void OnDisable()
    {
        HealthAd.enabled = true;
    }
}

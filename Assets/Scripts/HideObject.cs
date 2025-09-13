using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HideObject : MonoBehaviour
{
    public float OffDelay = 2f;

    private void OnEnable()
    {
        Invoke(nameof(OffHere),OffDelay);
    }

    void OffHere()
    {
        gameObject.SetActive(false);
    }
}

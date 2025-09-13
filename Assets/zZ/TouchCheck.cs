using UnityEngine;
using System;

public class TouchCheck : MonoBehaviour
{
    public static event Action OnTouch;

    private void Update()
    {
        if (Input.touchCount > 0 || Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
        {
            OnTouch?.Invoke();
            Debug.Log("Touch Detected.................");
        }
    }
}

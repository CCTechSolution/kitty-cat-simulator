using UnityEngine;
using UnityEngine.Events;

public class OnEnable_Events : MonoBehaviour
{
    public UnityEvent OnEnableEvents;

    private void OnEnable()
    {
        OnEnableEvents?.Invoke();
    }
}

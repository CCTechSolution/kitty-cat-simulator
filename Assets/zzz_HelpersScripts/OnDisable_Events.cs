using UnityEngine;
using UnityEngine.Events;

public class OnDisable_Events : MonoBehaviour
{
    public UnityEvent OnDisableEvents;

    private void OnDisable()
    {
        OnDisableEvents?.Invoke();
    }
}

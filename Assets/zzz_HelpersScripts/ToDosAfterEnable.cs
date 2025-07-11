using UnityEngine;
using UnityEngine.Events;

public class ToDosAfterEnable : MonoBehaviour
{
    [SerializeField] float timeAfterEnable;

    public UnityEvent OnTimerCompleteAfterEnable;

    private void OnEnable()
    {
        Invoke(nameof(CallEvent), timeAfterEnable);
    }

    private void CallEvent()
    {
        OnTimerCompleteAfterEnable?.Invoke();        
    }
}

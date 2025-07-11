using UnityEngine;
using UnityEngine.Events;

public class ToDoAfterEnable : MonoBehaviour
{
    [SerializeField] float timeAfterEnable;
    public UnityEvent OnTimerComplete;
    private void OnEnable()
    {
        PlayerPrefs.SetInt("Guide", 1); 
        Invoke(nameof(LetsGo), timeAfterEnable);
    }

    void LetsGo()
    {
        OnTimerComplete?.Invoke();
    }
}

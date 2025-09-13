using UnityEngine;

public class FirstGuid : MonoBehaviour
{
    [SerializeField] float timeToDisable = 5f;
    private void Start()
    {
        TouchCheck.OnTouch += TouchCheck_OnTouch;
    }

    private void TouchCheck_OnTouch()
    {
        Invoke(nameof(DisableGameobject), timeToDisable);
    }

    void DisableGameobject()
    {
        gameObject.SetActive(false);
    }
}

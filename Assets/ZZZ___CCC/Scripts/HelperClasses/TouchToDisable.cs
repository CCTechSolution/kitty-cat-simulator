using UnityEngine;

public class TouchToDisable : MonoBehaviour
{
    [SerializeField] GameObject gObjToDisable;
    [SerializeField] float afterTime;

    private void OnEnable()
    {
        TouchCheck.OnTouch += TouchCheck_OnTouch;
    }
    private void OnDisable()
    {
        TouchCheck.OnTouch -= TouchCheck_OnTouch;
    }

    private void TouchCheck_OnTouch()
    {
        Invoke(nameof(DisableGameobject), afterTime);
    }

    void DisableGameobject()
    {
        gObjToDisable.SetActive(false);
    }
}

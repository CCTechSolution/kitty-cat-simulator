using UnityEngine;

public class Scene_Obj_On : MonoBehaviour
{
    public bool Timer;
    public GameObject Obj;
    void OnEnable()
    {
        Screen.sleepTimeout = SleepTimeout.NeverSleep;
        Obj.SetActive(true);
        if (Timer == true)
        {
            Time.timeScale = 1f;
        }
    }
}

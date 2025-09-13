using UnityEngine;

public class DisableGameObjAfterTime : MonoBehaviour
{
    [SerializeField] GameObject gObjToDisable;
    [SerializeField] float time;
    private void OnEnable()
    {
        Invoke(nameof(DisableGameobject), time);
    }
    void DisableGameobject()
    {
        gObjToDisable.SetActive(false);
    }
}

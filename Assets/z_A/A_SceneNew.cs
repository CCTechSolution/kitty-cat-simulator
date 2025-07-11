using UnityEngine;

public class A_SceneNew : MonoBehaviour
{
    [SerializeField] float timeToLoading;
    [SerializeField] GameObject[] gameobjectsToEnable;
    [SerializeField] GameObject[] gameobjectsToDisable;

    void Call()
    {
        foreach (GameObject obj in gameobjectsToEnable)
        {
            obj.SetActive(true);
        }
        foreach (GameObject obj in gameobjectsToDisable)
        {
            obj?.SetActive(false);
        }
    }

    private void OnEnable()
    {
        Invoke(nameof(Call), timeToLoading);
    }
}

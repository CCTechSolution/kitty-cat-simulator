using UnityEngine;

public class DiableGameObjectAfter : MonoBehaviour
{
    [SerializeField] float timerToDisable;
    [SerializeField] bool selfObject;
    [SerializeField] GameObject gameobjectToDisable;


    private void OnEnable()
    {
        Invoke(nameof(Disable_Gameobject), timerToDisable);
    }

    void Disable_Gameobject()
    {
        if (selfObject)
        {
            gameObject.SetActive(false);
        }
        else
        {
            if (gameobjectToDisable != null)
            {
                gameobjectToDisable.SetActive(false);
            }
            else
            {
                Debug.LogWarning("Nore self gameobject is selected nore gameobject is assigned to disable on script of " + gameObject.name);
            }
        }
    }
}

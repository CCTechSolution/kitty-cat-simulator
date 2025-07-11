using UnityEngine;

public class Fade : MonoBehaviour
{
    [SerializeField] GameObject granny;

    private void OnEnable()
    {
        Invoke(nameof(DisableGranny), 0.4f);
    }

    void DisableGranny()
    {
        granny.SetActive(false);
    }

    public void DisableThisGameObject()
    {
        gameObject.SetActive(false);
    }
}

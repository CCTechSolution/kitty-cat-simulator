using UnityEngine;

public class EnableAfter : MonoBehaviour
{
    [SerializeField] GameObject objectToEnable;
    [SerializeField] float timeAfterEnable;

    private void OnEnable()
    {
        Invoke(nameof(EnableGameObject), timeAfterEnable);
    }
    void EnableGameObject()
    {
        objectToEnable.SetActive(true);
    }
}

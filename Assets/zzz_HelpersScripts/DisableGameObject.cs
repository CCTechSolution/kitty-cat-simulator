using UnityEngine;

public class DisableGameObject : MonoBehaviour
{
    [SerializeField] GameObject obj;

    public void DisableGivenGameObject()
    {
        obj.SetActive(false);
    }
}

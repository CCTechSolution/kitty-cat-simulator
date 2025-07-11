using UnityEngine;

public class EnableAllChildGameobjects : MonoBehaviour
{
    public GameObject[] allChilds;

    private void OnEnable()
    {
        EnableAll();
    }

    public void EnableAll()
    {
        foreach (var child in allChilds)
        {
            child.SetActive(true);
        }
    }
}

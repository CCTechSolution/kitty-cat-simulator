using UnityEngine;

public class LevelManager : MonoBehaviour
{
    private void Start()
    {
        ObjectiveManager.Instance.StartNextObjective();
    }
}

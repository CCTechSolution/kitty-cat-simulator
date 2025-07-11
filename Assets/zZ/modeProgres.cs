using UnityEngine;

public class modeProgres : MonoBehaviour
{
    private void OnEnable()
    {
        if (PlayerPrefs.GetInt("modeSe") == 0)
        {
        }
    }
}

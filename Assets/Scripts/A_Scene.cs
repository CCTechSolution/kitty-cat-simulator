using UnityEngine;
using UnityEngine.SceneManagement;

public class A_Scene : MonoBehaviour
{
    [SerializeField] float afterTime;
    [SerializeField] string sceneNameToLoad;

    void Load_Scene()
    {
        SceneManager.LoadScene(sceneNameToLoad);
    }

    private void OnEnable()
    {
        Invoke(nameof(Load_Scene), afterTime);
    }
}

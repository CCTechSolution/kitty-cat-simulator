using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections;

public class LoadingManager : MonoBehaviour
{
    public Slider loadingSlider;
    public string sceneName;

    public void OnEnable()
    {
        StartCoroutine(LoadSceneAsync(sceneName));
    }

    private IEnumerator LoadSceneAsync(string sceneName)
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneName);
        operation.allowSceneActivation = false; 

        while (!operation.isDone)
        {

            float progress = Mathf.Clamp01(operation.progress / 0.9f);
            loadingSlider.value = progress;


            if (operation.progress >= 0.9f)
            {
                loadingSlider.value = 1f;
                yield return new WaitForSeconds(1f);

                operation.allowSceneActivation = true;
            }

            yield return null;
        }
    }
}

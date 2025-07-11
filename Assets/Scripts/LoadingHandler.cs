using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadingHandler : MonoBehaviour
{
    public Slider slider;
    public float loadingTime = 4f;
    void Start()
    {
        //if (AdmobAdsManager.Instance.Internet == true)
        //{
        //    Firebase.Analytics.FirebaseAnalytics.LogEvent("Loading");
        //}
        StartCoroutine(LoadScene());
    }
    IEnumerator LoadScene()
    {
        float elapsedTime = 0f;

        while (elapsedTime < loadingTime)
        {
            elapsedTime += Time.deltaTime;
            slider.value = elapsedTime / loadingTime;
            yield return null;
        }
        SceneManager.LoadScene("Gameplay");
    }
}

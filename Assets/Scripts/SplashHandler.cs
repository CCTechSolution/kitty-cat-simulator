using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using DG.Tweening;
using UnityEngine.UI;

public class SplashHandler : MonoBehaviour
{
    public float loadingTime = 6f;
    private void OnEnable()
    {
        StartCoroutine(LoadScene());
        //Self SoundManager.Instance.PlayBackgroundMusic(AudioClipsSource.Instance.MainMenuClip);
    }
    IEnumerator LoadScene()
    {
       yield return new WaitForSeconds(loadingTime);
        SceneManager.LoadScene("MainMenu");
    }
}

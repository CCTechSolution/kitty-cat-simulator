using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MediumBannerHandler : MonoBehaviour
{
    MediationHandler mediationHandler;

    private void Awake()
    {
        mediationHandler = FindObjectOfType<MediationHandler>();
    }

    private void OnEnable()
    {
        mediationHandler.ShowMbanner(GoogleMobileAds.Api.AdPosition.BottomLeft);
        //mediationHandler.hideSmallBanner();
    }

    private void OnDisable()
    {
        mediationHandler.hideMediumBanner();
        if (UnityEngine.SceneManagement.SceneManager.GetActiveScene().buildIndex != 3 && UnityEngine.SceneManagement.SceneManager.GetActiveScene().buildIndex != 2 && UnityEngine.SceneManagement.SceneManager.GetActiveScene().buildIndex != 5 && UnityEngine.SceneManagement.SceneManager.GetActiveScene().buildIndex != 4)
        {
            Debug.Log("Hiding medium banner and showing small banner");
            mediationHandler.ShowSbanner(GoogleMobileAds.Api.AdPosition.Top);
        }
        
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class GameTimer : MonoBehaviour
{
    public static GameTimer instance;
    public float finalcountdown = 60;
    public Text TimerUI;
    public bool ClockTick;
    public Text AdLoadingImg;
    private void Awake()
    {
        instance = this;
    }
    void Start()
    {
        finalcountdown = 60;

    }
    private void Update()
    {
        if (finalcountdown > 0 && !ClockTick)
        {
            ClockTick = true;
            StartCoroutine(Wait());
        }
    }
    IEnumerator Wait()
    {
        finalcountdown -= 1;
        UpdateTimer();
        yield return new WaitForSeconds(1); 
        if (finalcountdown == 0)
        {
            finalcountdown = 0;
            ClockTick = false;
            Debug.Log("Ad Loading...");
          TimerUI.gameObject.SetActive(false);
            AdLoadingImg.gameObject.SetActive(true);
            AdLoadingImg.text = "Ad Loading";
            Invoke(nameof(AdWait), 2.0f);


            //AdmobAdsManager.Instance.LoadInterstitial();


            Invoke(nameof(WaitForAd), 3.0f);

        }
        else
        {
            ClockTick = false;
        }

    }
    void UpdateTimer()
    {
        int min = Mathf.FloorToInt(finalcountdown / 60);
        int sec = Mathf.FloorToInt(finalcountdown % 60);
        TimerUI.GetComponent<UnityEngine.UI.Text>().text = min.ToString("00") + ":" + sec.ToString("00");
    }
    public void AdWait()
    {
        Debug.Log("Waiting For Ad....");


        //AdmobAdsManager.Instance.ShowInterstitial();
        
        AdLoadingImg.gameObject.SetActive(false);
    }
    public void WaitForAd()
    {
       TimerUI.gameObject.SetActive(true);
        finalcountdown = 60;
        UpdateTimer();

    }

}

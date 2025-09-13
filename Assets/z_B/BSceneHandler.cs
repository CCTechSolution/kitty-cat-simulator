using UnityEngine;

public class BSceneHandler : MonoBehaviour
{
    [SerializeField] float timeForAppOpen;



    void OnEnable()
    {
        InAppload();
        Call();
    }
    void Call()
    {
        Invoke(nameof(InAppShow), timeForAppOpen);
    }

    void InAppload()
    {
<<<<<<< HEAD
        Debug.Log("app open load call deliver");
        AdmobAdsManager.Instance.Btn_App_Load();
    }
    void InAppShow()
    {
        Debug.Log("app open show call deliver");
        AdmobAdsManager.Instance.Btn_App_Show();
=======
      //  Debug.Log("app open load call deliver");
//        AdmobAdsManager.Instance.Btn_App_Load();
    }
    void InAppShow()
    {
       // Debug.Log("app open show call deliver");
       // AdmobAdsManager.Instance.Btn_App_Show();
>>>>>>> origin/main
    }
    
}


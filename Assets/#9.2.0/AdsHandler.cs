using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdsHandler : MonoBehaviour
{
    MediationHandler mediationHandler;

    private void Awake()
    {
        mediationHandler = FindObjectOfType<MediationHandler>();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void showAD()
    {
        mediationHandler.ShowInterstitial();
    }
}

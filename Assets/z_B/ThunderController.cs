using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThunderController : MonoBehaviour
{
    public float DelayTime;
    public GameObject thunder;
    public ParticleSystem RainParticle;
    public AudioClip aaa;
    private void OnEnable()
    {
        RainParticle.Play();
        DelayTime = aaa.length;
        StopCoroutine(ThunderDelayActivation());
        StartCoroutine(ThunderDelayActivation());
        Invoke(nameof(Deactvie), 30);
    }
    void Deactvie()
    {
        gameObject.SetActive(false);
    }
    void Actvie()
    {
        gameObject.SetActive(true);
    }
    IEnumerator ThunderDelayActivation()
    {
        RainParticle.Play();
        //Debug.LogError(DelayTime);
        yield return new WaitForSeconds(5);
        thunder.SetActive(true);
        yield return new WaitForSeconds(5f);
        thunder.SetActive(false);
        yield return new WaitForSeconds(3.81878f);
        
        StartCoroutine(ThunderDelayActivation());
    }
    private void OnDisable()
    {
        thunder.SetActive(false);
        StopCoroutine(ThunderDelayActivation());
        Invoke(nameof(Actvie), 10);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AIHandler : MonoBehaviour
{
    public static AIHandler Instance;
    public NavMeshAgent agent;
    public Camera ShakeCam;
    public AudioSource Death;

    private void Awake()
    {
        Instance = this;
    }
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.radius = 30f;
        agent.height = 170f;
    }
    public void ActiveBloodImg()
    {
        ShakeCam.enabled = true;
        UIManager.instance.BloodImg.SetActive(true);
        Death.Play();
    }

}

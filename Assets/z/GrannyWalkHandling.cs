using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class GrannyWalkHandling : MonoBehaviour
{
    public NavMeshAgent agent;
    public Animator anim;
    public Transform StartPoint;
    public Transform EndPoint;
  
    void Start()
    {
        agent= GetComponent<NavMeshAgent>();
        anim=GetComponent<Animator>();
        GoDestination();
    }

    public void GoDestination()
    {
        Debug.Log("Walking....");
        agent.SetDestination(EndPoint.position);
        anim.SetBool("Walk", true);
        anim.SetBool("Idle", false);  
        transform.LookAt(EndPoint.position);
    }
    public void OnTriggerEnter(Collider other)
    {
        Debug.Log("Reaching.....");
        if (other.tag == "EndPoint")
        {
            Debug.Log("Reached...");
            anim.SetBool("Walk", false);
            anim.SetBool("Idle", true);
            StartCoroutine(WaitToStayIdle());
        }
    }
    public IEnumerator WaitToStayIdle()
    {
        anim.SetBool("Walk", false);
        anim.SetBool("Idle", true);
        yield return new WaitForSeconds(7f);
        agent.SetDestination(StartPoint.position);
        anim.SetBool("Walk", true);
        anim.SetBool("Idle", false);
        transform.LookAt(StartPoint.position);
    }
}

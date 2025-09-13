using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PathDrawToTestination : MonoBehaviour
{
    public static PathDrawToTestination instance;
    public LineRenderer drawpath;
    public Transform target;
    private NavMeshPath path;
    public float elapsed = 0.0f, Interval = .1f,SpecificDis, PathHeightOffset;
    public bool NotUseInterval,StartPathDraw;
    public NavMeshAgent  Currentagent;
    public Material CurrentMaterial;
    public float scrollSpeed = 0.5f;
    private void Awake()
    {
        instance = this;
    }
    void Start()
    {
        path = new NavMeshPath();
    }
    private void OnEnable()
    {
        
        NotUseInterval = false;
    }
    float time=1;
    void Update()
    {
        if (PlayerManager.instance.currentPickable != null && PlayerManager.instance.hasReached)
        {
            target = PlayerManager.instance.currentPickable.transform;
        }
        else
        {
      target = GamePlayHandler.instance.EndPoint.transform;
        }
        if (target != null && StartPathDraw)
        {
            
            if (Currentagent.enabled)
            {
                if (NotUseInterval)
                {
                    if (drawpath.enabled == false)
                        drawpath.enabled = true;

                    if (Currentagent.gameObject.activeInHierarchy)
                    {
                        if (Currentagent.hasPath)
                        {
                            SetPath();
                        }
                        if (Currentagent.isOnNavMesh )
                        {

                         Currentagent.SetDestination(target.position);
                        }
                        
                        
                    }
                     
                    float offset = Time.time * scrollSpeed;
                    CurrentMaterial.SetTextureOffset("_MainTex", new Vector2(offset, 0));

                    time -= Time.deltaTime;
                    if (time < 0)
                    {
                        Currentagent.gameObject.SetActive(false);
                        Currentagent.transform.position = transform.position;
                        time = 1.5f;
                        
                        Currentagent.gameObject.SetActive(true);
                    }
                }
                else
                {

                    NotUseInterval = true;
                    if (Currentagent.enabled)
                    {
                        Currentagent.SetDestination(target.position);
                    }
                    Currentagent.transform.position = transform.position;
                    
                }
            }
            
        }
        else
        {
            drawpath.enabled = false;
            
        }

    }
    void SetPath()
    {
        drawpath.positionCount = Currentagent.path.corners.Length;
        if(drawpath.positionCount>0)
            drawpath.SetPosition(0, transform.position);

        if (Currentagent.path.corners.Length < 2)
        {
            return;
        }

        for (int i = 0; i < Currentagent.path.corners.Length; i++)
        {
            Vector3 pointPos = new Vector3(Currentagent.path.corners[i].x, Currentagent.path.corners[i].y, Currentagent.path.corners[i].z);
            if(pointPos != Vector3.zero)
            {
                drawpath.SetPosition(i, pointPos);
            }
            
        }
    }

}

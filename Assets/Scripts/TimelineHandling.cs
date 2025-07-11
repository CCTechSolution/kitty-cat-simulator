using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
public class TimelineHandling : MonoBehaviour
{
    public static TimelineHandling Instance;
    public PlayableDirector timeline;
    public GameObject TimelineSounds;
    private void Awake()
    {
        Instance = this;
    }
    private void Start()
    {
        timeline.stopped += OnTimelineStopped;
    }
    void OnTimelineStopped(PlayableDirector director)
    {
        if (director == timeline)
        {
           director.Play();
        
        }
    }
    public void StopTimeline()
    {
        timeline.Pause();
        TimelineSounds.SetActive(false);
 

    }
    public void ResumeTimeline()
    {
        timeline.Resume();
        TimelineSounds.SetActive(true);
    }
}

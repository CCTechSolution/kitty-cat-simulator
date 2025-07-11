using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class TimelineSpeed : MonoBehaviour
{
    public PlayableDirector CutSceneLine;
  
    public void SpeedSet(float speed)
    {
        CutSceneLine.playableGraph.GetRootPlayable(0).SetSpeed(speed);
    }
}

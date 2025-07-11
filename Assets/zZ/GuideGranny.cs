using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuideGranny : MonoBehaviour
{
    [SerializeField] Animator guideGrannyAnimator;
    [SerializeField] Animator parentGrannyPosAnimtor;
    public void ToWalking()
    {
        guideGrannyAnimator.SetBool("Walk", true);
        parentGrannyPosAnimtor.SetBool("Pos", true);
    }
}

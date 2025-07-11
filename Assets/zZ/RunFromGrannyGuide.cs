using UnityEngine;

public class RunFromGrannyGuide : MonoBehaviour
{
    [SerializeField] Animator guideGrannyAnimator;

    private void OnEnable()
    {
        guideGrannyAnimator.SetBool("AngerStart", true);
        PlayerPrefs.SetInt("Tutorial", 1);
    }
}

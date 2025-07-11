using System;
using UnityEngine;

public class Breakable_Item : MonoBehaviour
{
    public GameObject brokenVersion; // Assign the broken object prefab in the Inspector
    float forceThreshold = 2f;
    bool canBreak = true;

    public static event Action OnItemBreak;
    public static event Action OnGlassBreak;
    public static event Action OnCupBreak;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.relativeVelocity.magnitude > forceThreshold)
        {
            if (canBreak)
            {
                if (Sfx_Manager.Instance)
                    Sfx_Manager.PlayRandomSound(Sfx_Manager.Instance.breakItemEffect);                              
                BreakObject();
                canBreak = false;
                OnItemBreak?.Invoke();
            }
        }
    }

    void BreakObject()
    {
        GameObject breakItem = Instantiate(brokenVersion, transform.position, transform.rotation);
        Destroy(breakItem,1.5f);
        gameObject.SetActive(false);
    }
}

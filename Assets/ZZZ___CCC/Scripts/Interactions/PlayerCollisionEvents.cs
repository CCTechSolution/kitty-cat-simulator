using UnityEngine;
using System;

public class PlayerCollisionEvents : MonoBehaviour
{

    [Header("Tags String")]
    [SerializeField] string diamondTag;
    [SerializeField] string keyTag;
    [SerializeField] string punchTag;
    [SerializeField] string shockTag;
    [SerializeField] string fireTag;
    [SerializeField] string beeTag;


    public static event Action OnDiamondHit;
    public static event Action OnKeyHit;
    public static event Action OnPunchTrigger;
    public static event Action OnShockTrigger;
    public static event Action OnFireTrigger;
    public static event Action OnBeeTrigger;


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag(diamondTag))
        {
            OnDiamondHit?.Invoke();
            if (Sfx_Manager.Instance)
            {
                Sfx_Manager.PlayRandomSound(Sfx_Manager.Instance.diamondCollect);
            }
            other.gameObject.SetActive(false);

        }
        if (other.gameObject.CompareTag(keyTag))
        {
            OnKeyHit?.Invoke();
            if (Sfx_Manager.Instance)
            {
                Sfx_Manager.PlayRandomSound(Sfx_Manager.Instance.keysCollect);
            }
            other.gameObject.SetActive(false);

        }

        //PUNCH
        if (other.gameObject.CompareTag(punchTag))
        {
            OnPunchTrigger?.Invoke();              
        }

        //SHOCK
        if (other.gameObject.CompareTag(shockTag))
        {
            OnShockTrigger?.Invoke();              
        }

        //FIRE
        if (other.gameObject.CompareTag(fireTag))
        {
            OnFireTrigger?.Invoke();             
        }

        //BEE
        if (other.gameObject.CompareTag(beeTag))
        {
            OnBeeTrigger?.Invoke();               
        }
    }
}

using System;
using UnityEngine;

public class CollidersForEvents : MonoBehaviour
{
    public bool canSendCall = true;
    public static event Action OnEnterCollider;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if (canSendCall)
            {
                OnEnterCollider?.Invoke();
                canSendCall = false;
            }
        }
    }
}

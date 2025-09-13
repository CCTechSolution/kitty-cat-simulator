using System;
using UnityEngine;

public class Granny_Detection : MonoBehaviour
{

    public static event Action OnBottleHitGranny;
    public static event Action OnBookHitGranny;
    public static event Action OnCoffeeHitGranny;
    public static event Action OnToyHitGranny;
    public static event Action OnFruitHitGranny;
    public static event Action OnFramesHitGranny;
    public static event Action OnFireBulletHitGranny;
    public static event Action OnShockBulletHitGranny;
    public static event Action OnBeeBulletHitGranny;
    public static event Action OnPunchHitGranny;

    bool canSendEventCall = true;

    [SerializeField] LayerMask interactableLayer;
    bool canHit;
    private void OnCollisionEnter(Collision collision)
    {
        if (canSendEventCall)
        {
            if (Sfx_Manager.Instance)
            {
                Sfx_Manager.PlayRandomSound(Sfx_Manager.Instance.StopAndNoSound);
            }

            if (collision.gameObject.layer == 6)
            {
                Debug.Log(" Interactable Object hit granny");
                Granny_EventManager.TriggerGrannyAngry();
                canSendEventCall = false;
            }

            if (collision.gameObject.CompareTag("Bottle"))
            {
                OnBottleHitGranny?.Invoke();
                Debug.Log("Bottle hit granny");
                canSendEventCall = false;
            }
            if (collision.gameObject.CompareTag("Book"))
            {
                OnBookHitGranny?.Invoke();
                Debug.Log("Book hit granny");
                canSendEventCall = false;
            }
            if (collision.gameObject.CompareTag("Coffee"))
            {
                OnCoffeeHitGranny?.Invoke();
                Debug.Log("Coffee hit granny");
                canSendEventCall = false;
            }
            if (collision.gameObject.CompareTag("Toy"))
            {
                OnToyHitGranny?.Invoke();
                Debug.Log("Toy hit granny");
                canSendEventCall = false;
            }
            if (collision.gameObject.CompareTag("Fruits"))
            {
                OnFruitHitGranny?.Invoke();
                Debug.Log("Fruits hit granny");
                canSendEventCall = false;
            }
            if (collision.gameObject.CompareTag("Frames"))
            {
                OnFramesHitGranny?.Invoke();
                Debug.Log("Frames hit granny");
                canSendEventCall = false;
            }
        }
        Invoke(nameof(CanSendCallTrue), 1f);
    }

    void CanSendCallTrue()
    {
        canSendEventCall = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("PunchRod"))
        {
            OnPunchHitGranny?.Invoke();
            Debug.Log("Punch hit granny");
        }
        if (other.gameObject.CompareTag("FireBullet"))
        {
            OnFireBulletHitGranny?.Invoke();
            Debug.Log("Fire Bullet hit granny");
        }        
        if (other.gameObject.CompareTag("BeeBullet"))
        {
            OnBeeBulletHitGranny?.Invoke();
            Debug.Log("Bee Bulllet hit granny");
        }
        if (other.gameObject.CompareTag("ShockBullet"))
        {
            OnShockBulletHitGranny?.Invoke();
            Debug.Log("Shock Bullet hit granny");
        }
    }
}

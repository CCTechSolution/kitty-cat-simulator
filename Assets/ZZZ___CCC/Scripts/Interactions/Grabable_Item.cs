using System;
using System.Collections.Generic;
using UnityEngine;

public class Grabable_Item : MonoBehaviour, IInteractables
{
    private bool isGrabbed = false;
    private Vector3 initialPos;
    private Quaternion initialRotation;
    private Collider m_Collider;
    private float forceThreshold = 1.0f;
    private Rigidbody m_RigidBody;
    private static List<Grabable_Item> allResettableObjects = new List<Grabable_Item>();

    bool canFireEventForCollision = true;

    //Events
    public static event Action OnVaseHit;
    public static event Action OnPotHit;
    public static event Action OnGlassHit;
    public static event Action OnCupHit;

    private void Awake()
    {

        initialPos = transform.position;
        initialRotation = transform.rotation;

        allResettableObjects.Add(this);
    }
    private void Start()
    {
        m_RigidBody = GetComponent<Rigidbody>();
        if (m_Collider == null)
        {
            m_Collider = GetComponent<Collider>();
        }
        else
        {
            Debug.LogWarning("Collider of " + gameObject.name + " is not present");
        }

        initialPos = transform.position;
    }

    public void OnEnterRange()
    {
        if (!isGrabbed) UI_Manager.Instance.ShowGrabButton(true);
    }

    public void OnExitRange()
    {
        UI_Manager.Instance.ShowGrabButton(false);
    }

    public void OnInteract()
    {
        if (!isGrabbed)
        {
            Player_Interaction.Instance.GrabItem(this);
        }
    }

    public void SetGrab(bool grabbed)
    {
        isGrabbed = grabbed;
    }

    public Vector3 GetInitialPosition()
    {
        return initialPos;
    }

    public void SetColliderTrigger()
    {
        m_Collider.isTrigger = true;
    }
    public void SetColliderNonTrigger()
    {
        m_Collider.isTrigger = false;
    }

    public void ResetRotation()
    {
        transform.localEulerAngles = Vector3.zero;
    }

    public static void ResetAllObjects()
    {
        foreach (var obj in allResettableObjects)
        {
            obj.ResetToInitialState();
        }
    }
    void ResetToInitialState()
    {
        transform.position = initialPos;
        transform.rotation = initialRotation;
    }

    //COLLISION EVENTS CALLING

    private void OnCollisionEnter(Collision collision)
    {
        m_RigidBody.useGravity = true;
        if (collision.relativeVelocity.magnitude > forceThreshold)
        {
            if (gameObject.CompareTag("Vase"))
            {
                if (canFireEventForCollision)
                {
                    OnVaseHit?.Invoke();
                    canFireEventForCollision = false;
                    Invoke(nameof(CanFireCollisionEvent), 2f);
                }                
            }
            if (gameObject.CompareTag("Pot"))
            {
                if (canFireEventForCollision)
                {
                    OnPotHit?.Invoke();
                    canFireEventForCollision = false;
                    Invoke(nameof(CanFireCollisionEvent), 2f);
                }                
            } 
            if (gameObject.CompareTag("Glass"))
            {
                Debug.Log("Glass hit something");
                if (canFireEventForCollision)
                {
                    Debug.Log("Event invoked for glass hit");
                    OnGlassHit?.Invoke();
                    canFireEventForCollision = false;
                    Invoke(nameof(CanFireCollisionEvent), 2f);
                }                
            } 
            if (gameObject.CompareTag("Cup"))
            {
                Debug.Log("Cup hit something");
                if (canFireEventForCollision)
                {
                    Debug.Log("Event invoked for glass hit");
                    OnCupHit?.Invoke();
                    canFireEventForCollision = false;
                    Invoke(nameof(CanFireCollisionEvent), 2f);
                }                
            }                        
        }
        Invoke(nameof(MakeObjectStill), 1.5f);
    }

    void MakeObjectStill()
    {
        m_RigidBody.useGravity = false;
        m_RigidBody.isKinematic = true;
            Collider col = GetComponent<Collider>();
        col.isTrigger = true;
    }
    void CanFireCollisionEvent()
    {
        canFireEventForCollision = true;
    }
}

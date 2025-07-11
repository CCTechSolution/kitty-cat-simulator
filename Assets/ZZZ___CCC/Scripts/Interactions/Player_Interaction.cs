using System;
using UnityEngine;


public class Player_Interaction : MonoBehaviour
{
    public static Player_Interaction Instance;





    [Header("Prefrences")]
    [SerializeField] float throwForce;
    [SerializeField] float upwardForceWhileThrowing = 0.3f;



    [Header("Req Components")]
    [Tooltip("The direction transform at which player throw item")]
    [SerializeField] Transform playerCameraTransform;
    [Tooltip("The transfom parent of held object")]
    [SerializeField] Transform holdPosition;
    [SerializeField] Transform throwPoint;


    public static event Action OnGrabbedBottle;
    public static event Action OnAnyObjectGrab;
    public static event Action OnAnyObjectThrow;


    private Grabable_Item heldItem;
    
    private void Awake()=> Instance = this;

    public void GrabItem(Grabable_Item item)
    {
        if (heldItem == null)
        {
            heldItem = item;
            heldItem.SetColliderTrigger();

            Rigidbody rb = item.GetComponent<Rigidbody>();
            rb.isKinematic = true;

            

            if (Sfx_Manager.Instance)
            {
                Sfx_Manager.PlayRandomSound(Sfx_Manager.Instance.objectPick);
            }

            item.transform.SetParent(holdPosition);
            item.transform.localPosition = Vector3.zero;
            item.ResetRotation();
            item.SetGrab(true);
            OnAnyObjectGrab?.Invoke();

            UI_Manager.Instance.ShowGrabButton(false);
            UI_Manager.Instance.ShowThrowButton(true);

            foreach (Transform child in item.transform)
            {
                child.gameObject.SetActive(false);
            }

            if (item.gameObject.CompareTag("Bottle"))
            {
                Debug.Log("Bottle picked up");
                OnGrabbedBottle?.Invoke();
            }
        }
    }

    void TriggerItem(Collider coll)
    {
        coll.isTrigger = true;
    }

    public void ThrowItem()
    {
        if (heldItem != null)
        {
            heldItem.transform.SetParent(null);

            if (Sfx_Manager.Instance)
            {
                Sfx_Manager.PlayRandomSound(Sfx_Manager.Instance.objectThrow);
            }

            Rigidbody rb = heldItem.GetComponent<Rigidbody>();
            rb.isKinematic = false;
            rb.useGravity = true;

            Collider collider = heldItem.GetComponent<Collider>();
            collider.isTrigger = false;

            
            heldItem.gameObject.transform.SetParent(throwPoint);
            heldItem.transform.localPosition = Vector3.zero;
            Vector3 throwDirection = playerCameraTransform.transform.forward + Vector3.up * upwardForceWhileThrowing; 
            throwDirection.Normalize();
            rb.AddForce(throwDirection * throwForce, ForceMode.Impulse);

            OnAnyObjectThrow?.Invoke();

            heldItem.transform.SetParent(null);
            heldItem.SetColliderNonTrigger();
            heldItem.SetGrab(false);
            heldItem = null;


            UI_Manager.Instance.ShowThrowButton(false);
        }
    }


    public void ResetHoldingState()
    {
        if (heldItem != null)
        {
            heldItem.transform.SetParent(null);
            Rigidbody rb = heldItem.GetComponent<Rigidbody>();
            rb.isKinematic = false;
            rb.useGravity = true;
            heldItem.SetColliderNonTrigger();
            heldItem.SetGrab(false);
            heldItem.transform.position = heldItem.GetInitialPosition();
            heldItem = null;
            

            UI_Manager.Instance.ShowThrowButton(false);
        }
    }

    public bool IsHoldingItem()
    {
        return heldItem != null;
    }

  
}

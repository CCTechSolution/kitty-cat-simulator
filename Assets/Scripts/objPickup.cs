using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
//using static UnityEditor.Progress;//Self

public class objPickup : MonoBehaviour
{
    public static objPickup instance;
    public bool _Light;
    public GameObject _Temp;

    public GameObject crosshair1, crosshair2;
    public Transform objTransform, cameraTransform;
    public bool interactable;
    public bool pickedup = false;
    public Rigidbody Objrb;
    public float throwAmount,ItemScale=1.6f;
    public Transform pickPos;
    public GameObject PickEffect;
    private void Awake()
    {
        instance = this;
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("MainCamera"))
        {
            crosshair1.SetActive(false);
            crosshair2.SetActive(true);
            interactable = true;
            UIManager.instance.PickBtn.SetActive(true);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("MainCamera"))
        {
            crosshair1.SetActive(true);
            crosshair2.SetActive(false);
            interactable = false;
            UIManager.instance.PickBtn.SetActive(false);
            UIManager.instance.DropBagBtn.SetActive(false);
        }
    }
    private void Update()
    {
        if (interactable)
        {
            if (UIManager.instance.pickPressed)
            {
                PickObject();
            }
            if (pickedup == true)
            {
                if (UIManager.instance.dropPressed)
                {
                    //Debug.LogError("Drop here Update");
                   // DropObject();
                }
            }
        }
    }
    bool islightOpen;
    Rigidbody rb;
    public void PickObject()
    {
        //Debug.LogError("PickObject");
        rb = objTransform.gameObject.GetComponent<Rigidbody>();
        objTransform.gameObject.GetComponent<Rigidbody>().useGravity = false;
        if (_Light == true)
        {
            PlayerManager.instance.TorchLight.SetActive(true);
            objTransform.parent = pickPos;
            if (!islightOpen)
            {
                if (objTransform.TryGetComponent(out Animator animator))
                {
                    islightOpen = true;
                    animator.enabled = true;
                }
            }
            if (objTransform.transform.childCount > 1)
            {
                //objTransform.transform.GetChild(1).gameObject.SetActive(true);
            }
        }
        else
        {
            PlayerManager.instance.TorchLight.SetActive(false);
            objTransform.parent = pickPos;
            objTransform.DOMove(pickPos.position, 0.6f);
            objTransform.DORotateQuaternion(pickPos.rotation, .2f);

            if (!islightOpen)
            {
                if (objTransform.TryGetComponent(out Animator animator))
                {
                    islightOpen = true;
                    animator.enabled = true;
                    GamePlayHandler.instance.currentFootIndex += 1;
                    Debug.Log("PickObject:" + GamePlayHandler.instance.currentFootIndex);
                }
            }
        }
        
        objTransform.DOScale(ItemScale, 1.2f);
        objTransform.GetComponent<BoxCollider>().isTrigger = true;
        objTransform.GetComponent<BoxCollider>().enabled = false;
        pickedup = true;
        if (GameManagerScript.instance.CurrentLevel != 2)
        {
            ActivePickablesHandling();
        }
        
        if (PickEffect != null)
        {
            PickEffect.SetActive(false);
        }
        crosshair1.SetActive(true);
        crosshair2.SetActive(false);
        UIManager.instance.pickPressed = false;
    }
    public void DropObject()
    {
        if (pickedup == true)
        {
            objTransform.DOScale(1f, 0.9f);
            objTransform.parent = null;
            Objrb.useGravity = true;
            objTransform.TryGetComponent(out BoxCollider collider);
            collider.enabled = true;
            Objrb.velocity = cameraTransform.forward * throwAmount * Time.deltaTime;
            pickedup = false;
            if (PickEffect != null)
            {
                PickEffect.SetActive(true);
            }
            UIManager.instance.dropPressed = false;
        }

    }
    public void ActivePickablesHandling()
    {
        if (pickedup == true)
        {
            string pickableName = PlayerManager.instance.currentPickable.name;
            Debug.Log(pickableName);
            switch (pickableName)
            {
                case "bag":
                    //PlayerManager.instance.currentPickable.SetActive(false);//Self                    
                    UIManager.instance.PickBtn.SetActive(false);
                    UIManager.instance.DropBtn.SetActive(false);
                    break;
                case "tourch":
                    PlayerManager.instance.TorchLight.SetActive(true);
                    //PlayerManager.instance.currentPickable.SetActive(false);//Self
                    UIManager.instance.PickBtn.SetActive(false);
                    UIManager.instance.DropBtn.SetActive(false);
                    break;

                case "key":
                    UIManager.instance.PickBtn.SetActive(false);
                    UIManager.instance.DropBtn.SetActive(false);
                    break;
                case "hammer":
                    UIManager.instance.PickBtn.SetActive(false);
                    UIManager.instance.DropBtn.SetActive(false);
                    break;
                case "baby":
                    UIManager.instance.PickBtn.SetActive(false);
                    UIManager.instance.DropBtn.SetActive(false);
                    break;
                default:
                    // Handle other pickables
                    Debug.Log("Picked up " + pickableName);
                    break;
            }
            GamePlayHandler.instance.EndPoint.SetActive(false);
            PlayerManager.instance.PrevPickable = PlayerManager.instance.currentPickable;
            GamePlayHandler.instance.PIckableIndex++;
            Debug.Log(GamePlayHandler.instance.PIckableIndex);
            PlayerManager.instance.HandlePickables();
            PlayerManager.instance.HandleEndPoint();
            //Debug.LogError("HandleEndPoint ActivePickablesHandling");
            GamePlayHandler.instance.ActiveObjectives();//Self
            Debug.Log("ENdPoint............" + GamePlayHandler.instance.EndPointIndex);
        }
    }
    public void DropBag()
    {        
        GamePlayHandler.instance.ActiveObjectives();//Self
    }
}


using System;
using UnityEngine;

public class Player_Detection : MonoBehaviour
{
    [SerializeField] Transform raycastOrigin;
    [SerializeField] float detectionRange = 3f;
    [SerializeField] LayerMask interactableLayer;
    [SerializeField] LayerMask rewardLayer;
    public GameObject rewardButtonUI;


    public static event EventHandler<RewardItemCarry> OnInteractWithRewardItem;
    public class RewardItemCarry : EventArgs
    {
        public GameObject rewardItem;
    }

    private IInteractables currentInteteractable;


    private void Start()
    {
        RewardItem.OnRewardButtonClicked += RewardItem_OnRewardButtonClicked;
    }
    private void OnDestroy()
    {
        RewardItem.OnRewardButtonClicked -= RewardItem_OnRewardButtonClicked;
    }
    private void RewardItem_OnRewardButtonClicked()
    {
        OnInteractWithRewardItem?.Invoke(this,new RewardItemCarry() );
    }

    private void Update()
    {
        CheckForInteractble();
        CheckForRewardItem();
    }

    void CheckForInteractble()
    {

        if (Player_Interaction.Instance.IsHoldingItem())
        {
            if (currentInteteractable != null)
            {
                currentInteteractable.OnExitRange();
                currentInteteractable = null;
            }
            return;
        }
        RaycastHit hit;
        if (Physics.Raycast(raycastOrigin.position, raycastOrigin.forward, out hit, detectionRange, interactableLayer))
        {
            IInteractables interactable = hit.collider.GetComponent<IInteractables>();
            if (interactable != null && interactable != currentInteteractable)
            {
                currentInteteractable?.OnExitRange();

                currentInteteractable = interactable;
                currentInteteractable.OnEnterRange();
            }
        }
        else if (currentInteteractable != null)
        {
            currentInteteractable.OnExitRange();
            currentInteteractable = null;
        }
    }

    public void Interact()
    {
        currentInteteractable?.OnInteract();
    }

    void CheckForRewardItem()
    {
        if (Player_Interaction.Instance.IsHoldingItem())
        {
            rewardButtonUI.SetActive(false);
            return;
        }

        RaycastHit hit;
        if (Physics.Raycast(raycastOrigin.position, raycastOrigin.forward, out hit, detectionRange, rewardLayer))
        {
            Debug.Log("raycasting reward");
            rewardButtonUI.SetActive(true);
            OnInteractWithRewardItem?.Invoke(this, new RewardItemCarry() { rewardItem = hit.transform.gameObject });
        }
        else
        {
            rewardButtonUI.SetActive(false);            
            Debug.Log("not raycasting for reward");
        }
    }

}

using UnityEngine;

public class PickObjectTutorial : MonoBehaviour
{
    [SerializeField] Vector3 targetPositionForObjGrab;
    [SerializeField] Transform catTransfrom;
    [SerializeField] Transform cameraTransform;

    private void OnEnable()
    {
        ChangeCatPosition();
        Player_Interaction.OnAnyObjectGrab += Player_Interaction_OnAnyObjectGrab;
    }
    private void OnDisable()
    {
        Player_Interaction.OnAnyObjectGrab -= Player_Interaction_OnAnyObjectGrab;
    }

    private void Player_Interaction_OnAnyObjectGrab()
    {
        gameObject.SetActive(false);
    }

    void ChangeCatPosition()
    {
        catTransfrom.gameObject.SetActive(false);
        catTransfrom.position = targetPositionForObjGrab;
        catTransfrom.rotation = Quaternion.Euler(0f, -1.6f, 0f);
        cameraTransform.rotation = Quaternion.Euler(3f, 0f, 0f);
        catTransfrom.gameObject.SetActive(true);
    }



}

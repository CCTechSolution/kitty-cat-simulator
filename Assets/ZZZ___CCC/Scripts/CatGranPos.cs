using UnityEngine;

public class CatGranPos : MonoBehaviour
{

    public static CatGranPos Instance;

    Granny granny;

    [SerializeField] Transform catTransfrom;
    [SerializeField] Transform grannyTransform;

    [Header("Positions of Cat")]
    [SerializeField] Vector3 catInTutorialStart;
    [SerializeField] Vector3 catInLivingRoom;
    [SerializeField] Vector3 catInKitchen;
    [SerializeField] Vector3 catInSecondFloor;    
    [Header("Position of Granny")]
    [SerializeField] Vector3 grannyInTutorialStart;
    [SerializeField] Vector3 grannyInLivingRoom;
    [SerializeField] Vector3 grannyInKitchen;
    [SerializeField] Vector3 grannyInSecondFloor;
    

    private void Awake()
    {
        Instance = this;        
    }

    private void Start()
    {
        granny = grannyTransform.GetComponent<Granny>();
    }

    public void InTutorialStart()
    {
        ChangePos(catInTutorialStart, grannyInTutorialStart, 0f);
    }

    public void InKitchen1stFloor()
    {
        ChangePos(catInKitchen, grannyInKitchen, -270f);
    }

    public void InLivingRoom1stFloor()
    {
        ChangePos(catInLivingRoom, grannyInLivingRoom, 0f);
    }
    public void InSecondFloor()
    {
        ChangePos(catInSecondFloor, grannyInSecondFloor, 125f);
    }

    void ChangePos(Vector3 catPos, Vector3 enemyPos, float catYRot)
    {
        catTransfrom.gameObject.SetActive(false);
        catTransfrom.position = catPos;
        catTransfrom.rotation = Quaternion.Euler(0f, 0f, 0f);
        catTransfrom.rotation = Quaternion.Euler(0f, catYRot, 0f);
        grannyTransform.gameObject.SetActive(false);
        grannyTransform.position = enemyPos;
        granny.navMeshAgent.ResetPath();
        catTransfrom.gameObject.SetActive(true);
        grannyTransform.gameObject.SetActive(true);
    }
}

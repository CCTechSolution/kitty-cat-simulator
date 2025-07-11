using System.Collections;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public static PlayerManager instance;
    public GameObject PlayerCam;
    public GameObject ShakeCam;
    public GameObject BoxCam;
    public GameObject ChairCam;
    public GameObject ScareShakeCam;
    public GameObject CurrentSOund;
    public GameObject NewspaperCam;
    public GameObject Rain;
    public GameObject Thunder;
    public GameObject Hand;
    public GameObject TorchLight;
    public GameObject currentPickable;
    public GameObject PrevPickable;
    public GameObject ArrowLvl1;
    public AudioSource LockDoor;
    public bool Itempick, DropItem;
    public bool hasReached = false;
    public int curentPickUpIndex;
    [Header("Dummy Objs")]
    public GameObject Dummybag;
    public GameObject DummyTorch;
    public GameObject DummyKey;
    public GameObject DummyHammer;
    public GameObject ScaryGranny;
    private void Awake()
    {
        instance = this;
    }
    private void Start()
    {
        if (GameManagerScript.instance.CurrentLevel == 0)
        {
            PathDrawToTestination.instance.target = GamePlayHandler.instance.EndPoint.transform;
        }
        if (currentPickable != null)
        {
            currentPickable = GamePlayHandler.instance.GameModes[GameManagerScript.instance.CurrentMode].GameLevels[GameManagerScript.instance.CurrentLevel].Pickable[GamePlayHandler.instance.PIckableIndex];
        }
        else { }

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Rain"))
        {
            Rain.SetActive(true);
            Thunder.SetActive(true);
            other.gameObject.SetActive(false);
        }
        if (other.CompareTag("Cupboard"))
        {
            PlayerCam.SetActive(false);
            ShakeCam.TryGetComponent(out Camera cam);
            cam.enabled = true;
            other.GetComponent<BoxCollider>().enabled = false;
            LevelsHandling.Instance.cupboardDoor.GetComponent<DoorOpening>().OpenDoor();
            LevelsHandling.Instance.cupboardNun.SetActive(false);
            LevelsHandling.Instance.cupboardSkull.SetActive(true);
            StartCoroutine(WaitforShake());
        }
        if (other.CompareTag("BoxTrigger"))
        {
            PlayerCam.SetActive(false);
            GamePlayHandler.instance.PlayerControls.SetActive(false);
           BoxCam.TryGetComponent(out Camera cam1);
            cam1.enabled = true;
            BoxCam.TryGetComponent(out Animator BoxAnim);
            BoxAnim.enabled = true;
            other.GetComponent<BoxCollider>().enabled = false;
            GamePlayHandler.instance.DisableAllAI_NUN();
            StartCoroutine(WaitforCat());
        }
        if (other.CompareTag("ScarePlayer"))
        {
            PlayerCam.SetActive(false);
            GamePlayHandler.instance.PlayerControls.SetActive(false);
            ShakeCam.TryGetComponent(out Camera cam4);
            cam4.enabled = true;
            ScaryGranny.SetActive(true);
            ShakeCam.TryGetComponent(out Animator shakeAnim);
            shakeAnim.enabled = true;
            other.GetComponent<BoxCollider>().enabled = false;
            GamePlayHandler.instance.DisableAllAI_NUN();
            StartCoroutine(WaitforCalm());
        }
        if (other.CompareTag("ChairTrigger"))
        {
            PlayerCam.SetActive(false);
            GamePlayHandler.instance.DisableAllAI_NUN();
            GamePlayHandler.instance.PlayerControls.SetActive(false);
            ChairCam.TryGetComponent(out Camera cam2);
            cam2.enabled = true;
            LevelsHandling.Instance.ChairGranny.SetActive(true);
            other.GetComponent<BoxCollider>().enabled = false;
            StartCoroutine(WaitforKey());
        }
        if (other.CompareTag("ScareMe"))
        {
            PlayerCam.SetActive(false);
            GamePlayHandler.instance.PlayerControls.SetActive(false);
            LevelsHandling.Instance.ScareGranny.SetActive(true);
            other.GetComponent<BoxCollider>().enabled = false;
            GamePlayHandler.instance.DisableAllAI_NUN();
            StartCoroutine(WaitforNormal());
        }
        if (other.CompareTag("HouseTrigger"))
        {
            LevelsHandling.Instance.HouseGranny.SetActive(true);
            other.GetComponent<BoxCollider>().enabled = false;
        }
        if (other.CompareTag("Newspaper"))
        {
            NewspaperCam = other.transform.GetChild(0).gameObject;
            other.GetComponent<BoxCollider>().enabled = false;
            other.transform.GetChild(0).gameObject.SetActive(true);
            other.transform.GetChild(0).GetComponent<Camera>().enabled = true;
            PlayerCam.SetActive(false);
            LevelsHandling.Instance.cat.SetActive(false);
            StartCoroutine(WaitforCam());
        }
        if (other.CompareTag("Bats"))
        {
            LevelsHandling.Instance.ForestBats.SetActive(true);
            other.GetComponent<BoxCollider>().enabled = false;
        }
        if (other.CompareTag("ForestBats"))
        {
            LevelsHandling.Instance.ForestBats.SetActive(true);
            other.GetComponent<BoxCollider>().enabled = false;
        }
        if (other.CompareTag("Sound"))
        {
            other.GetComponent<AudioSource>().Play();
            CurrentSOund = other.gameObject;
            other.GetComponent<BoxCollider>().enabled = false;
            StartCoroutine(WaitForSound());

        }
        if (other.CompareTag("LockDoor"))
        {
            //Self SoundManager.Instance.PlayEffect(AudioClipsSource.Instance.LockDoor);
            if (LockDoor != null)
            {
                LockDoor.Play();
            }
        }
        if (other.CompareTag("Door"))
        {
            other.GetComponent<DoorOpening>().OpenDoor();
            other.GetComponent<BoxCollider>().enabled = false;
        }
        if (other.CompareTag("EndPoint"))
        {
     
            GamePlayHandler.instance.DisableEnemy();
            PathDrawToTestination.instance.StartPathDraw = false;

            if (GameManagerScript.instance.CurrentLevel == 0)
            {
                ArrowLvl1.SetActive(false);

            }
            hasReached = true;
            //UIManager.instance.Ad.SetActive(true);
            if (Itempick)
            {
                UIManager.instance.PickBtn.SetActive(true);
                UIManager.instance.DropBagBtn.SetActive(false);
            }
            else if (DropItem)
            {
                UIManager.instance.PickBtn.SetActive(false);
                UIManager.instance.DropBagBtn.SetActive(true);
            }
            if (GameManagerScript.instance.CurrentLevel == 1 || GameManagerScript.instance.CurrentLevel == 3)
            {
                Debug.Log("HandleEndPoint OnTriggerEnter");
                HandleEndPoint();
            }
         //  HandleLevelCompletion();   // COmented for testing........

        }
        if (other.CompareTag("BagDrop"))
        {
            UIManager.instance.DropBagBtn.SetActive(true);
        }
        if (other.CompareTag("CatTrigger"))
        {
            LevelsHandling.Instance.ForestCat1.SetActive(true);
            StartCoroutine(WaitForCat());
        }
        if (other.CompareTag("Hand"))
        {
            Hand.SetActive(true);
            StartCoroutine(WaitForHand());
        }

    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("EndPoint"))
        {
            UIManager.instance.PickBtn.SetActive(false);
            UIManager.instance.DropBtn.SetActive(false);
        }
        if (other.CompareTag("BagDrop"))
        {
            UIManager.instance.DropBagBtn.SetActive(false);
        }
        UIManager.instance.PickBtn.SetActive(false);
        UIManager.instance.DropBagBtn.SetActive(false);
    }

    public IEnumerator WaitForSound()
    {
        yield return new WaitForSeconds(10f);
        CurrentSOund.GetComponent<BoxCollider>().enabled = true;

    }
    public void HandleEndPoint()
    {
        if (GamePlayHandler.instance.EndPointIndex < GamePlayHandler.instance.GameModes[GameManagerScript.instance.CurrentMode].GameLevels[GameManagerScript.instance.CurrentLevel].EndPointPos.Length)
        {
            //Debug.LogError("Orignal HandleEndPoint ActivePickablesHandling"+ GamePlayHandler.instance.EndPointIndex);
            GamePlayHandler.instance.EndPointIndex++;
            GamePlayHandler.instance.ActiveEndPoint();

        }
    }
    public void HandleObjectives()
    {
        if (GamePlayHandler.instance.currentObjectiveIndex < GamePlayHandler.instance.GameModes[GameManagerScript.instance.CurrentMode].GameLevels[GameManagerScript.instance.CurrentLevel].LevelObjective.Length)
        {
            GamePlayHandler.instance.currentObjectiveIndex++;
            GamePlayHandler.instance.currentFootIndex = GamePlayHandler.instance.currentObjectiveIndex - 1;
            //GamePlayHandler.instance.ActiveObjectives();//self
       
        }
        else
        {
            GamePlayHandler.instance.currentFootIndex += 1;
        }
        // Debug.LogError("HandleObjectives:" + GamePlayHandler.instance.currentFootIndex);
    }
    public void HandleFootSteps()
    {
        UIManager.instance.HintBtn.interactable = false;
        // Debug.LogError("TotalMode"+ GamePlayHandler.instance.GameModes.Length + ",CurrentMode:" + GameManagerScript.instance.CurrentMode+ ",CurrentLevel" + GameManagerScript.instance.CurrentLevel+",footpath length:"+ GamePlayHandler.instance.GameModes[GameManagerScript.instance.CurrentMode].GameLevels[GameManagerScript.instance.CurrentLevel].FootStepLvl.Length+ ",currentFootIndex:" + GamePlayHandler.instance.currentFootIndex);
        if (GamePlayHandler.instance.GameModes[GameManagerScript.instance.CurrentMode].GameLevels[GameManagerScript.instance.CurrentLevel].FootStepLvl != null)
        {

            if (GamePlayHandler.instance.GameModes[GameManagerScript.instance.CurrentMode].GameLevels[GameManagerScript.instance.CurrentLevel].FootStepLvl[GamePlayHandler.instance.currentFootIndex] != null)
            {
                if (GamePlayHandler.instance.currentFootIndex > 0)//-1
                {
                    GamePlayHandler.instance.GameModes[GameManagerScript.instance.CurrentMode].GameLevels[GameManagerScript.instance.CurrentLevel].FootStepLvl[GamePlayHandler.instance.currentFootIndex - 1].SetActive(false);
                }
                GamePlayHandler.instance.GameModes[GameManagerScript.instance.CurrentMode].GameLevels[GameManagerScript.instance.CurrentLevel].FootStepLvl[GamePlayHandler.instance.currentFootIndex].SetActive(true);
            }
        }
    }

    public IEnumerator WaitforCam()
    {
        yield return new WaitForSeconds(5f);
        NewspaperCam.SetActive(false);
        PlayerCam.SetActive(true);
    }
    public IEnumerator WaitforShake()
    {
        yield return new WaitForSeconds(3.0f);
        ShakeCam.TryGetComponent(out Camera cam);
        cam.enabled = false;
        PlayerCam.SetActive(true);
        LevelsHandling.Instance.cupboardSkull.SetActive(false);
    }
    public IEnumerator WaitforCat()
    {
        yield return new WaitForSeconds(1.6f);
        LevelsHandling.Instance.BoxHand.SetActive(true);
        yield return new WaitForSeconds(0.2f);
        LevelsHandling.Instance.BoxEffect.SetActive(true);
        yield return new WaitForSeconds(2.6f);
        BoxCam.TryGetComponent(out Camera cam1);
        cam1.enabled = false;
        PlayerCam.SetActive(true);
        GamePlayHandler.instance.PlayerControls.SetActive(true);
        LevelsHandling.Instance.BoxEffect.SetActive(false);
        LevelsHandling.Instance.BoxHand.SetActive(false);
        LevelsHandling.Instance.Box.SetActive(false);
        GamePlayHandler.instance.ActiveAI_NUN();
    }
    public IEnumerator WaitforKey()
    {
        yield return new WaitForSeconds(10f);
        BoxCam.TryGetComponent(out Camera cam1);
        cam1.enabled = false;
        PlayerCam.SetActive(true);
        GamePlayHandler.instance.PlayerControls.SetActive(true);
        LevelsHandling.Instance.ChairGranny.SetActive(false);
        GamePlayHandler.instance.ActiveAI_NUN();
    }
    public IEnumerator WaitforNormal()
    {
        yield return new WaitForSeconds(1.1f);
        LevelsHandling.Instance.grannyLaugh.GetComponent<SkinnedMeshRenderer>().material = LevelsHandling.Instance.Grannymat;
        yield return new WaitForSeconds(9f);
        PlayerCam.SetActive(true);
        GamePlayHandler.instance.PlayerControls.SetActive(true);
        LevelsHandling.Instance.ScareGranny.SetActive(false);
        GamePlayHandler.instance.ActiveAI_NUN();
    }
    public IEnumerator WaitforCalm()
    {
        yield return new WaitForSeconds(6f);
        ShakeCam.TryGetComponent(out Camera cam5);
        cam5.enabled = false;
        ScaryGranny.SetActive(false);
        PlayerCam.SetActive(true);
        GamePlayHandler.instance.PlayerControls.SetActive(true);
        GamePlayHandler.instance.ActiveAI_NUN();
    }
    public IEnumerator WaitForCat()
    {
        yield return new WaitForSeconds(5f);
        LevelsHandling.Instance.ForestCat1.SetActive(false);
    }
    public IEnumerator WaitForHand()
    {
        yield return new WaitForSeconds(4f);
        Hand.SetActive(false);
    }
    public void HandlePickables()
    {
        int currentIndex = GamePlayHandler.instance.PIckableIndex;
      //  Debug.Log(currentIndex);
        Debug.Log("Handle Pick" + currentIndex);
        if (currentIndex < GamePlayHandler.instance.GameModes[GameManagerScript.instance.CurrentMode].GameLevels[GameManagerScript.instance.CurrentLevel].Pickable.Length)
        {
            PrevPickable = currentPickable;
            currentPickable = GamePlayHandler.instance.GameModes[GameManagerScript.instance.CurrentMode].GameLevels[GameManagerScript.instance.CurrentLevel].Pickable[currentIndex];
            currentPickable.SetActive(true);
            if (GameManagerScript.instance.CurrentLevel == 0)
                Itempick = GamePlayHandler.instance.GameModes[GameManagerScript.instance.CurrentMode].GameLevels[GameManagerScript.instance.CurrentLevel].ItemPickReq[currentIndex];
            DropItem = GamePlayHandler.instance.GameModes[GameManagerScript.instance.CurrentMode].GameLevels[GameManagerScript.instance.CurrentLevel].ItemDropReq[currentIndex];
            curentPickUpIndex = currentIndex;

        }
        else
        {
            Debug.Log("No more pickables");
        }
    }
    public void HandleLevelCompletion()
    {
        int currentEndIndex = GamePlayHandler.instance.EndPointIndex;
        if (GameManagerScript.instance.CurrentLevel == 0)
        {
            if (GamePlayHandler.instance.currentObjectiveIndex >= 7)
            {

                StartCoroutine(GamePlayHandler.instance.ActiveLevel1LastCin());
            }
        }
        else if (GameManagerScript.instance.CurrentLevel == 2)
        {
            if (currentEndIndex >= 1)
            {
                GamePlayHandler.instance.EndCinDelay();
                UIManager.instance.OnLevelComplete.Invoke();
            }
        }
        else if (GameManagerScript.instance.CurrentLevel == 1 || GameManagerScript.instance.CurrentLevel == 3)
        {
            if (currentEndIndex >= GamePlayHandler.instance.GameModes[GameManagerScript.instance.CurrentMode].GameLevels[GameManagerScript.instance.CurrentLevel].EndPointPos.Length)
            {
                if (GamePlayHandler.instance.GameModes[GameManagerScript.instance.CurrentMode].GameLevels[GameManagerScript.instance.CurrentLevel].EndCin != null)
                {
                    GamePlayHandler.instance.EndCinDelay();
                    UIManager.instance.OnLevelComplete.Invoke();
                }
                else
                {
                    UIManager.instance.OnLevelComplete.Invoke();
                }
            }
            else
            {
                Debug.Log(" Level 1 chapter :" + currentEndIndex);
                UIManager.instance.Ad.SetActive(true);
                //GamePlayHandler.instance.currentFootIndex = currentEndIndex;
                GamePlayHandler.instance.ActiveObjectives();
            }
        }

        else
        {
            Debug.Log(" Does Nothing");
            Debug.Log(currentEndIndex + " Just for testing");
        }
        UIManager.instance.HintBtn.interactable = true;
    }
}

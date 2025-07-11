using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelsHandling : MonoBehaviour
{
    public static LevelsHandling Instance;
    public Text Levelno;
    public HealthHandling HealthHandle;
    public GameObject Baby;
    public GameObject Mother;
    public GameObject Bats;
    public GameObject ForestBats;
    public GameObject cat;
    public GameObject ForestCat1;
    public GameObject ForestCat2;
    public GameObject cupboardTrigger;
    public GameObject cupboardDoor;
    public GameObject cupboardNun;
    public GameObject cupboardSkull;
    public GameObject BoxHand;
    public GameObject Box;
    public GameObject BoxTrigger;
    public GameObject BoxEffect;
    public GameObject WheelChair;
    public GameObject RevolvingChair;
    public GameObject ChairTrigger;
    public GameObject ChairGranny;
    public GameObject Football;
    public GameObject ScareMeTrigger;
    public GameObject ScareGranny;
    public GameObject grannyLaugh;
    public Material Grannymat;
    public GameObject HouseGranny;
    public GameObject HouseTrigger;
    public GameObject ScarePlayerTrigger;
    public GameObject crawlingNun;

    [Header("Level 1")]
    public GameObject CrawlingGranny;
    private void Awake()
    {
        Instance = this;
    }
    void Start()
    {
        levelnoHandle();
        if (GameManagerScript.instance.CurrentLevel == 2)
        {
            cupboardTrigger.SetActive(true);
            cupboardNun.SetActive(true);
            Baby.SetActive(true);
        }

    }
    public void levelnoHandle()
    {
        if (GamePlayHandler.instance.currentObjectiveIndex == 0)
        {
            Levelno.text = "1";
        }
        if (GamePlayHandler.instance.currentObjectiveIndex == 1)
        {
            Levelno.text = "2";
        }
        if (GamePlayHandler.instance.currentObjectiveIndex == 2)
        {
            Levelno.text = "3";
        }
        if (GamePlayHandler.instance.currentObjectiveIndex == 3)
        {
            Levelno.text = "4";
        }
        if (GamePlayHandler.instance.currentObjectiveIndex == 4)
        {
            Levelno.text = "5";
        }
        if (GamePlayHandler.instance.currentObjectiveIndex == 5)
        {
            Levelno.text = "6";
        }
        if (GamePlayHandler.instance.currentObjectiveIndex == 6)
        {
            Levelno.text = "7";
        }
    }

}

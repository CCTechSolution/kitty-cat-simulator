using AssetKits.ParticleImage;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UI_Manager : MonoBehaviour
{
    public static UI_Manager Instance;

    public Text objectiveText;

    public Slider progressSlider;
    private BaseObjective currentObjective;
    public Button GrabButton;
    public Button ThrowButton;
    [Space(10)]
    public Text diamondText;
    public Text keyText;
    public Text heartText;
    [Space(10)]
    public GameObject objectiveUpdateUI;
    public Text objectiveUpdateText;
    [Space(10)]
    public Text currentProgressText;
    public Text totalProgressText;
    [Space(10)]
    public Image musicImage;
    [Space(10)]
    public ParticleImage diamondParticleImage;
    public ParticleImage keyParticleImage;




    private void Awake() => Instance = this;

    private void Start()
    {        
        BaseObjective.OnProgressUpdated += UpdateProgressBar;
        BaseObjective.OnProgressCounterUpdate += UpdateProgressCounter;

        UpdateUI();
    }

    public void ShowGrabButton(bool show)=> GrabButton.gameObject.SetActive(show);
    public void ShowThrowButton(bool show)=> ThrowButton.gameObject.SetActive(show);

    public void UpdateMainQuest(string text)
    {
        objectiveText.text = text;
    }

    public void UpdateProgressBar(float progress)
    {
        progressSlider.value = progress;
    }

    public void AddDiamond(int amount)
    {
        diamondParticleImage.gameObject.SetActive(true);
        diamondParticleImage.Play();
        Invoke(nameof(DisableDiamondParticle), 4f);
        int diamonds = PlayerPrefs.GetInt("Diamonds", 0) + amount;
        PlayerPrefs.SetInt("Diamonds", diamonds);
        PlayerPrefs.Save();
        UpdateUI();
    }

    void DisableDiamondParticle()
    {
        diamondParticleImage.gameObject.SetActive(false);
    }

    public void AddKey(int amount)
    {
        keyParticleImage.gameObject.SetActive(true);
        keyParticleImage.Play();
        Invoke(nameof(DisableKeyParticle), 4f);
        int keys = PlayerPrefs.GetInt("Keys", 0) + amount;
        PlayerPrefs.SetInt("Keys", keys);
        PlayerPrefs.Save();
        UpdateUI();
    }

    void DisableKeyParticle()
    {
        keyParticleImage.gameObject.SetActive(false);
    }

    public void AddHeart(int amount)
    {
        int hearts = PlayerPrefs.GetInt("Hearts", 0) + amount;
        PlayerPrefs.SetInt("Hearts", hearts);
        PlayerPrefs.Save();
        UpdateUI();
    }

    private void UpdateUI()
    {
        diamondText.text = PlayerPrefs.GetInt("Diamonds", 0).ToString();
        keyText.text = PlayerPrefs.GetInt("Keys", 0).ToString();
        heartText.text = PlayerPrefs.GetInt("Hearts", 0).ToString();
    }

    public void UpdateProgressCounter(int currentProgress, int totalProgress)
    {
        currentProgressText.text = currentProgress.ToString();
        totalProgressText.text = totalProgress.ToString();
    }
    public void ObjectiveUpdateUI(string objText)
    {
        objectiveUpdateUI.gameObject.SetActive(true);
        objectiveUpdateText.text = objText;
    }

    public void ToggleSound()
    {
        if (MusicManager.Instance)
            MusicManager.Instance.ToggleSound(musicImage);
        else Debug.Log("Music manager instance not found");
    }
}

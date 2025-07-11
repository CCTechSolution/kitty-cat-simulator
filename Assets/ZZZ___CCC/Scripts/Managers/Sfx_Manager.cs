using UnityEngine;
using UnityEngine.UI;

public class Sfx_Manager : MonoBehaviour
{
    public static Sfx_Manager Instance;

    public static bool canPlaySound = true;

    public AudioClip[] objectPick;
    public AudioClip[] objectThrow;
    public AudioClip[] keysCollect;
    public AudioClip[] diamondCollect;
    public AudioClip[] updateUIText;
    public AudioClip[] MissionComplete;
    public AudioClip[] MissionFail;
    public AudioClip[] PauseResume;
    public AudioClip[] breakItemEffect;
    public AudioClip[] goalSound;
    public AudioClip[] popSound;
    public AudioClip[] buttonClick;
    public AudioClip[] cashSound;
    public AudioClip[] spawnSound;

    
    [Space(10)]
    [Header("Granny Sounds")]
    public AudioClip[] StopAndNoSound;
    public AudioClip[] grannyAttack;
    public AudioClip[] dangerSound;


    [Space(10)]
    [SerializeField] Sprite SoundOnImage;
    [SerializeField] Sprite SoundOffImage;
    
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Debug.LogError("Another instance was present of " + Sfx_Manager.Instance.name +" so it was destroyed");
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        PlayerPrefs.SetInt("Sound", 1);
        Debug.Log("Sound player prefs is :" + PlayerPrefs.GetInt("Sound"));
    }

    public static void PlayRandomSound(AudioClip[] clips,float volume = 1f)
    {
        if (clips == null || clips.Length == 0)
        {
            Debug.LogWarning("No clips assigned to Sfx_Manager!");
            return;
        }
        if (canPlaySound)
        {
            int randomIndex = Random.Range(0, clips.Length);
            AudioClip clipToPlay = clips[randomIndex];

            GameObject AudioObj = new GameObject("TempAudio");
            AudioSource audioSource = AudioObj.AddComponent<AudioSource>();

            audioSource.volume = volume;
            audioSource.clip = clipToPlay;
            audioSource.Play();

            Object.Destroy(AudioObj, clipToPlay.length);
        }
        

    }

    public void ToggleSoundEffects(Image soundImage)
    {
        if (canPlaySound)
        {
            canPlaySound = false;
            PlayerPrefs.SetInt("Sound", 0);
            soundImage.sprite = SoundOffImage;
        }
        else
        {
            canPlaySound= true;            
            PlayerPrefs.SetInt("Sound",1);
            soundImage.sprite = SoundOnImage;
        }
        Debug.Log("Sound state is : "+ canPlaySound);
    }

    public void SetSoundImageAtStart(Image soundImage)
    {
        if (PlayerPrefs.GetInt("Sound") == 1)
        {
            soundImage.sprite = SoundOnImage;
        }
        else
        {
            soundImage.sprite = SoundOffImage;
        }
        Debug.Log("Sound player prefs is :" + PlayerPrefs.GetInt("Sound"));
    }

    public void SetOnImage(Image image)
    {
        image.sprite = SoundOnImage;
    }
    public void SetOffImage(Image image)
    {
        image.sprite = SoundOffImage;
    }
}


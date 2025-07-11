using UnityEngine;


public class AudioClipsSource : MonoBehaviour
{

    [Header("Music Clips")]
    public AudioClip MainMenuClip;
    public AudioClip GamePlayClip;
    public AudioClip LoadingClip;

    public AudioClip PlayButtonClick;
    public AudioClip GenericButtonClip;

    public AudioClip LevelFailedClip;
    public AudioClip LevelSuccessClip;
    public AudioClip LockDoor;
    public AudioClip NunKilling;
    public AudioClip PlayerScream;


    public static AudioClipsSource Instance;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            DontDestroyOnLoad(this.gameObject);
        }
    }
}

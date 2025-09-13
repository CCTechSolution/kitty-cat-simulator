using UnityEngine;
using UnityEngine.UI;

public class MusicManager : MonoBehaviour
{
    public static MusicManager Instance;
    
    public bool isON = true;

    [SerializeField] private AudioSource musicSource;
    [SerializeField] Sprite offMusicImage;
    [SerializeField] Sprite onMusicImage;


    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
            return;
        }
    }

  

    public void ToggleSound(Image image)
    {
        if (isON)
        {
            isON = false;
            image.sprite = offMusicImage;
            musicSource.mute = true;
        }
        else
        {
            isON = true;
            image.sprite = onMusicImage;
            musicSource.mute = false;
        }
    }

    public void OnStartSetImage(Image musicImage)
    {
        if (isON)
        {
            musicImage.sprite = onMusicImage;
        }
        else
        {
            musicImage.sprite = offMusicImage;
        }
    }
}

using UnityEngine;
using UnityEngine.UI;

public class Setting : MonoBehaviour
{
    [SerializeField] Image musicImage;
    [SerializeField] Image soundImage;


    private void Start()
    {
        Sfx_Manager.Instance.SetSoundImageAtStart(soundImage);
        MusicManager.Instance.OnStartSetImage(musicImage);
    }
    public void ToggleSound()
    {
        MusicManager.Instance.ToggleSound(musicImage);
    }
    public void ToggleSoundEffects()
    {
        Sfx_Manager.Instance.ToggleSoundEffects(soundImage);
    }
}

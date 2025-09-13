using UnityEngine;
using UnityEngine.UI;

public class SettingGameplay : MonoBehaviour
{
    [SerializeField] Image soundImage;
    [SerializeField] Image musicImage;

    private void Start()
    {
        Debug.Log("Sfx button state is :" + Sfx_Manager.canPlaySound);
        MusicManager.Instance.OnStartSetImage(musicImage);
        if (Sfx_Manager.canPlaySound)
        {
            Sfx_Manager.Instance.SetOnImage(soundImage);
        }
        else
        {
            Sfx_Manager.Instance.SetOffImage(soundImage);
        }
    }

    public void ToggleMusic()
    {
        MusicManager.Instance.ToggleSound(musicImage);
    }

    public void ToggleSoundEffect()
    {
        Sfx_Manager.Instance.ToggleSoundEffects(soundImage);
    }
}

using UnityEngine;

public class UiManagerMainmenu : MonoBehaviour
{
    public GameObject SettingPanel;
    public GameObject MainmenuPanel;
    public GameObject ModeSelectionPanel;
    public GameObject ExitPanel;
    public GameObject LoadingScreenPanel;

    public void OnPlayButtonClicked()
    {
        MainmenuPanel.SetActive(false);
        ModeSelectionPanel.SetActive(true);
        PlayUISound();
    }
    public void OnSettingButtonClicked()
    {
        MainmenuPanel.SetActive(false);
        SettingPanel.SetActive(true);
        PlayUISound();
    }
    public void OnSettingBackButtonClicked()
    {
        SettingPanel.SetActive(false);
        MainmenuPanel.SetActive(true);
        Sfx_Manager.PlayRandomSound(Sfx_Manager.Instance.buttonClick);
    }
    public void OnStoryModeButtonClicked()
    {
        ModeSelectionPanel.SetActive(false);
        LoadingScreenPanel.SetActive(true);
        Sfx_Manager.PlayRandomSound(Sfx_Manager.Instance.buttonClick);
    }

    public void OnBackModeSelectionButtonClicked()
    {
        ModeSelectionPanel.SetActive(false);
        MainmenuPanel.SetActive(true);
        Sfx_Manager.PlayRandomSound(Sfx_Manager.Instance.buttonClick);
    }

    void PlayUISound()
    {
        Sfx_Manager.PlayRandomSound(Sfx_Manager.Instance.buttonClick);
        Sfx_Manager.PlayRandomSound(Sfx_Manager.Instance.popSound);
    }
}

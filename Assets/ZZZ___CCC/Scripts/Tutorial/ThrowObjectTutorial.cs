using UnityEngine;

public class ThrowObjectTutorial : MonoBehaviour
{
    private void OnEnable()
    {
        Player_Interaction.OnAnyObjectThrow += Player_Interaction_OnAnyObjectThrow;
    }
    private void OnDisable()
    {
        Player_Interaction.OnAnyObjectThrow -= Player_Interaction_OnAnyObjectThrow;
    }

    private void Player_Interaction_OnAnyObjectThrow()
    {
        gameObject.SetActive(false);
        PlayerPrefs.SetInt("Tutorial", 1);
    }
}

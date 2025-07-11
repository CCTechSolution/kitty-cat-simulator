using UnityEngine;

public class EnteringGameplay : MonoBehaviour
{
    [Header("On New Game")]
    [SerializeField] GameObject[] gameObjectsToActivateNewGame;
    [SerializeField] GameObject[] gameObjectsToDisableNewGame;

    [Space(10)]
    [Header("On Previous Game")]
    [SerializeField] GameObject[] gameObjectsToActivatePrevGame;
    [SerializeField] GameObject[] gameObjectsToDisablePrevGame;

    public bool WithTutorial;

    private void OnEnable()
    {
        if (!WithTutorial)
            Invoke(nameof(CheckGameState), 0.1f);
        else AtTutorialEnd();

    }

    void CheckGameState()
    {
        if (PlayerPrefs.GetInt("Tutorial") == 1)
        {
            //Previouse game
            SetActivation(gameObjectsToActivatePrevGame, true);
            SetActivation(gameObjectsToDisablePrevGame, false);
        }
        else
        {
            //New Game
            SetActivation(gameObjectsToActivateNewGame, true);
            SetActivation(gameObjectsToDisableNewGame, false);
        }
    }
    void SetActivation(GameObject[] gameobjects, bool condition)
    {
        foreach (GameObject gameObject in gameobjects)
        {
            gameObject.SetActive(condition);
        }
    }


    public void AtTutorialEnd()
    {
        //Previouse game
        SetActivation(gameObjectsToActivatePrevGame, true);
        SetActivation(gameObjectsToDisablePrevGame, false);
    }
}

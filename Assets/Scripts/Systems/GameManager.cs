using UnityEngine;

// the GameManager-prefab and the InGameMenuCanvas-prefab both go into the GamePlay scenes 
// make sure to also add a UI/EventSystem
// the MainMenu-prefab goes into the MainMenu scene

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public bool isGameOver = false;

    private void Awake()
    {
        if (instance == null) instance = this;
        else Destroy(gameObject);
    }

    public void GameOver()
    {
        isGameOver = true;
        Debug.Log("GameOver called");
        UIManager _ui = GetComponent<UIManager>();
        if (_ui != null)
        {
            Debug.Log("UI manager found");
            _ui.ToggleDeathPanel();
        }
    }

    /*
     * in PlayerHealth or something like that:
    private void PlayerDied()
    {
        Debug.Log("Player died called");
        GameManager.instance.GameOver();
        gameObject.SetActive(false);
    }

     */
}

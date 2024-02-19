using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    // Singleton instance
    public static GameManager Instance = null;

    public enum GameState
    {
        MainMenu,
        Game,
        Paused,
		Settings,
		Exit
    }

    private GameState gameState;

    [SerializeField]
    private Object loadingScene;

    void Awake()
    {
        // Ensure only one GameManager Instance exists
        if (Instance == null)
        {
            Instance = this;
        }
        else if (Instance != this)
        {
            Destroy(this.gameObject);
        }

        // Initialize game state
        gameState = GameState.MainMenu;
    }

    public void ChangeGameState(GameState newGameState)
    {
        if (gameState != newGameState)
        {
            gameState = newGameState;
        }

        switch (gameState)
        {
            case GameState.MainMenu:
                LoadScene("MainMenu");
                break;
            case GameState.Game:
                LoadScene("Game");
                break;
            case GameState.Paused:
				// Is pause menu open?
				// No - Show pause menu
				// Yes - Close pause menu
				break;
			case GameState.Settings:
				// Is settings open?
				// No - Show settings
				// Yes - Close settings
				break;
			case GameState.Exit:
                Application.Quit();
                break;
        }
    }

    public void LoadScene(string sceneName)
    {
        if (loadingScene != null)
        {
            SceneManager.LoadSceneAsync(loadingScene.name);
        }
        StartCoroutine(LoadNextScene(sceneName));
    }

    IEnumerator LoadNextScene(string sceneName)
    {
        AsyncOperation asyncLoading = SceneManager.LoadSceneAsync(sceneName);
        
        while (!asyncLoading.isDone)
        {
            yield return null;
        }
    }
}

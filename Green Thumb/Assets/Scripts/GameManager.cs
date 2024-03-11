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

	public enum GameSpeed
	{
		Paused,
		Half,
		Normal,
        Double,
	}

	private GameState gameState;
    private GameSpeed gameSpeed;

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

        // Initialize game state and speed
        gameState = GameState.MainMenu;
        gameSpeed = GameSpeed.Normal;
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

    public void ChangeGameSpeed(GameSpeed newGameSpeed)
    {
		if (gameSpeed != newGameSpeed)
		{
			gameSpeed = newGameSpeed;
		}

		switch (gameSpeed)
        {
            case GameSpeed.Paused:
                Time.timeScale = 0f;
                break;
			case GameSpeed.Half:
				Time.timeScale = 0.5f;
				break;
			case GameSpeed.Normal:
				Time.timeScale = 1f;
				break;
			case GameSpeed.Double:
				Time.timeScale = 2f;
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

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public enum GameState
    {
		None ,
        MainMenu,
        Game,
		FridgeLayoutVideo,
        FridgeLayout,
        HazardPerceptionVideo,
        HazardPerception
    }

	public static GameManager Instance;
	public GameState gameState;

	private void Awake()
	{
		if (Instance == null)
		{
			Instance = this;
		}
		else if (Instance != this)
		{
			Destroy(gameObject);
		}

		SetGameState(GetGameStateByScene());
	}

	private GameState GetGameStateByScene()
	{
		string activeSceneName = SceneManager.GetActiveScene().ToString();

		switch (activeSceneName)
		{
			case "None":
				return GameState.None;
			case "MainMenu":
				return GameState.MainMenu;
			case "Game":
				return GameState.Game;
            case "FridgeLayoutVideo":
                return GameState.FridgeLayoutVideo;
            case "FridgeLayout":
				return GameState.FridgeLayout;
            case "HazardPerceptionVideo":
                return GameState.HazardPerceptionVideo;
            case "HazardPerception":
                return GameState.HazardPerception;
		}

		return GameState.None;
	}

	public GameState GetGameState
	{
		get { return gameState; }
	}

	public void SetGameState(GameState newGameState)
	{
		if (gameState != newGameState)
		{
			gameState = newGameState;
			SceneManager.LoadScene(gameState.ToString());
		}
		else { return; }
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
	[HideInInspector]
    public enum GameState
    {
		Null ,
        MainMenu,
        Game,
        Completed
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
			case "Null":
				return GameState.Null;
			case "MainMenu":
				return GameState.MainMenu;
			case "Game":
				return GameState.Game;
			case "Completed":
				return GameState.Completed;
		}

		return GameState.Null;
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

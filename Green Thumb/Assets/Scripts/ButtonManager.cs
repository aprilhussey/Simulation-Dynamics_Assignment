using UnityEngine;

public class ButtonManager : MonoBehaviour
{
    public void OnPlayClick()
    {
        GameManager.Instance.ChangeGameState(GameManager.GameState.Game);
    }

    public void OnExitClick()
    {
		GameManager.Instance.ChangeGameState(GameManager.GameState.Exit);
	}


	// Game speed
	public void OnHalfSpeedClick()
	{
		GameManager.Instance.ChangeGameSpeed(GameManager.GameSpeed.Half);
	}

	public void OnPausedSpeedClick()
    {
        GameManager.Instance.ChangeGameSpeed(GameManager.GameSpeed.Paused);
    }

	public void OnNormalSpeedClick()
	{
		GameManager.Instance.ChangeGameSpeed(GameManager.GameSpeed.Normal);
	}

	public void OnDoubleSpeedClick()
	{
		GameManager.Instance.ChangeGameSpeed(GameManager.GameSpeed.Double);
	}
}

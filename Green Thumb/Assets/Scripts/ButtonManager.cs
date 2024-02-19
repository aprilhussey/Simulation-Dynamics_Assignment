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
}

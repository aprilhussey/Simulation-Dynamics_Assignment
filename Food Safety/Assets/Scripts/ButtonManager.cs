using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonManager : MonoBehaviour
{
    public void OnStartTrainingClick()
    {
        GameManager.Instance.SetGameState(GameManager.GameState.Game);
    }
}

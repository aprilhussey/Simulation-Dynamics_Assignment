using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeGameState : MonoBehaviour
{
    [SerializeField]
    private GameManager.GameState gameStateToChangeTo;

    public void ChangeGameStateOnClick()
    {
        GameManager.Instance.SetGameState(gameStateToChangeTo);
    }
}

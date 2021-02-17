using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    #region singleton
    private static GameManager instance;
    public static GameManager Instance
    {
        get
        {
            if (instance == null)
                Debug.Log("Game Manager Not Found On The Scene");
            return instance;
        }
    }

    private void Awake()
    {
        instance = this;
    }
    #endregion


    [Header("Limit")]
    private const int MAX_SCORE = 195;

    [Header("Score and Remained Turn")]
    public static int score = 0;
    public static int turnRemained = 25;

    public void CheckGame()
    {
        if (turnRemained == 0)
        {
            if(score < MAX_SCORE)
                Lose();
            else
                Win();
            return;
        }

        if (score >= MAX_SCORE)
            Win();
    }

    private void Win()
    {
        // TODO
        Debug.Log("You win");
    }

    private void Lose()
    {
        // TODO
        Debug.Log("You lose");
    }

}

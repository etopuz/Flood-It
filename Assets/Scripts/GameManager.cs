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

    public enum State
    {
        Playing,
        Win,
        Lose
    }

    [Header("Limit")]
    private const int MAX_SCORE = 195;

    [Header("Game Info")]
    public static int score = 0;
    public static int moves = 25;
    public static int win = 0;
    public static State state = State.Playing;

    public void CheckGame()
    {
        if (moves == 0)
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
        win += 1;
        state = State.Win;
        Debug.Log("You win");
    }

    private void Lose()
    {
        state = State.Lose;
        Debug.Log("You lose");
    }

}

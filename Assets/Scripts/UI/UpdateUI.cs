using System;
using UnityEngine;
using UnityEngine.UI;


public class UpdateUI : MonoBehaviour
{   
    [Header("Game Info")]
    [SerializeField] private Text moves = null;
    [SerializeField] private Text score = null;
    [SerializeField] private Text win = null;

    [Header("Game Over References")]
    [SerializeField] private GameObject inputPanel = null;
    [SerializeField] private Image gameOverImage = null;
    [SerializeField] private Text gameOverText = null;

    public void UpdateTexts()
    {
        score.text = string.Format("Score: {0:g}", GameManager.score).ToString();
        moves.text = string.Format("Moves: {0:g}", GameManager.moves).ToString();
        win.text = string.Format("Win: {0:g}", GameManager.win).ToString();
    }

    public void GameOver()
    {
        inputPanel.SetActive(false);
        gameOverImage.enabled = true;
        gameOverText.enabled = true;
        gameOverText.text = "Game Over! ";
        gameOverText.text += GameManager.State.Win == GameManager.state ? "You Win." : "You Lose.";
        gameOverText.text += "\nPress Restart Game For Continue Playing";
    }

}

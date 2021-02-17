using System;
using UnityEngine;
using UnityEngine.UI;


public class UpdateUI : MonoBehaviour
{
    [SerializeField] private Text score;
    [SerializeField] private Text turn;

    private void Awake()
    {
        score = transform.GetChild(1).GetComponent<Text>();
        turn = transform.GetChild(2).GetComponent<Text>();
    }

    public void UpdateTexts(int _score, int _turn)
    {
        score.text = string.Format("Score: {0:g}",_score).ToString();
        turn.text = string.Format("Turn: {0:g}/25", _turn).ToString();
    }

}

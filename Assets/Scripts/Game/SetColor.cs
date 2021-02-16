using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;


public class SetColor : MonoBehaviour
{
    [SerializeField]    private Button button;
    [SerializeField]    private Color buttonColor;
    [SerializeField]    private PlayerController playerController;

    private void Awake()
    {
        playerController = GameObject.FindGameObjectWithTag("GameBoard").GetComponent<PlayerController>();
        buttonColor = this.GetComponent<Image>().color;
        Button button = this.GetComponent<Button>();
        button.onClick.AddListener(TaskOnClick);
    }

    void TaskOnClick()
    {
        playerController.Game(buttonColor);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

public class ResetGame : MonoBehaviour
{
    [SerializeField] private Button button;

    private void Awake()
    {
        Button button = this.GetComponent<Button>();
        button.onClick.AddListener(TaskOnClick);
    }

    private void TaskOnClick()
    {
        SceneManager.LoadScene(SceneManager.GetSceneAt(0).name);
        GameManager.score = 0;
        GameManager.turnRemained = 25;
    }
}

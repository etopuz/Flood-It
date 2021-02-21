using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Help : MonoBehaviour
{
    [Header("UI Elements")]
    [SerializeField] private Button button;
    [SerializeField] private Text helpText;
    [SerializeField] private Image transparentScreen;
    [SerializeField] private bool isHelpOpened;

    private void Awake()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(HandleHelp);
        isHelpOpened = false;
    }

    private void HandleHelp()
    {
        transparentScreen.enabled = isHelpOpened;
        helpText.enabled = isHelpOpened;
        isHelpOpened = !isHelpOpened;
    }
}

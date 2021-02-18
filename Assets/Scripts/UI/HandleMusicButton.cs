using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class HandleMusicButton : MonoBehaviour
{
    [SerializeField] private Button button;
    [SerializeField] private bool isSoundOpened;
    [SerializeField] Slider slider;
    [SerializeField] GameObject disableIcon;


    public void Awake()
    {
        isSoundOpened = true;

        slider = transform.GetChild(0).GetComponent<Slider>();
        button = GetComponent<Button>();
        button.onClick.AddListener(HandleSlideBar);

    }


    private void HandleSlideBar()
    {

        if (isSoundOpened)
        {
            slider.value = 0f;
            slider.gameObject.SetActive(false);
            disableIcon.SetActive(true);
        }

        else
        {
            slider.gameObject.SetActive(true);
            disableIcon.SetActive(false);
        }

        isSoundOpened = !isSoundOpened;


    }





}

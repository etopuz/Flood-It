using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HeaderRandomColor : MonoBehaviour
{
    [SerializeField] Text text;
    [SerializeField] float timeLimit = 0;
    [SerializeField] Color targetColor;
    private void Awake()
    {
        text = this.GetComponent<Text>();
    }

    private void Update()
    {
        ChangeColor();
    }

    private void ChangeColor()
    {
        if (timeLimit <= Time.deltaTime)
        {
            float R = Random.Range(0.1f, 0.8f);
            float G = Random.Range(0.1f, 0.8f);
            float B = Random.Range(0.1f, 0.8f);

            targetColor = new Color(R, G, B);

            timeLimit = 0.8f;
        }

        else
        {
            text.color = Color.Lerp(text.color, targetColor, Time.deltaTime * 1.25f);
            timeLimit -= Time.deltaTime;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


[System.Serializable]
public class Tile : MonoBehaviour
{

    public Tile right;
    public Tile left;
    public Tile down;
    public Tile upper;

    public static Color[] colours = new Color[6] 
    {
        Color.red,
        Color.blue,
        Color.magenta,
        Color.cyan,
        Color.green,
        Color.yellow
    };

    public Color color;
    Image image;

    private void Awake()
    {
        color = colours[Random.Range(0, colours.Length)];
        image = GetComponent<Image>();
        image.color = color;
    }

    public void ChangeColor(Color color)
    {
        this.color = color;
        image.color = color;
    }
}

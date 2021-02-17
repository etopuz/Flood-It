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

    public static Color[] colours = new Color[6] {
        Color.red,
        Color.blue,
        Color.magenta,
        Color.cyan,
        Color.green,
        Color.yellow};

    private Color color;
    Image image;

    public Color Color { get => color; set => color = value; }

    private void Awake()
    {
        Color = colours[Random.Range(0, colours.Length)];
        image = GetComponent<Image>();
        image.color = Color;
    }

    public void ChangeColor(Color color)
    {
        Color = color;
        image.color = Color;
    }
}

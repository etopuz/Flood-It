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
        new Color(1f,0f,0f,1f),             // red 
        new Color(1f, 0.92f, 0.016f, 1f),   // yellow
        new Color(0f,1f,1f,1f),             // cyan
        new Color(0f,0f,1f,1f),             // blue
        new Color(0f,1f,0f,1f),             // green
        new Color(1f,0f,1f,1f)              // magenta
    };

    public Color color;
    public bool isOccupied;
    Image image;

    private void Awake()
    {
        isOccupied = false;
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

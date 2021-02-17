using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Board Info")]
    [SerializeField] private const int edge = 14;
    [SerializeField] private Color currentColor;
    [SerializeField] private Tile [] allTiles;
    [SerializeField] private List<Tile> occupiedTiles;
    [SerializeField] private List<Tile> occupiedEdgeTiles;


    private void Start()
    {
        InitializeBoard();
    }

    public void Play(Color color)
    {
       
        
    }

    private void ChangeEdges()
    {
    
    }

    private void ChangeOccupiedTilesColors(Color color)
    {
  
    }

    private void InitializeBoard()
    {
        allTiles = transform.gameObject.GetComponentsInChildren<Tile>();
        BoardOperations.Initialize(allTiles);
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Board Info")]
    [SerializeField] private int edge = 14;

    [Header("Tile Lists")]
    [SerializeField] private Tile [] allTiles;
    [SerializeField] private List<Tile> occupiedTiles;
    [SerializeField] private List<Tile> occupiedEdgeTiles;

    [Header("References")]
    [SerializeField] private BoardOperations boardOperations;

    private void Awake()
    {
        boardOperations = GetComponent<BoardOperations>();
    }

    private void Start()
    {
        InitializeBoard();
    }

    public void Play(Color color)
    {
        for(int i = 0; i < occupiedEdgeTiles.Count; i++)
        {

        }

        boardOperations.FloodOccupiedTiles(occupiedTiles, color);
        boardOperations.UpdateEdges(occupiedEdgeTiles);
    }

    private void InitializeBoard()
    {
        allTiles = transform.gameObject.GetComponentsInChildren<Tile>();
        boardOperations.Initialize(allTiles);

        Tile firstTile = allTiles[0];
        occupiedTiles.Add(firstTile);
        occupiedEdgeTiles.Add(firstTile);
    }
}

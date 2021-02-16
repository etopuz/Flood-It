using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Board Info")]
    [SerializeField] private const int edge = 14;
    [SerializeField] private Color currentColor;

    private Tile[,] tiles;
    private List<List<int>> edgeTileIndexes = new List<List<int>>();
    private List<List<int>> occupiedTileIndexes = new List<List<int>>();

    private void Awake()
    {
        tiles = new Tile[edge, edge];
    }

    private void Start()
    {
        InitializeBoard();
        currentColor = tiles[0, 0].Color;
        edgeTileIndexes.Add(new List<int> { 0, 0 });
        occupiedTileIndexes.Add(new List<int> { 0, 0 });
    }

    public void Game(Color color)
    {
        int row, column;
        bool shouldCheckLeft, shouldCheckRight, shouldCheckUpper, shouldCheckDown;
        bool isColorChanged = false;

        for (int i = 0; i< edgeTileIndexes.Count; i++)
        {
            row = edgeTileIndexes[i][0];
            column = edgeTileIndexes[i][1];

            shouldCheckRight = column != edge - 1;
            shouldCheckLeft = column != 0;
            shouldCheckDown = row != edge - 1;
            shouldCheckUpper = row != 0;

            Tile rightTile, leftTile, downTile, upperTile;

            if (shouldCheckRight)
            {
                rightTile = tiles[row, column + 1];

                if(rightTile.Color == color)
                {
                    isColorChanged = true;
                }
            }
                
            if (shouldCheckLeft)
            {
                leftTile = tiles[row, column - 1];

                if (leftTile.Color == color)
                {
                    isColorChanged = true;
                }
            }
                
            if (shouldCheckDown)
            {
                downTile = tiles[row + 1, column];

                if (downTile.Color == color)
                {
                    isColorChanged = true;
                }

            }
                
            if (shouldCheckUpper)
            {
                upperTile = tiles[row - 1, column];

                if (upperTile.Color == color)
                {
                    isColorChanged = true;
                }
            }

            if (isColorChanged)
            {
                ChangeOccupiedTilesColors(color);
            }
                
        }
    }

    public void ChangeOccupiedTilesColors(Color color)
    {
        int row, column;
        for (int i = 0; i< occupiedTileIndexes.Count; i++)
        {
            row = edgeTileIndexes[i][0];
            column = edgeTileIndexes[i][1];
            tiles[row, column].ChangeColor(color);

        }
    }

    private void InitializeBoard()
    {
        Tile[] allTiles = transform.gameObject.GetComponentsInChildren<Tile>();

        for (int i = 0; i < edge; i++)
        {
            for (int j = 0; j < edge; j++)
            {
                tiles[i, j] = allTiles[i * edge + j];
            }
        }

    }
}

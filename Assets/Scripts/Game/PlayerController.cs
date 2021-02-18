using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Tile Lists")]
    [SerializeField] private Tile [] allTiles;
    [SerializeField] private List<Tile> occupiedTiles = new List<Tile>();
    [SerializeField] private List<Tile> occupiedEdgeTiles = new List<Tile>();

    [Header("References")]
    [SerializeField] private BoardOperations boardOperations;
    [SerializeField] private UpdateUI uI;

    

    private void Awake()
    {
        boardOperations = GetComponent<BoardOperations>();
        uI = GameObject.FindWithTag("UserPanel").GetComponent<UpdateUI>();
    }

    private void Start()
    {
        InitializeBoard();
        uI.UpdateTexts();
    }

    public void Play(Color color)
    {
        Tile currentTile;
        bool isColorChanged = false;
        for (int i = 0; i < occupiedEdgeTiles.Count; i++)
        {
            currentTile = occupiedEdgeTiles[i];

            if (currentTile.right != null)
            {
                var v = boardOperations.CheckPossibleTiles(currentTile.right, occupiedTiles, occupiedEdgeTiles, color);
                isColorChanged = v == true ? v : isColorChanged;
            }

            if (currentTile.left != null)
            {
                var v = boardOperations.CheckPossibleTiles(currentTile.left, occupiedTiles, occupiedEdgeTiles, color);
                isColorChanged = v == true ? v : isColorChanged;
            }

            if (currentTile.upper != null)
            {
                var v = boardOperations.CheckPossibleTiles(currentTile.upper, occupiedTiles, occupiedEdgeTiles, color);
                isColorChanged = v == true ? v : isColorChanged;
            }

            if (currentTile.down != null)
            {
                var v = boardOperations.CheckPossibleTiles(currentTile.down, occupiedTiles, occupiedEdgeTiles, color);
                isColorChanged = v == true ? v : isColorChanged;
            }
        }

        if (isColorChanged)
        {
            boardOperations.FloodOccupiedTiles(occupiedTiles, color);
            boardOperations.UpdateEdges(occupiedEdgeTiles);
            UpdateGame();
        }
    }

    private void UpdateGame()
    {
        GameManager.score = occupiedTiles.Count;
        GameManager.moves -= 1;
        GameManager.Instance.CheckGame();

        uI.UpdateTexts();
        
        if (GameManager.state != GameManager.State.Playing)
            uI.GameOver();
    }

    private void InitializeBoard()
    {
        allTiles = transform.gameObject.GetComponentsInChildren<Tile>();
        boardOperations.Initialize(allTiles);
        Tile firstTile = allTiles[0];
        occupiedTiles.Add(firstTile);
        occupiedEdgeTiles.Add(firstTile);
        firstTile.isOccupied = true;
    }
}

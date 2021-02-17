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
        uI = GameObject.FindWithTag("Texts").GetComponent<UpdateUI>();
    }

    private void Start()
    {
        InitializeBoard();
        uI.UpdateTexts(GameManager.score, GameManager.turnRemained);
    }

    public void Play(Color color)
    {
        Tile currentTile;
        bool isColorChanged = false;

        for (int i = 0; i < occupiedEdgeTiles.Count; i++)
        {
            currentTile = occupiedEdgeTiles[i];

            if (currentTile.right != null)
                boardOperations.CheckPossibleTiles(isColorChanged, currentTile.right, occupiedTiles, occupiedEdgeTiles, color);
            if (currentTile.left != null)
                boardOperations.CheckPossibleTiles(isColorChanged, currentTile.left, occupiedTiles, occupiedEdgeTiles, color);
            if (currentTile.upper != null)
                boardOperations.CheckPossibleTiles(isColorChanged, currentTile.upper, occupiedTiles, occupiedEdgeTiles, color);
            if (currentTile.down != null)
                boardOperations.CheckPossibleTiles(isColorChanged, currentTile.down, occupiedTiles, occupiedEdgeTiles, color);
        }

        boardOperations.FloodOccupiedTiles(occupiedTiles, color);
        boardOperations.UpdateEdges(occupiedEdgeTiles);

        UpdateGame();

    }

    private void UpdateGame()
    {
        GameManager.score = occupiedTiles.Count;
        GameManager.turnRemained -= 1;
        uI.UpdateTexts(GameManager.score, GameManager.turnRemained);
        GameManager.Instance.CheckGame();
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

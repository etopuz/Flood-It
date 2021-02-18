using System.Collections.Generic;
using UnityEngine;

public class BoardOperations : MonoBehaviour
{
    [SerializeField] private const int edge = 14;

    public void Initialize(Tile[] tiles)
    {
        bool isInTheRightEdge, isInTheLeftEdge, isInTheTopEdge, isInTheBottomEdge;
        Tile current;

        for (int i =0; i < tiles.Length; i++)
        {
            current = tiles[i];

            isInTheRightEdge = i % edge == 13;
            isInTheLeftEdge = i % edge == 0;
            isInTheTopEdge = i < 14;
            isInTheBottomEdge = i > 181;

            current.right = isInTheRightEdge ? null : tiles[i + 1];
            current.left = isInTheLeftEdge ? null : tiles[i - 1];
            current.down = isInTheBottomEdge ? null : tiles[i + edge];
            current.upper = isInTheTopEdge ? null : tiles[i - edge];
        }
    }


    public void UpdateEdges(List<Tile> occupiedEdgeTiles)
    {
        bool isEdge;
        Tile tile;
        for (int i = occupiedEdgeTiles.Count - 1; i >= 0; i--)
        {
            tile = occupiedEdgeTiles[i];
            isEdge = false;


            if (tile.right != null && tile.color != tile.right.color)
                isEdge = true;
            else if (tile.left != null && tile.color != tile.left.color)
                isEdge = true;
            else if (tile.upper != null && tile.color != tile.upper.color)
                isEdge = true;
            else if (tile.down != null && tile.color != tile.down.color)
                isEdge = true;

            if (!isEdge)
                occupiedEdgeTiles.Remove(tile);
        }
    }


    public void FloodOccupiedTiles(List<Tile> occupiedTiles, Color color)
    {
        for(int i = 0; i < occupiedTiles.Count; i++)
        {
            occupiedTiles[i].ChangeColor(color);
        }
    }


    public bool CheckPossibleTiles(Tile possibleTile, List<Tile> occupiedTiles, List<Tile> tempOccupiedEdgeTiles, Color color)
    {
        if (possibleTile.color == color && possibleTile.isOccupied == false)
        {
            possibleTile.isOccupied = true;
            occupiedTiles.Add(possibleTile);
            tempOccupiedEdgeTiles.Add(possibleTile);
            return true;
        }
        return false;
    }


}

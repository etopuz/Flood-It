using UnityEngine;

public class BoardOperations
{
    [SerializeField] private const int edge = 14;

    public static void Initialize(Tile[] tiles)
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


}

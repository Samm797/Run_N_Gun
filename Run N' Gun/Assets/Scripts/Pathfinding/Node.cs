using UnityEngine;

public class Node 
{
    public bool walkable;
    public Vector2 worldPosition;
    public int gridX;
    public int gridY;

    public int gCost;
    public int hCost;
    public Node parent;
    int heapIndex;

    public Node(bool Walkable, Vector2 WorldPos, int GridX, int GridY)
    {
        this.walkable = Walkable;
        this.worldPosition = WorldPos;
        this.gridX = GridX;
        this.gridY = GridY;
    }

    public int fCost
    {
        get
        {
            return gCost + hCost;
        }
    }
}

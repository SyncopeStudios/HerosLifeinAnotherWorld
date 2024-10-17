using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Room 
{
    public Vector2Int size;
    public Vector2Int position;
    public List<TileBase> tiles;
    
    public Room(Vector2Int size, Vector2Int position)
    {
        this.size = size;
        this.position = position;
        tiles = new List<TileBase>();
    }
}

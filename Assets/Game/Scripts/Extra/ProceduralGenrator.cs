using System.Collections.Generic;
using Game.Scripts.Extra;
using UnityEngine;
using UnityEngine.Tilemaps;

public class ProceduralGenrator : Singelton<ProceduralGenrator>
{
     public Sprite[] floorSprites;   // Array of floor sprites
    public Sprite[] wallSprites;    // Array of wall sprites
    public GameObject spriteRendererPrefab;  // Prefab for GameObjects with SpriteRenderer
    
    public Vector2Int minRoomSize = new Vector2Int(5, 5); // Minimum room size
    public Vector2Int maxRoomSize = new Vector2Int(10, 10); // Maximum room size

    private void Awake()
    {
        // Generate a random size for the room based on x and y separately
        int randX = Random.Range(minRoomSize.x, maxRoomSize.x);
        int randY = Random.Range(minRoomSize.y, maxRoomSize.y);

        // Create the room size Vector2Int with the random x and y values
        Vector2Int randRoomSize = new Vector2Int(randX, randY);

        // Call GenerateRoom with the random room size
        GenerateRoom(randRoomSize);
    }

    // Main entry point for room generation
    public void GenerateRoom(Vector2Int position)
    {
        // Generate a random room size
        Vector2Int roomSize = new Vector2Int(
            Random.Range(minRoomSize.x, maxRoomSize.x),
            Random.Range(minRoomSize.y, maxRoomSize.y)
        );

        // Generate floors and walls
        GenerateFloors(roomSize, position);
        GenerateWalls(roomSize, position);
    }

    // Generate floor tiles as GameObjects
    private void GenerateFloors(Vector2Int size, Vector2Int position)
    {
        for (int x = position.x; x < position.x + size.x; x++)
        {
            for (int y = position.y; y < position.y + size.y; y++)
            {
                Vector2 spawnPosition = new Vector2(x, y);
                GameObject floorGO = Instantiate(spriteRendererPrefab, spawnPosition, Quaternion.identity);

                // Randomly pick a floor sprite
                Sprite floorSprite = floorSprites[Random.Range(0, floorSprites.Length)];
                floorGO.GetComponent<SpriteRenderer>().sprite = floorSprite;
            }
        }
    }

    // Generate wall tiles as GameObjects
    private void GenerateWalls(Vector2Int size, Vector2Int position)
    {
        for (int x = position.x - 1; x <= position.x + size.x; x++)
        {
            for (int y = position.y - 1; y <= position.y + size.y; y++)
            {
                // If the current position is outside the bounds of the room (around the edges)
                if (x == position.x - 1 || x == position.x + size.x || y == position.y - 1 || y == position.y + size.y)
                {
                    Vector2 spawnPosition = new Vector2(x, y);
                    GameObject wallGO = Instantiate(spriteRendererPrefab, spawnPosition, Quaternion.identity);

                    // Randomly pick a wall sprite
                    Sprite wallSprite = wallSprites[Random.Range(0, wallSprites.Length)];
                    wallGO.GetComponent<SpriteRenderer>().sprite = wallSprite;
                }
            }
        }
    }
}

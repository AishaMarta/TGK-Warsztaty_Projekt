using System.Collections.Generic;
using UnityEngine;

public class BackgroundController : MonoBehaviour
{
    [SerializeField] private GameObject templateBackground;
    private float tileWidth = 10.24f;
    private float tileHeight = 7.68f;

    public int renderDistance; //minecraft referencja xd

    private Transform player;
    private Transform backgroundFolder;
    private HashSet<Vector2Int> spawnedCells = new HashSet<Vector2Int>();

    void Update()
    {
        if (!player || !backgroundFolder)
        {
            player = GameManager.instance.playerObject.transform;
            backgroundFolder = GameManager.instance.backgroundFolder.transform;
            return;
        }
        Vector2Int currentCell = new Vector2Int(
            Mathf.FloorToInt(player.position.x / tileWidth),
            Mathf.FloorToInt(player.position.y / tileHeight)
        );

        for (int dx = -renderDistance; dx <= renderDistance; dx++)
        {
            for (int dy = -renderDistance; dy <= renderDistance; dy++)
            {
                Vector2Int cell = new Vector2Int(currentCell.x + dx, currentCell.y + dy);
                if (!spawnedCells.Contains(cell))
                {
                    Vector3 spawnPos = new Vector3(
                        cell.x * tileWidth,
                        cell.y * tileHeight,
                        0f
                    );

                    Instantiate(templateBackground, spawnPos, Quaternion.identity, backgroundFolder);
                    spawnedCells.Add(cell);
                }
            }
        }
    }
}
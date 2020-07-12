using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TownGrid : MonoBehaviour
{
    [SerializeField]
    private BuildManager buildManager;
    
    [SerializeField]
    private GameObject tileHolder;

    [SerializeField]
    private Vector2Int size;

    [SerializeField]
    private float addedHeight = 0;

    [SerializeField]
    private Tile tilePreset;

    [SerializeField]
    private Tile[,] grid;

    [SerializeField]
    private Vector2Int[] ocupiedList;

    private void Start()
    {
        grid = new Tile[size.x, size.y];

        for (int x = 0; x < size.x; x++)
        {
            for (int y = 0; y < size.y; y++)
            {
                CreateTile(x, y);
            }
        }   
    }

    private void CreateTile(int x, int y)
    {
        Vector3 gridPosition = new Vector3(x, addedHeight, y);
        Tile currentTile = Instantiate(tilePreset);

        currentTile.transform.SetParent(tileHolder.transform);
        currentTile.transform.localPosition = gridPosition;

        currentTile.Grid = this;
        currentTile.BuildManager = buildManager;
        grid[x, y] = currentTile;

        Vector2Int currentLocation = new Vector2Int(x, y);
        for (int i = 0; i < ocupiedList.Length; i++)
        {
            if (currentLocation == ocupiedList[i])
                currentTile.IsOcupied = true;
        }

        currentTile.debugLocation = currentLocation;
    }

    public Vector2 FindTilePosition(Tile tile)
    {
        for (int x = 0; x < grid.GetLength(0); x++)
        {
            for (int y = 0; y < grid.GetLength(1); y++)
            {
                if(grid[x,y] == tile)
                {
                    return new Vector2Int(x, y);
                }
            }
        }
        return new Vector2(-1, -1);
    }

    public Tile FindTile(Vector2Int locationHype)
    {
        return FindTile(locationHype.x, locationHype.y);
    }

    public Tile FindTile(int x, int y)
    {
        return grid[x, y];
    }

    public bool IsValidPosition(int x, int y) => x < size.x && y < size.y && x >= 0 && y >= 0;
    public bool IsValidPosition(Vector2Int position) => IsValidPosition(position.x, position.y);

    public Vector2Int[] GetNeighbourPositions(Vector2Int nodePosition, bool crossWise = true)
    {
        List<Vector2Int> positions = new List<Vector2Int>();
        for (int x = -1; x < 2; x++)
        {
            for (int y = -1; y < 2; y++)
            {

                if ((!crossWise && (y == 1 || y == -1) && (x == 1 || x == -1)) ||
                    x == 0 && y == 0)
                    continue;

                var position = new Vector2Int(x, y) + nodePosition;
                if (!IsValidPosition(position))
                    continue;

                positions.Add(position);
            }
        }
        return positions.ToArray();

    }

    public Tile[] GetNeighbours(Vector2Int nodePosition, bool crossWise = true, bool allowNull = false)
    {
        Vector2Int[] positions = GetNeighbourPositions(nodePosition, crossWise);
        List<Tile> neighbours = new List<Tile>();
        for (int i = 0; i < positions.Length; i++)
        {
            var neighbour = FindTile(positions[i]);
            if (!allowNull && neighbour == null)
                continue;

            neighbours.Add(FindTile(positions[i]));
        }
        return neighbours.ToArray();
    }
}

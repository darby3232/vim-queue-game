using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Map : MonoBehaviour
{
    public enum TileType
    {
        PATH,
        WALL
    };

    public struct Tile
    {
        public TileType type;
        public GameObject gobj;
        public int x;
        public int y;
    };

    public int gridSize = 40;

    public GameObject wallObject;
    public GameObject pathObject;

    public Transform gridHolder;

    private Tile[,] grid;

    // Start is called before the first frame update
    void Start()
    {
        CreateGrid();
    }

    void CreateGrid()
    {
        gridHolder = new GameObject("Grid").transform;

        grid = new Tile[gridSize, gridSize];

        for (int x = 0; x < grid.GetLength(0); x++)
        {
            for (int y = 0; y < grid.GetLength(1); y++)
            {
                grid[x, y].x = x;
                grid[x, y].y = y;

                if (x % 2 == 0 || y % 2 == 0)
                {
                    grid[x, y].type = TileType.PATH;
                    grid[x, y].gobj = Instantiate(pathObject, new Vector3(x, y, 0f), Quaternion.identity) as GameObject;
                }
                else
                {
                    grid[x, y].type = TileType.WALL;
                    grid[x, y].gobj = Instantiate(wallObject, new Vector3(x, y, 0f), Quaternion.identity) as GameObject;
                }

                grid[x, y].gobj.transform.SetParent(gridHolder);
            }
        }
    }

    public TileType GetTileType(int x, int y)
    {
        return grid[x, y].type;
    }
}

using UnityEngine;

public class GridManager : MonoBehaviour
{
    public int gridSizeX;
    public int gridSizeY;
    public GameObject tilePrefab;
    public UnitController[] units; // Assuming you have an array of units

    private GameObject[,] grid;

    void Start()
    {
        CreateGrid();
    }

    void CreateGrid()
    {
        grid = new GameObject[gridSizeX, gridSizeY];

        for (int x = 0; x < gridSizeX; x++)
        {
            for (int y = 0; y < gridSizeY; y++)
            {
                GameObject tile = Instantiate(tilePrefab, new Vector3(x, y, 0), Quaternion.identity) as GameObject;
                grid[x, y] = tile;
            }
        }

        MoveAllUnitsToClosestTile();

    }

    void MoveAllUnitsToClosestTile()
    {

        UnitController[] units = FindObjectsOfType<UnitController>(); // Get all Unit objects in the scene

        foreach (UnitController unit in units)
        {
            unit.MoveToClosestTile();
        }
    }
}

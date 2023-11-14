using UnityEngine;
using System.Collections;

public class Tile : MonoBehaviour
{
    public Material defaultMaterial;
    public Material highlightMaterial;
    public bool isHighlighted = false;

    GameManager gameManager;
    UnitController selectedUnit;

    Renderer rend;

    void Start()
    {
        rend = GetComponent<Renderer>();
        rend.material = defaultMaterial;
        gameManager = GameManager.instance;
    }

    void OnMouseDown()
    {
        if (isHighlighted)
        {
            if (selectedUnit != null)
            {
                MoveSelectedUnit();
            }
        }
    }

    public void HighlightTile(UnitController unit)
    {
        selectedUnit = unit;
        isHighlighted = true;
        rend.material = highlightMaterial;
    }

    public void ResetTile()
    {
        isHighlighted = false;
        selectedUnit = null;
        rend.material = defaultMaterial;
    }

    void MoveSelectedUnit()
    {
        if (selectedUnit != null)
        {
            selectedUnit.MoveToTile(this.transform.position);
            ResetAdjacentTiles();
            gameManager.CheckPlayerTurnEnd(); // Check if the player's turn is finished after moving
        }
    }

    void ResetAdjacentTiles()
    {
        // Reset all the tiles except the selected one
        Tile[] tiles = FindObjectsOfType<Tile>();
        foreach (Tile tile in tiles)
        {
            if (tile != this)
            {
                tile.ResetTile();
            }
        }
    }
}

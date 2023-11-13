using UnityEngine;

public class Tile : MonoBehaviour
{
    public Material highlightMaterial;
    public LayerMask unitLayer;

    private bool isUnitSelected = false;
    private GameObject selectedUnit;
    private bool isMoving = false;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, Mathf.Infinity, unitLayer))
            {
                if (hit.collider.gameObject.CompareTag("Unit"))
                {
                    if (!isMoving)
                    {
                        isUnitSelected = true;
                        selectedUnit = hit.collider.gameObject;
                        HighlightTiles(selectedUnit.transform.position);
                    }
                }
                else if (isUnitSelected)
                {
                    MoveToTile(hit.point);
                }
            }
        }
    }

    void HighlightTiles(Vector3 unitPosition)
    {
        Collider[] hitColliders = Physics.OverlapSphere(unitPosition, selectedUnit.GetComponent<Unit>().movementRange);
        foreach (Collider col in hitColliders)
        {
            if (col.CompareTag("Tile"))
            {
                col.GetComponent<Renderer>().material = highlightMaterial;
            }
        }
    }

    void MoveToTile(Vector3 destination)
    {
        if (!isMoving)
        {
            isMoving = true;
            selectedUnit.GetComponent<Unit>().Move(destination, this); // Pass reference to the TileHighlight script
            isUnitSelected = false;
            ClearHighlights();
        }
    }

    void ClearHighlights()
    {
        GameObject[] tiles = GameObject.FindGameObjectsWithTag("Tile");
        foreach (GameObject tile in tiles)
        {
            tile.GetComponent<Renderer>().material = null;
        }
    }

    public void SetMovingState(bool state)
    {
        isMoving = state;
    }
}

using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class UnitController : MonoBehaviour
{
    public int movementRange = 3;
    public bool hasGoneThisTurn = false;
    public int lastUnitThing;
    //0 = none
    //1 = walked
    //2 = attacked
    GameManager gameManager;

    public Unit unit;

    public int maxHP;
    public int currentHP;

    public Slider HPSlider;

    void Start()
    {
        gameManager = GameManager.instance;

        maxHP = unit.health;
        currentHP = maxHP;

        HPSlider.maxValue = maxHP;
        HPSlider.value = currentHP;
    }

    public void HighlightAvailableMoves()
    {
        Collider[] hitColliders = Physics.OverlapSphere(transform.position, movementRange);

        foreach (var hitCollider in hitColliders)
        {
            Tile tile = hitCollider.GetComponent<Tile>();
            if (tile != null)
            {
                tile.HighlightTile(this);
            }
        }
    }

    public void MoveToTile(Vector3 position)
    {
        // Move the unit to the selected tile position
        transform.position = position;

        gameManager.EnableButtonOptions();
        
    }

    public void MoveToClosestTile() {

        // Calculate the closest grid position
        int nearestX = Mathf.RoundToInt(this.transform.position.x);
        int nearestY = Mathf.RoundToInt(this.transform.position.y);
        Vector3 closestGridPosition = new Vector3(nearestX, nearestY, 0);

        // Move the unit to the closest grid position
        transform.position = closestGridPosition;

    }

    void OnMouseDown()
    {
        gameManager.SelectUnit(this);
    }

    public void TakeDamage(int damage)
    {
        currentHP -= damage;
        HPSlider.value = currentHP;
    }
}

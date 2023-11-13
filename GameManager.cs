using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public List<Unit> playerUnits;
    public List<Unit> enemyUnits;

    private bool playerTurn = true;
    private bool isPlayerActing = false;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        // Initialize the game with the player's turn
        StartPlayerTurn();
    }

    public void StartPlayerTurn()
    {
        playerTurn = true;
        isPlayerActing = true;
        StartCoroutine(PlayerTurn());
    }

    IEnumerator PlayerTurn()
    {
        foreach (Unit unit in playerUnits)
        {
            // Allow units to move or perform actions
            isPlayerActing = true; // This might be set to false when all units have moved or attacked
            while (unit.isMoving || isPlayerActing)
            {
                yield return null;
            }
        }

        // All player units have acted, end the turn
        EndPlayerTurn();
    }

    void EndPlayerTurn()
    {
        playerTurn = false;
        isPlayerActing = false;
        // Add any necessary logic for enemy turn or next round
    }

    // You'd have similar functions to control the enemy turn, etc.
}

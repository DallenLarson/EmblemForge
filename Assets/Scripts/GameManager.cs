// GameManager class
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Cinemachine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public List<UnitController> playerUnits;
    public List<UnitController> enemyUnits;

    public bool playerTurn = true;
    private bool isPlayerActing = false;

    public CinemachineVirtualCamera virtualCamera; // Reference to the Cinemachine Virtual Camera

    public GameObject buttonOptions; // Reference to the ButtonOptions GameObject
    private bool isButtonOptionsActive = false;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        StartPlayerTurn();
    }

    public void StartPlayerTurn()
    {
        playerTurn = true;
        isPlayerActing = true;

        // Reset all player units for the new turn
        foreach (UnitController unit in playerUnits)
        {
            unit.hasGoneThisTurn = false;
        }

        // Disable buttonOptions at the start of the turn
        DisableButtonOptions();
    }

    public void EndPlayerTurn()
    {
        playerTurn = false;
        isPlayerActing = false;

        // End the player's turn and trigger the enemy's turn or other game logic
        // For example:
        // StartEnemyTurn();
    }

    public void CheckPlayerTurnEnd()
    {
        foreach (UnitController unit in playerUnits)
        {
            if (!unit.hasGoneThisTurn)
                return; // If any unit hasn't gone, return to continue the player's turn
        }
        // All player units have completed their actions
        EndPlayerTurn();
    }

    // Method to handle unit selection and highlighting
    public void SelectUnit(UnitController selectedUnit)
    {
        if (playerTurn && isPlayerActing && !selectedUnit.hasGoneThisTurn && !isButtonOptionsActive)
        {
            selectedUnit.HighlightAvailableMoves();
            FollowSelectedUnit(selectedUnit.transform);
        }
    }

    // Use Cinemachine to follow the selected unit
    private void FollowSelectedUnit(Transform target)
    {
        if (virtualCamera != null)
        {
            virtualCamera.Follow = target;
        }
    }

    // Enable the buttonOptions
    public void EnableButtonOptions()
    {
        isButtonOptionsActive = true;
        if (buttonOptions != null)
        {
            buttonOptions.SetActive(true);
        }
    }

    // Disable the buttonOptions
    public void DisableButtonOptions()
    {
        isButtonOptionsActive = false;
        if (buttonOptions != null)
        {
            buttonOptions.SetActive(false);
        }
    }
}

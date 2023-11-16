// GameManager class
using UnityEngine;
using UnityEngine.UI;
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
    public GameObject attackButton;
    private bool isAttackButtonActive = false;
    private bool isButtonOptionsActive = false;

    public Animator turnChange;
    public Text whosTurnText;
    public Image turnVig;
    public Image turnbg;

    public Color playerColor1;
    public Color playerColor2;
    public Color enemyColor1;
    public Color enemyColor2;

    private UnitController selectedUnit;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        StartPlayerTurn();
    }

    public void Update()
    {
        if (playerTurn)
        {
            CheckPlayerTurnEnd();
        }
    }

    public void StartPlayerTurn()
    {
        RunTurnChange();
        playerTurn = true;
        isPlayerActing = true;

        // Reset all player units for the new turn
        foreach (UnitController unit in playerUnits)
        {
            unit.hasGoneThisTurn = false;
            unit.lastUnitThing = 0; // Set lastUnitThing to 0
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
        StartEnemyTurn();
    }

    public void StartEnemyTurn()
    {
        RunTurnChange();
    }

    public void RunTurnChange()
    {
        if (playerTurn)
        {
            turnVig.color = playerColor1;
            turnbg.color = playerColor2;
            whosTurnText.text = "PLAYER TURN";
        }
        else
        {
            turnVig.color = enemyColor1;
            turnbg.color = enemyColor2;
            whosTurnText.text = "ENEMY TURN";
        }

        turnChange.SetTrigger("turnChange");
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
            this.selectedUnit = selectedUnit; // Set the selected unit
            selectedUnit.HighlightAvailableMoves();
            FollowSelectedUnit(selectedUnit.transform);
        }
    }

    private bool CheckAdjacentEnemy(UnitController selectedUnit)
    {
        foreach (UnitController enemyUnit in enemyUnits)
        {
            float distance = Vector3.Distance(selectedUnit.transform.position, enemyUnit.transform.position);
            if (distance <= 1.0f) // You can adjust the distance as needed
            {
                return true;
            }
        }
        return false;
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

        // Check if the selected unit is next to an enemy unit
        if (CheckAdjacentEnemy(selectedUnit))
        {
            isAttackButtonActive = true;
            attackButton.SetActive(true);
        }
        else
        {
            isAttackButtonActive = false;
            attackButton.SetActive(false);
        }

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

    public void IdleButton()
    {
        selectedUnit.lastUnitThing = 1;
        selectedUnit.hasGoneThisTurn = true;
        DisableButtonOptions();
    }

    public void AttackButton()
    {
        if (isAttackButtonActive)
        {
            UnitController defender = FindAdjacentEnemy(selectedUnit);
            if (defender != null)
            {
                Attack(selectedUnit, defender);
            }
        }
        DisableButtonOptions();
    }

    public void Attack(UnitController attacker, UnitController defender)
    {
        defender.TakeDamage(attacker.unit.strength);
        //EndPlayerTurn();
    }

    private UnitController FindAdjacentEnemy(UnitController selectedUnit)
    {
        foreach (UnitController enemyUnit in enemyUnits)
        {
            float distance = Vector3.Distance(selectedUnit.transform.position, enemyUnit.transform.position);
            if (distance <= 1.0f) // You can adjust the distance as needed
            {
                return enemyUnit;
            }
        }
        return null;
    }



}

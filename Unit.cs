using UnityEngine;
using System.Collections;

public class Unit : MonoBehaviour
{
    public int movementRange = 3;
    public bool isMoving = false;

    public void Move(Vector3 destination, Tile tileHighlightScript)
    {
        isMoving = true;
        StartCoroutine(MoveCoroutine(destination, tileHighlightScript));
    }

    IEnumerator MoveCoroutine(Vector3 destination, Tile tileHighlightScript)
    {
        Vector3 startPosition = transform.position;
        float journeyLength = Vector3.Distance(startPosition, destination);
        float startTime = Time.time;

        while (Vector3.Distance(transform.position, destination) > 0.1f)
        {
            float distCovered = (Time.time - startTime) * 5f;
            float fracJourney = distCovered / journeyLength;
            transform.position = Vector3.Lerp(startPosition, destination, fracJourney);
            yield return null;
        }

        isMoving = false;
        tileHighlightScript.SetMovingState(false);
    }
}

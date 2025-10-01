using UnityEngine;

public class MazeResetter : MonoBehaviour
{
    [Header("Maze Settings")]
    // Drag an empty object from the start of the maze here.
    public Transform resetPoint;
    // We'll drag all the "wrong turn" nodes here.
    public Transform[] wrongTurnNodes;
    // How close you have to get to a wrong turn to be reset.
    public float resetDistance = 2f;

    private CharacterController characterController;

    void Start()
    {
        characterController = GetComponent<CharacterController>();
    }

    void Update()
    {
        // This runs every frame, checking your position.
        CheckForWrongTurn();
    }

    private void CheckForWrongTurn()
    {
        // Loop through every "wrong turn" node we've defined.
        foreach (Transform node in wrongTurnNodes)
        {
            if (node != null)
            {
                // Calculate the distance from the player to the current node.
                float distance = Vector3.Distance(transform.position, node.position);

                // If we are too close, trigger the reset.
                if (distance < resetDistance)
                {
                    ResetPlayerPosition();
                    // We break here to stop checking the other nodes after a reset.
                    break;
                }
            }
        }
    }

    private void ResetPlayerPosition()
    {
        Debug.Log("Wrong turn! Resetting position.");

        // We must disable the CharacterController to teleport the player.
        if (characterController != null && resetPoint != null)
        {
            characterController.enabled = false; // Disable it
            transform.position = resetPoint.position; // Teleport
            characterController.enabled = true; // Re-enable it
        }
    }
}

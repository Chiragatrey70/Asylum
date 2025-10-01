using UnityEngine;
using UnityEngine.SceneManagement; // Required for loading scenes

public class LockedDoor : InteractableObject
{
    [Header("Door Settings")]
    public int requiredDoorID = 0;
    public bool isMainExitDoor = false;

    [Header("Interaction Prompts")]
    public string lockedPrompt = "It's locked.";
    public string openPrompt = "Escape";

    private bool isLocked = true;

    public override void Interact()
    {
        if (isLocked)
        {
            UpdateDoorStatus();
            if (isLocked)
            {
                Debug.Log("Door is still locked.");
                return;
            }
        }
        UnlockDoor();
    }

    private void UnlockDoor()
    {
        Debug.Log("Door Unlocked!");

        if (isMainExitDoor)
        {
            // If this is the main exit, load the end scene.
            SceneManager.LoadScene("EndScene");
        }
        else
        {
            // Otherwise, just destroy the door like normal.
            Destroy(gameObject);
        }
    }

    // This is called by the PlayerController to update the UI prompt
    public void UpdateDoorStatus()
    {
        if (isMainExitDoor)
        {
            if (GameManager.instance.GetMainExitKeyCount() >= 3)
            {
                isLocked = false;
                interactionPrompt = openPrompt;
            }
            else
            {
                interactionPrompt = $"Locked. Requires 3 keys. ({GameManager.instance.GetMainExitKeyCount()}/3)";
            }
        }
        else
        {
            if (GameManager.instance.HasDoorKey(requiredDoorID))
            {
                isLocked = false;
                interactionPrompt = openPrompt; // Changed to use the generic openPrompt
            }
            else
            {
                isLocked = true;
                interactionPrompt = lockedPrompt;
            }
        }
    }
}
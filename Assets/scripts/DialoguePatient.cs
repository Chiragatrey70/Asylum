using UnityEngine;

public class DialoguePatient : InteractableObject
{
    [Header("Dialogue")]
    [TextArea(5, 10)]
    public string dialogueText;

    [Header("Reward")]
    public GameObject mainExitKeyToSpawn; // One of the 3 main keys

    void Start()
    {
        // Make sure the key is hidden at the start
        if (mainExitKeyToSpawn != null)
        {
            mainExitKeyToSpawn.SetActive(false);
        }
    }

    public override void Interact()
    {
        // --- THIS LINE HAS BEEN CHANGED ---
        // We now call the new "ShowTextFile" function to display the dialogue.
        UIManager.instance.ShowTextFile(dialogueText);

        // After showing the dialogue, spawn the key and disappear.
        if (mainExitKeyToSpawn != null)
        {
            mainExitKeyToSpawn.SetActive(true);
        }

        gameObject.SetActive(false);
    }
}

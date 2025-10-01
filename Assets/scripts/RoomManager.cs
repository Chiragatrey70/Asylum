using UnityEngine;

public class RoomManager : MonoBehaviour
{
    [Header("Puzzle Requirements")]
    // Set this in the Inspector to how many items are in the room
    public int memoryItemsRequired = 3;

    [Header("Room Objects")]
    public GameObject patientToSpawn;
    public GameObject keyForNextRoomToSpawn;
    // We will list all the pillow piles that need to disappear here
    public GameObject[] pillowPilesToVanish;

    private int memoryItemsFound = 0;

    void Start()
    {
        // Make sure these are hidden when the room starts
        if (patientToSpawn != null) patientToSpawn.SetActive(false);
        if (keyForNextRoomToSpawn != null) keyForNextRoomToSpawn.SetActive(false);
    }

    // This method will be called by each memory item when it's found
    public void OnMemoryItemFound()
    {
        memoryItemsFound++;
        Debug.Log($"Memory item found! Total: {memoryItemsFound}/{memoryItemsRequired}");

        // Check if all items have been found
        if (memoryItemsFound >= memoryItemsRequired)
        {
            CompletePuzzle();
        }
    }

    private void CompletePuzzle()
    {
        Debug.Log("All memories found! The patient's spirit and a key appear.");

        // Safely loop through the pillow piles and disable them
        foreach (GameObject pile in pillowPilesToVanish)
        {
            // This 'if' statement prevents errors if a slot is empty
            if (pile != null)
            {
                pile.SetActive(false);
            }
        }

        // Spawn the patient
        if (patientToSpawn != null) patientToSpawn.SetActive(true);

        // Spawn the key for the next room
        if (keyForNextRoomToSpawn != null) keyForNextRoomToSpawn.SetActive(true);
    }
}

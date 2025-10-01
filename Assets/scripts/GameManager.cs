using UnityEngine;
using System.Collections.Generic; // Needed to use a List

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    private List<int> collectedDoorKeyIDs = new List<int>();
    private List<int> collectedMainExitKeyIDs = new List<int>();

    private void Awake()
    {
        if (instance != null && instance != this) { Destroy(this.gameObject); }
        else { instance = this; }
    }

    public void AddKey(KeyType type, int id)
    {
        if (type == KeyType.DoorKey && !collectedDoorKeyIDs.Contains(id))
        {
            collectedDoorKeyIDs.Add(id);
            Debug.Log("Collected Door Key ID: " + id);
        }
        else if (type == KeyType.MainExitKey && !collectedMainExitKeyIDs.Contains(id))
        {
            collectedMainExitKeyIDs.Add(id);
            Debug.Log("Collected Main Exit Key ID: " + id);
        }
    }

    // This method lets doors check if we have the specific key they need.
    public bool HasDoorKey(int doorID)
    {
        return collectedDoorKeyIDs.Contains(doorID);
    }

    // This method lets the main exit door check how many keys we have.
    public int GetMainExitKeyCount()
    {
        return collectedMainExitKeyIDs.Count;
    }
}

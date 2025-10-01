using UnityEngine;

// An Enum defines a set of named constants. It makes our code cleaner.
public enum KeyType { DoorKey, MainExitKey }

public class KeyItem : InteractableObject
{
    [Header("Key Settings")]
    public KeyType keyType;
    // For Door Keys, this ID links it to a specific door (e.g., Door 1, Door 2)
    // For Main Exit Keys, this can be 1, 2, or 3.
    public int keyID = 0;

    public override void Interact()
    {
        // Tell the GameManager which specific key we collected.
        GameManager.instance.AddKey(keyType, keyID);
        base.Interact(); // This calls the original Interact() which destroys the object
    }
}

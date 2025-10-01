using UnityEngine;

// An enum to let us choose the file type in the Inspector
public enum FileType { Text, Image }

public class PatientFile : InteractableObject
{
    [Header("File Type")]
    public FileType fileType; // Choose Text or Image from a dropdown

    [Header("File Content")]
    // This field will only be used if the type is Text
    [TextArea(5, 10)]
    public string textContent;

    // This field will only be used if the type is Image
    public Sprite imageContent;


    public override void Interact()
    {
        // Check which type of file this is and call the correct UIManager function.
        if (fileType == FileType.Text)
        {
            UIManager.instance.ShowTextFile(textContent);
        }
        else if (fileType == FileType.Image)
        {
            UIManager.instance.ShowImageFile(imageContent);
        }

        // By removing the SetActive(false) line, the file will remain
        // in the world after you close the UI, allowing you to read it again.
    }
}

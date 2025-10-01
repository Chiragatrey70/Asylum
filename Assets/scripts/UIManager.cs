using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIManager : MonoBehaviour
{
    public static UIManager instance;

    [Header("File Viewer Panel")]
    public GameObject fileViewPanel;
    public TextMeshProUGUI fileContentText; // The text element
    public Image fileImageHolder;       // The image element

    [Header("Item Viewer Panel")]
    public GameObject itemViewPanel;
    public Image itemImage;
    public TextMeshProUGUI itemDescriptionText;

    [Header("Player Reference")]
    public PlayerController playerController;

    private ViewableMemoryItem currentMemoryItem;

    private void Awake()
    {
        if (instance != null && instance != this) { Destroy(this.gameObject); }
        else { instance = this; }
    }

    // --- New, Flexible File Viewer Methods ---
    public void ShowTextFile(string content)
    {
        fileViewPanel.SetActive(true);

        // Show the text, hide the image
        fileContentText.gameObject.SetActive(true);
        fileImageHolder.gameObject.SetActive(false);

        fileContentText.text = content;
        PauseGame();
    }

    public void ShowImageFile(Sprite imageToShow)
    {
        fileViewPanel.SetActive(true);

        // Show the image, hide the text
        fileContentText.gameObject.SetActive(false);
        fileImageHolder.gameObject.SetActive(true);

        fileImageHolder.sprite = imageToShow;
        PauseGame();
    }

    // This single Hide function works for both types
    public void HideFile()
    {
        fileViewPanel.SetActive(false);
        ResumeGame();
    }

    // --- Item Viewer Methods ---
    public void ShowMemoryItem(ViewableMemoryItem memoryItem)
    {
        itemViewPanel.SetActive(true);
        itemImage.sprite = memoryItem.itemSprite;
        itemDescriptionText.text = memoryItem.itemDescription;
        currentMemoryItem = memoryItem;
        PauseGame();
    }

    public void HideMemoryItem()
    {
        itemViewPanel.SetActive(false);
        if (currentMemoryItem != null)
        {
            currentMemoryItem.CompleteInteraction();
            currentMemoryItem = null;
        }
        ResumeGame();
    }

    // --- Helper Methods ---
    private void PauseGame()
    {
        playerController.SetMovement(false);
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    private void ResumeGame()
    {
        playerController.SetMovement(true);
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
}

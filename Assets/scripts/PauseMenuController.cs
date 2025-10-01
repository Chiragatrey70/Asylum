using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenuController : MonoBehaviour
{
    [Header("Pause Menu UI")]
    public GameObject pauseMenuPanel; // Drag the pause menu panel here
    public KeyCode pauseKey = KeyCode.Escape;

    private bool isPaused = false;

    void Start()
    {
        // Make sure the pause menu is hidden at the start
        pauseMenuPanel.SetActive(false);
    }

    void Update()
    {
        // Check if the player presses the pause key
        if (Input.GetKeyDown(pauseKey))
        {
            if (isPaused)
            {
                ResumeGame();
            }
            else
            {
                PauseGame();
            }
        }
    }

    public void PauseGame()
    {
        isPaused = true;
        pauseMenuPanel.SetActive(true);
        Time.timeScale = 0f; // This freezes the entire game

        // Unlock the cursor so the player can click the buttons
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    // This function will be called by the "Resume" button
    public void ResumeGame()
    {
        isPaused = false;
        pauseMenuPanel.SetActive(false);
        Time.timeScale = 1f; // This unfreezes the game

        // Lock the cursor again for gameplay
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    // This function will be called by the "Main Menu" button
    public void LoadMainMenu()
    {
        // Make sure to unpause the game before changing scenes
        Time.timeScale = 1f;
        SceneManager.LoadScene("Start");
    }
}

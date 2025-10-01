using UnityEngine;
using UnityEngine.SceneManagement; // Required for loading and unloading scenes

public class MainMenuController : MonoBehaviour
{
    // This function will be called by the "Start Game" button.
    // Make sure the name of your main game scene is correct.
    public void StartGame()
    {
        // "SafeRoom" should be the exact name of your main game scene file.
        SceneManager.LoadScene("SafeRoom");
    }

    // This function will be called by the "Exit Game" button.
    public void ExitGame()
    {
        // This line will only work in a built version of the game, not in the editor.
        Debug.Log("Quitting game...");
        Application.Quit();
    }
}

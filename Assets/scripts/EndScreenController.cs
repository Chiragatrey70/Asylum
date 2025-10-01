using UnityEngine;
using UnityEngine.SceneManagement;

public class EndScreenController : MonoBehaviour
{
    // This function will be called by the "Replay" button.
    public void ReplayGame()
    {
        // Reloads your main game scene. Make sure the name is correct.
        SceneManager.LoadScene("SafeRoom");
    }

    // This function will be called by the "Exit" button.
    public void ExitGame()
    {
        // This will close the application.
        Debug.Log("Quitting game...");
        Application.Quit();
    }
}

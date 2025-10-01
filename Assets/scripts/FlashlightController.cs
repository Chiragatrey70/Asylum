using UnityEngine;

public class FlashlightController : MonoBehaviour
{
    [Header("Flashlight Settings")]
    public Light flashlight; // Drag your flashlight object here
    public KeyCode toggleKey = KeyCode.F;

    // Optional: Add sound effects for a more polished feel
    // public AudioSource toggleSound; 

    private bool isFlashlightOn = false;

    void Start()
    {
        // Make sure the flashlight is off when the game starts
        if (flashlight != null)
        {
            flashlight.enabled = false;
        }
    }

    void Update()
    {
        // Check if the player presses the toggle key
        if (Input.GetKeyDown(toggleKey))
        {
            ToggleFlashlight();
        }
    }

    void ToggleFlashlight()
    {
        if (flashlight == null) return;

        isFlashlightOn = !isFlashlightOn; // Flip the state
        flashlight.enabled = isFlashlightOn;

        // if (toggleSound != null)
        // {
        //     toggleSound.Play();
        // }
    }
}

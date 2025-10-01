using UnityEngine;

public class AlarmClock : InteractableObject
{
    [Header("Alarm Clock Settings")]
    public Room2_Manager roomManager;

    private AudioSource alarmSound;
    private bool isSilenced = false;

    void Start()
    {
        // Get the AudioSource component attached to this clock
        alarmSound = GetComponent<AudioSource>();
        interactionPrompt = "Silence the alarm";
    }

    public override void Interact()
    {
        if (isSilenced) return; // Do nothing if it's already off

        isSilenced = true;

        // Stop the sound
        if (alarmSound != null)
        {
            alarmSound.Stop();
        }

        // Tell the Room Manager that this alarm has been silenced
        if (roomManager != null)
        {
            roomManager.OnAlarmSilenced();
        }
        else
        {
            Debug.LogError("Room Manager not assigned to this alarm clock!");
        }

        // Disable the object so it can't be used again
        gameObject.GetComponent<Collider>().enabled = false;
        interactionPrompt = "...";
    }
}

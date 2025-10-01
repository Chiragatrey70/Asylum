using UnityEngine;

public class Room2_Manager : MonoBehaviour
{
    [Header("Puzzle Requirements")]
    public int alarmsToSilence = 3;

    [Header("Room Rewards")]
    public GameObject patientToSpawn;
    public GameObject keyForNextRoomToSpawn;

    [Header("Ambiance")]
    public Light mainRoomLight;
    public AudioSource[] alarmSounds;

    [Header("Distance Trigger Settings")]
    public Transform playerTransform; // Drag the Player object here
    public float triggerDistance = 5f; // How close the player needs to be
    private bool hasBeenTriggered = false;

    // --- THIS LINE WAS MISSING ---
    private int alarmsSilenced = 0;

    void Start()
    {
        // Make sure rewards and the main light are off at the start
        if (patientToSpawn != null) patientToSpawn.SetActive(false);
        if (keyForNextRoomToSpawn != null) keyForNextRoomToSpawn.SetActive(false);
        if (mainRoomLight != null) mainRoomLight.enabled = false;
    }

    void Update()
    {
        // This check runs every frame until the alarms are triggered.
        if (!hasBeenTriggered && playerTransform != null)
        {
            // Calculate the distance between this manager object and the player
            float distance = Vector3.Distance(transform.position, playerTransform.position);

            // If the player is close enough, start the alarms
            if (distance < triggerDistance)
            {
                StartAlarms();
                hasBeenTriggered = true; // Make sure this only runs once
            }
        }
    }

    public void StartAlarms()
    {
        Debug.Log("Player is close, starting alarms!");
        foreach (AudioSource alarm in alarmSounds)
        {
            if (alarm != null)
            {
                alarm.Play();
            }
        }
    }

    public void OnAlarmSilenced()
    {
        alarmsSilenced++;
        if (alarmsSilenced >= alarmsToSilence)
        {
            CompletePuzzle();
        }
    }

    private void CompletePuzzle()
    {
        Debug.Log("All alarms silenced! The room is calm.");
        foreach (AudioSource alarm in alarmSounds)
        {
            if (alarm != null) alarm.Stop();
        }
        if (mainRoomLight != null) mainRoomLight.enabled = true;
        if (patientToSpawn != null) patientToSpawn.SetActive(true);
        if (keyForNextRoomToSpawn != null) keyForNextRoomToSpawn.SetActive(true);
    }
}

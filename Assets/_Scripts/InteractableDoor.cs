using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Interactables;

public class InteractableDoor : MonoBehaviour
{
    [SerializeField] private ConfidenceManager confidencemanager;
    [SerializeField] private MicrophoneTracker micTracker;
    [SerializeField] private GazeTracker gazeTracker;

    private void Start()
    {
        var interactable = GetComponent<XRSimpleInteractable>();
        if (interactable != null)
            interactable.selectEntered.AddListener(OnDoorClicked);
    }

    private void OnDoorClicked(SelectEnterEventArgs args)
    {
        SaveStats();
        SceneManager.LoadScene("MainMenu");
    }

    private void SaveStats()
    {
        GameManager.Instance.FinalConfidence = confidencemanager.ConfidenceScore;
        GameManager.Instance.LookPercentage = gazeTracker.GetLookPercentage();
        GameManager.Instance.LongPauseCount = micTracker.LongPauseCount;
        GameManager.Instance.TotalTime = micTracker.TotalTime;
        GameManager.Instance.HasResults = true;
    }
}
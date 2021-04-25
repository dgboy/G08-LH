using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogNPC : Interactable {
    [Header("Dialog Stats")]
    [SerializeField] private SpeakerValue speakerStats = null;
    [SerializeField] private SpeakerValue speakerBuffer = null;
    [SerializeField] private Notification dialogNotif = null;
    [Header("Diary")]
    [SerializeField] private StringValue storyStateBuffer = null;
    // [SerializeField] private Quest questBuffer = null;
    // [SerializeField] private Notification diaryNotif = null;
    private string myStoryState = null;

    public void InitDialog() {
        if (playerInRange) {
            storyStateBuffer.value = myStoryState;
            speakerBuffer.CopyStats(speakerStats);
            dialogNotif.Raise();
        }
    }

    public void SaveStoryState() {
        myStoryState = storyStateBuffer.value;
    }

    protected void OnEnable() {
        isBlocked = true;
        if (speakerStats) {
            speakerStats.quest.InitProgress();
        }
    }
}

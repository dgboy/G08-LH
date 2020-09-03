using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogNPC : Interactable {
    [SerializeField] private TextAsset myDialog = null;
    [SerializeField] private DialogAssetValue dialogBuffer = null;
    [SerializeField] private Notification dialogNotif = null;
    [SerializeField] private StringValue storyStateBuffer = null;
    [SerializeField] private SpriteValue faceSprite = null;
    [SerializeField] private SpeakerValue speakerStats = null;
    [SerializeField] private SpeakerValue speakerBuffer = null;
    private string myStoryState = null;
	private bool isTalking = false;

    public void InitDialog() {
        if (playerInRange) { /*&& !isTalking*/
            dialogBuffer.value = myDialog;
            storyStateBuffer.value = myStoryState;
            speakerBuffer.CopyStats(speakerStats);
            dialogNotif.Raise();
            // BlockClue();
            // isTalking = true;
        }
    }
    
    public void SaveStoryState() {
        myStoryState = storyStateBuffer.value;
    }

    protected void Start() {
        isBlocked = true;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(menuName = "Scriptable Objects/Values/Speaker", fileName = "Speaker")]
public class SpeakerValue : ScriptableObject {
    public string name;
    public Sprite face;
    public TextAsset story;
    public Quest quest;

    public void CopyStats(SpeakerValue speaker) {
        this.name = speaker.name;
        this.face = speaker.face;
        this.story = speaker.story;
        this.quest = speaker.quest;
    }

    public void ClearStats() {
        this.name = null;
        this.face = null;
        this.story = null;
        this.quest = null;
    }
}

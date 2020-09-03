using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(menuName = "Scriptable Objects/Values/Speaker", fileName = "Speaker Value")]
public class SpeakerValue : ScriptableObject {
    public string name;
    public Sprite face;
    public TextAsset story;

    public void CopyStats(SpeakerValue speaker) {
        this.name = speaker.name;
        this.face = speaker.face;
        this.story = speaker.story;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Ink.Runtime;
using TMPro;

public class DialogManager : MonoBehaviour {
    [Header("Dialog Game Objects")]
    [SerializeField] private GameObject dialogBox = null;
    [SerializeField] private GameObject arrorNext = null;
    [SerializeField] private GameObject speakerName = null;
    [SerializeField] private GameObject speakerFace = null;
    [Header("Story Stuff")]
    [SerializeField] private Story myStory = null;
    [SerializeField] private TextMeshProUGUI dialogText = null;
    [SerializeField] private StringValue messageBuffer = null;
    [Header("Speaker Stats")]
    [SerializeField] private SpeakerValue playerSpeaker = null;
    [SerializeField] private SpeakerValue speakerBuffer = null;
    [Header("Story State Stuff")]
    [SerializeField] private StringValue storyStateBuffer = null;
    [SerializeField] private Notification storyStateNotif = null;
    [Header("Diary Stuff")]
    [SerializeField] private Quest questBuffer = null;
    [SerializeField] private Notification diaryNotif = null;
    [Header("Action Map Manager")]
    [SerializeField] private ActionMapManager actionMapManager = null;

    public void StartDialog() {
        if (!dialogBox.activeSelf) {
            LaunchDialog();
        }
        ContinueDialog();
    }

    public void DisplayMessage() {
        dialogBox.SetActive(!dialogBox.activeSelf);
        dialogText.text = dialogBox.activeSelf ? messageBuffer.value : "";
        Time.timeScale = dialogBox.activeSelf ? 0 : 1;
        if (!dialogBox.activeSelf)
            messageBuffer.value = null;
    }


    private void LaunchDialog() {
        Time.timeScale = 0;
        dialogBox.SetActive(true);
        actionMapManager.Change(ActionMap.Dialog);

        questBuffer.CopyStats(speakerBuffer.quest);
        // if (questBuffer.IsExecuted) {
        //     Debug.Log("here");
        //     SaveStoryState("state", 2);
        // }
        if (speakerBuffer.story) {
            myStory = new Story(speakerBuffer.story.text);
            myStory.ObserveVariable("state", SaveStoryState);

            if (storyStateBuffer.value != null) {
                myStory.state.LoadJson(storyStateBuffer.value);
                Debug.Log(myStory.variablesState["state"]);
            }
        }
    }

    private void ContinueDialog() {
        if (myStory.canContinue) {
            string text = myStory.Continue();
            ChangeArrorActive();
            ActiveSpeaker(speakerBuffer);
            MakeNewDialog(text, Color.white);
            // Debug.Log(text);
        } else if (myStory.currentChoices.Count > 0) {
            ActiveSpeaker(playerSpeaker);
            MakeNewDialog(myStory.currentChoices[0].text, new Color(.9f, .8f, .9f));
            myStory.ChooseChoiceIndex(0);
        } else {
            FinishDialog();
        }
    }

    private void FinishDialog() {
        DeactiveSpeaker();
        dialogBox.SetActive(false);
        Time.timeScale = 1;
        actionMapManager.Change(ActionMap.Player);
    }

    private void MakeNewDialog(string text, Color color) {
        dialogText.text = text;
        dialogBox.GetComponent<Image>().color = color;
    }
    private void ChangeArrorActive() {
        arrorNext.SetActive(myStory.canContinue);
    }
    private void ActiveSpeaker(SpeakerValue speaker) {
        speakerName.SetActive(true);
        speakerName.GetComponent<TextMeshProUGUI>().text = speaker.name;
        speakerFace.SetActive(true);
        speakerFace.GetComponent<Image>().sprite = speaker.face;
    }
    private void DeactiveSpeaker() {
        speakerName.SetActive(false);
        speakerFace.SetActive(false);
        // speakerBuffer = null;
    }

    public void SaveStoryState(string varName, object newValue) {
        Story save = new Story(speakerBuffer.story.text);
        save.variablesState[varName] = newValue;
        storyStateBuffer.value = save.state.ToJson();
        storyStateNotif.Raise();
        diaryNotif.Raise();
        // questBuffer.ChangeState((int)newValue);
        speakerBuffer.quest.CopyStats(questBuffer);
    }

    public void SaveStoryState(int newValue) {
        Story save = new Story(speakerBuffer.story.text);
        save.variablesState["state"] = (object)newValue;
        storyStateBuffer.value = save.state.ToJson();
        storyStateNotif.Raise();
        diaryNotif.Raise();
    }
}    

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Ink.Runtime;
using TMPro;

public class DialogManager : MonoBehaviour {
    [SerializeField] private GameObject dialogBox = null;
    [SerializeField] private GameObject arrorNext = null;
    [SerializeField] private Story myStory = null;
    [SerializeField] private TextMeshProUGUI dialogText = null;
    [SerializeField] private DialogAssetValue dialogBuffer = null;
    [SerializeField] private StringValue messageBuffer = null;
    [SerializeField] private StringValue storyStateBuffer = null;
    [SerializeField] private Notification storyStateNotif = null;
    [SerializeField] private Notification inputMapDialogNotif = null;
    [SerializeField] private Notification inputMapPlayerNotif = null;
    [Header("Speaker Stats")]
    [SerializeField] private SpeakerValue playerSpeaker = null;
    [SerializeField] private SpeakerValue speakerBuffer = null;
    [SerializeField] private GameObject speakerName = null;
    [SerializeField] private GameObject speakerFace = null;
    private bool startedDialog = false;

    public void StartDialog() {
        if (!startedDialog) {
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

    private void ContinueDialog() {
        Debug.Log(myStory.canContinue);
        if (myStory.canContinue) {
            ActiveSpeaker(speakerBuffer);
            dialogBox.GetComponent<Image>().color = Color.white;
            string text = myStory.Continue();
            MakeNewDialog(text);
            Debug.Log(text);
        } else {
            if (myStory.currentChoices.Count > 0) {
                // DeactiveSpeaker();
                ActiveSpeaker(playerSpeaker);
                dialogBox.GetComponent<Image>().color = new Color(0.9f, 0.8f, 0.9f);
                MakeNewDialog(myStory.currentChoices[0].text);
                myStory.ChooseChoiceIndex(0);
            } else {
                FinishDialog();
            }
        }

        ChangeActiveArror();
    }

    private void LaunchDialog() {
        Time.timeScale = 0;
        dialogBox.SetActive(true);
        startedDialog = true;
        inputMapDialogNotif.Raise();
        if (dialogBuffer.value) {
            myStory = new Story(dialogBuffer.value.text);
            // if (storyStateBuffer.value != "") {
            //     myStory.state.LoadJson(storyStateBuffer.value);
            // }
        }
    }

    private void FinishDialog() {
        // storyStateBuffer.value = myStory.state.ToJson();
        // storyStateNotif.Raise();
        Time.timeScale = 1;
        dialogBox.SetActive(false);
        startedDialog = false;
        inputMapPlayerNotif.Raise();
        dialogBuffer.value = null;
    }

    private void MakeNewDialog(string text) {
        dialogText.text = text;
    }

    private void ChangeActiveArror() {
        arrorNext.SetActive(/*myStory.currentChoices.Count <= 0 && */myStory.canContinue);
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
    }
}

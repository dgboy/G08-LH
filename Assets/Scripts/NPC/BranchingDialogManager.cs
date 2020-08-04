using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Ink.Runtime;

public class BranchingDialogManager : MonoBehaviour {
    [SerializeField] private GameObject branchingCanvas;
    [SerializeField] private GameObject dialogPrefab;
    [SerializeField] private GameObject choicePrefab;
    [SerializeField] private GameObject dialogHolder;
    [SerializeField] private GameObject choiceHolder;
    [SerializeField] private DialogAssetValue dialogValue;
    [SerializeField] private Story myStory;
    [SerializeField] private ScrollRect dialogScroll;

    public void EnableCanvas() {
        Time.timeScale = 0f;
        branchingCanvas.SetActive(true);
        SetStory();
        RefreshView();
    }

    public void SetStory() {
        if(dialogValue.value) {
            myStory = new Story(dialogValue.value.text);
        } else {

        }
    }

    void DeleteOldDialogs() {
        for (int i = 0; i < dialogHolder.transform.childCount; i++) {
            Destroy(dialogHolder.transform.GetChild(i).gameObject);
        }
        for (int i = 0; i < choiceHolder.transform.childCount; i++) {
            Destroy(choiceHolder.transform.GetChild(i).gameObject);
        }
    }

    public void RefreshView() {
        while (myStory.canContinue) {
            MakeNewDialog(myStory.Continue());
        }

        if (myStory.currentChoices.Count > 0) {
            MakeNewChoices();
        } else {
            DeleteOldDialogs();
            branchingCanvas.SetActive(false);
            Time.timeScale = 1f;
        }
        StartCoroutine(ScrollCo());
    }

    IEnumerator ScrollCo() {
        yield return null;
        dialogScroll.verticalNormalizedPosition = 0f;
    }

    void MakeNewDialog(string newDialog) {
        DialogObject newDialogObject = Instantiate(dialogPrefab, dialogHolder.transform)
            .GetComponent<DialogObject>();

        newDialogObject.Setup(newDialog);
    }

    void MakeNewResponse(string newDialog, int choiceValue) {
        ResponseObject newResponseObject = Instantiate(choicePrefab, choiceHolder.transform)
            .GetComponent<ResponseObject>();

        newResponseObject.Setup(newDialog, choiceValue);
        Button responseButton = newResponseObject.gameObject.GetComponent<Button>();
        if (responseButton) {
            responseButton.onClick.AddListener(delegate {ChooseChoice(choiceValue); });
        }
    }

    void MakeNewChoices() {
        for (int i = 0; i < choiceHolder.transform.childCount; i++) {
            Destroy(choiceHolder.transform.GetChild(i).gameObject);
        }
        for (int i = 0; i < myStory.currentChoices.Count; i++) {
            // Debug.Log(myStory.currentChoices[i].text);
            MakeNewResponse(myStory.currentChoices[i].text, i);
        }
    }

    void ChooseChoice(int choice) {
        myStory.ChooseChoiceIndex(choice);
        RefreshView();
    }
}

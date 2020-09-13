using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


[CreateAssetMenu(menuName = "Scriptable Objects/Quest", fileName = "Quest")]
public class Quest : ScriptableObject {
    public string name;
    [TextArea] public string description;
    [TextArea] public string afterword;
    public InventoryItem[] reward;
    public Task task;
    public Notification diaryNotif = null;
    //available, taken, formed, put, failed
    public enum Status {
        available, received, executed, deposited
    }
    private Status progress = Status.available;


    public Status Progress { get => progress; set => progress = value; }
    public bool IsAvailable { get => progress == Status.available; }
    public bool IsReceived { get => progress == Status.received; }
    public bool IsExecuted { get => progress == Status.executed; }
    public bool IsDeposited { get => progress == Status.deposited; }

    public void InitProgress() { 
        progress = Status.available;
    }

    public void CheckProgress() {
        // Debug.Log(questBuffer.Progress);
        task.CheckProgress();
        if (task.Executed) {
            progress = Status.executed;
            diaryNotif.Raise();
        }
    }

    public Quest(Quest quest) {
        this.name = quest.name;
        this.description = quest.description;
        this.reward = quest.reward;
        this.progress = Status.received;
        this.task = quest.task;
        this.diaryNotif = quest.diaryNotif;
        task.Start();
    }

    public void CopyStats(Quest quest) {
        this.name = quest.name;
        this.description = quest.description;
        this.reward = quest.reward;
        this.progress = quest.progress;
        // this.progress = Status.available;
        this.task = quest.task;
        this.diaryNotif = quest.diaryNotif;
        // task.Start();
    }

    public override bool Equals(object obj) {
        return obj is Quest quest && name == quest.name;
    }

    public void ChangeState(Status progress) {
        this.progress = progress;
    }
    public void ChangeState(int status) {
        switch (status) {
            case (int)Status.received:
                this.progress = Status.received;
                break;
            case (int)Status.executed:
                this.progress = Status.executed;
                break;
            case (int)Status.deposited:
                this.progress = Status.deposited;
                break;
            default:
                this.progress = Status.available;
                break;
        }
        // this.progress = progress;
    }
}
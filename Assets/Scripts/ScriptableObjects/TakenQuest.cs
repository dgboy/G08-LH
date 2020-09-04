using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//available, taken, formed, put, failed

public class TakenQuest : Quest {
    public enum Status {
        received, executed, deposited
    }
    public Status progress = Status.received;

    public void ChangeState(Status progress) {
        this.progress = progress;
    }

    public TakenQuest(Quest quest) : base(quest) {
        this.progress = Status.received;
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(menuName = "Scriptable Objects/Tasks/Kill Mobs", fileName = "Kill Task")]
public class KillTask : Task {
    public int count;
    public int current;

    public override bool Executed { get => executed; }

    public override void Start() {
        base.Start();
        current = 0;
    }

    public override void CheckProgress() {
        if (current < count) {
            current++;
        } 
        if (current == count) {
            executed = true;
        }
    }
}
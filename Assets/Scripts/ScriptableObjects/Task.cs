using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// [CreateAssetMenu(menuName = "Scriptable Objects/Task", fileName = "Task")]
public abstract class Task : ScriptableObject {
    protected bool executed = false;

    public virtual bool Executed { get => executed; }
    public virtual void Start() {
        executed = false;
    }

    public abstract void CheckProgress();
}
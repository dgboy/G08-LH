using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimelineCtrl : MonoBehaviour {
    [SerializeField] private GameObject timeline = null;
    [SerializeField] private BoolValue done = null;

    void Start() {
        if (done.value) {  
            timeline.SetActive(false);
        }
    }

    public void SwitchOffTimeline() {
        done.value = true;
    }
}

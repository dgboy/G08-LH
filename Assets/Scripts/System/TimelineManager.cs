using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class TimelineManager : MonoBehaviour {
    [SerializeField] private Animator playerAnimator = null;
    [SerializeField] private PlayableDirector director = null;
    [SerializeField] private BoolValue done = null;

    private RuntimeAnimatorController playerAnim;
    private bool fix = false;


    void Start() {
        Debug.Log(done.value);
        if (!done.value) {
            playerAnim = playerAnimator.runtimeAnimatorController;
            playerAnimator.runtimeAnimatorController = null;
        } else {
            this.gameObject.SetActive(false);
        }
    }

    void Update() {
        if (director.state != PlayState.Playing && !fix) {
            fix = true;
            playerAnimator.runtimeAnimatorController = playerAnim;
        }
    }

    public void SwitchOffTimeline() {
        done.value = true;
    }
}

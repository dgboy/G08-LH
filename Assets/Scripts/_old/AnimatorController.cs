﻿using UnityEngine;

public class AnimatorController : MonoBehaviour {
    [SerializeField] public Animator anim;

    public void SetAnimParameter(string floatName, float floatValue) {
        anim.SetFloat(floatName, floatValue);
    }

    public void SetAnimParameter(string boolName, bool boolValue) {
        anim.SetBool(boolName, boolValue);
    }

    public float GetAnimFloat(string floatName) {
        return anim.GetFloat(floatName);
    }

    public bool GetAnimBool(string boolName) {
        return anim.GetBool(boolName);
    }
}

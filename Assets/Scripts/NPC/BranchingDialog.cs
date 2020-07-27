using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BranchingDialog : MonoBehaviour {
    [SerializeField] private GameObject branchingCanvas;
    [SerializeField] private GameObject dialogPrefab;
    [SerializeField] private GameObject choicePrefab;
    [SerializeField] private TextAssetValue dialogValue;

    void Start() {
        
    }

    void Update() {
        
    }

    public void EnableCanvas() {
        branchingCanvas.SetActive(true);
    }
}

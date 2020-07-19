using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LocationTransfer : MonoBehaviour {
    public Vector2 cameraChange;
    public Vector3 playerChange;
    private SmoothCamera mainCamera; 

    public GameObject text;
    public Text roomText; 
    public string roomName;
    public bool textActive;

    void Start() {
        mainCamera = Camera.main.GetComponent<SmoothCamera>();
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.CompareTag("Player") && !other.isTrigger) {
            mainCamera.minPos += cameraChange;
            mainCamera.maxPos += cameraChange;
            other.transform.position += playerChange;

            if(textActive) {
                StartCoroutine(locNameCor());
            }
        }
    }

    private IEnumerator locNameCor() {
        text.SetActive(true);
        roomText.text = roomName;
        yield return new WaitForSeconds(2f);
        text.SetActive(false);
    }
}


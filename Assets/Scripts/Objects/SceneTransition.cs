using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransition : MonoBehaviour {
    public string sceneToLoad;
    public Vector2 playerPosition;
    public VectorValue positionStorage;
    public GameObject fadeInPanel;
    public GameObject fadeOutPanel;
    public float fadeWait;

    public void OnTriggerEnter2D(Collider2D other) {
        if(other.CompareTag("Player") && !other.isTrigger) {
            positionStorage.value = playerPosition; 
            //other.GetComponent<Animator>().SetFloat("moveY", 1);
            StartCoroutine(FadeCo());
            //SceneManager.LoadScene(sceneToLoad);
        }
    }

    private void Awake() {
        GameObject panel = Instantiate(fadeInPanel, Vector3.zero, Quaternion.identity) as GameObject;
        Destroy(panel, 1);
    } 

    public IEnumerator FadeCo() {
        if(fadeOutPanel != null)
            Instantiate(fadeOutPanel, Vector3.zero, Quaternion.identity);

        yield return new WaitForSeconds(fadeWait);
        AsyncOperation async = SceneManager.LoadSceneAsync(sceneToLoad);

        while(!async.isDone) {
            yield return null;
        }
    }
}

using UnityEngine;
using System.Collections;

public class FlashColor : MonoBehaviour {

    [SerializeField] private SpriteRenderer mySprite = null;
    [SerializeField] private Color flashColor;
    [SerializeField] private int numberOfFlashes = 3;
    [SerializeField] private float flashDelay = .1f;
    private bool isFlashing = false;

    public void StartFlash() {
        if (!isFlashing) {
            StartCoroutine(FlashCo());
        }
    }

    public IEnumerator FlashCo() {
        isFlashing = true;
        for (int i = 0; i < numberOfFlashes; i++) {
            if (mySprite) {
                mySprite.color = flashColor;
                yield return new WaitForSeconds(flashDelay);
                mySprite.color = Color.white;
                yield return new WaitForSeconds(flashDelay);
            }
        }
        isFlashing = false;
    }
}

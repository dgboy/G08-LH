using System.Collections; 
using System.Collections.Generic; 
using UnityEngine; 

public class Interactable : MonoBehaviour {

    [SerializeField] public StringValue otherTag;
	[SerializeField] public Notification clue;
	protected bool isBlocked = false;
    protected bool playerInRange; 

    protected virtual void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.CompareTag(otherTag.value) && !other.isTrigger) {
            playerInRange = true;
            if (!isBlocked) {
                clue.Raise(); 
            }
        }
    }

    protected virtual void OnTriggerExit2D(Collider2D other) {
        if (other.gameObject.CompareTag(otherTag.value) && !other.isTrigger) {
            playerInRange = false;
            if (!isBlocked) {
                clue.Raise(); 
            }
        }
    }
}

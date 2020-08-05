using System.Collections; 
using System.Collections.Generic; 
using UnityEngine; 

public class Interactable : MonoBehaviour {

    [SerializeField] public bool playerInRange; 
    [SerializeField] public StringValue otherTag;
	[SerializeField] public Notification clue;
	protected bool isBlocked = false;

    public virtual void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.CompareTag(otherTag.value) && !other.isTrigger) {
            playerInRange = true;
            if (!isBlocked) {
                clue.Raise(); 
            }
        }
    }

    public virtual void OnTriggerExit2D(Collider2D other) {
        if (other.gameObject.CompareTag(otherTag.value) && !other.isTrigger) {
            playerInRange = false;
            if (!isBlocked) {
                clue.Raise(); 
            }
        }
    }
}

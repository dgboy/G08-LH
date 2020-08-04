using System.Collections; 
using System.Collections.Generic; 
using UnityEngine; 

public class Interactable : MonoBehaviour {

    [SerializeField] public bool playerInRange; 
    [SerializeField] public StringValue otherTag;
	[SerializeField] public Notification clue; 

    public virtual void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.CompareTag(otherTag.value) && !other.isTrigger) {
            playerInRange = true; 
			clue.Raise(); 
        }
    }

    public virtual void OnTriggerExit2D(Collider2D other) {
        if (other.gameObject.CompareTag(otherTag.value) && !other.isTrigger) {
            playerInRange = false; 
			clue.Raise(); 
        }
    }
}

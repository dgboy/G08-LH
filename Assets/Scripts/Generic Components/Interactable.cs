using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour {

    [SerializeField] public bool playerInRange;
    [SerializeField] public string otherTag;
	[SerializeField] public Notification myNotification;

    public virtual void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag(otherTag) && !other.isTrigger)
        {
            playerInRange = true;
			myNotification.Raise();
        }
    }

    public virtual void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag(otherTag) && !other.isTrigger)
        {
            playerInRange = false;
			myNotification.Raise();
        }
    }
}

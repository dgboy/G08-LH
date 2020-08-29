using UnityEngine;

public class PickedUp : MonoBehaviour {
    [SerializeField] private StringValue otherTag = null;
    [SerializeField] private InventoryItem item = null;

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.CompareTag(otherTag.value) && !other.isTrigger) {
            PlayerInventory inventory = other.gameObject.GetComponent<PlayerInventory>();
            inventory.AddItem(item);
            Destroy(this.gameObject);
        }
    }
}

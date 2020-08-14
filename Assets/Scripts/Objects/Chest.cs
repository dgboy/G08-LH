using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest : Interactable {
    [SerializeField] private PlayerInventory playerInventory = null;
    [SerializeField] private Notification receiveItemNotif = null;
    [SerializeField] private InventoryItem item = null;
    [SerializeField] private BoolValue storedOpen = null;
    private Animator animator;

    void Start() {
        animator = GetComponent<Animator>();
        if (storedOpen.value) {
            animator.SetBool("open", true);
            isBlocked = true;
        }
    }

    public void OpenChest() {
        if (playerInRange && !isBlocked && !storedOpen.value) {
            clue.Raise();
            animator.SetBool("open", true);

            storedOpen.value = true;
            playerInventory.AddItem(item);

            isBlocked = true;
            StartCoroutine(WaitCo());
        }
    }

    private IEnumerator WaitCo() {
        yield return null;
        receiveItemNotif.Raise(); 
    }
}

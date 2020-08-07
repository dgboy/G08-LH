using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest : Interactable {
    [SerializeField] private PlayerInventory playerInventory;
    [SerializeField] private Notification receiveItemNotif;
    [SerializeField] private InventoryItem item;
    [SerializeField] private BoolValue storedOpen;
    private Animator animator;

    void Start() {
        animator = GetComponent<Animator>();
        if (storedOpen.value) {
            animator.SetBool("open", true);
            isBlocked = true;
        }
    }

    void Update() {
        if (Input.GetButtonDown("Check") && playerInRange && !isBlocked) {
            if (!storedOpen.value) {
                OpenChest();
            }
        }
    }

    private void OpenChest() {
        animator.SetBool("open", true);

        storedOpen.value = true;
        playerInventory.AddItem(item);

        clue.Raise();
        isBlocked = true;
        StartCoroutine(WaitCo());
    }

    private IEnumerator WaitCo() {
        yield return null;
        receiveItemNotif.Raise(); 
    }
}

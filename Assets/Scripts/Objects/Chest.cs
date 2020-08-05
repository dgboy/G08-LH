using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Chest : Interactable {
    public Inventory playerInventory;
    public Item item;
    public Notification itemSignal;
    public BoolValue storedOpen;
    public GameObject dialogBox;
    [SerializeField] private TextMeshProUGUI dialogText;
    private Animator animator;

    void Start() {
        animator = GetComponent<Animator>();
        if (storedOpen.value) {
            animator.SetBool("open", true);
            isBlocked = true;
        }
    }

    void Update() {
        if (Input.GetButtonDown("Check") && !isBlocked && playerInRange) {
            OpenChest();
            // StartCoroutine(WaitCo());
        } else if (Input.GetButtonDown("Check") && playerInRange) {
            dialogBox.SetActive(false);
            playerInventory.currentItem = null;
            itemSignal.Raise(); 
        }
    }

    private void OpenChest() {
        animator.SetBool("open", true);
        
        storedOpen.value = true;
        dialogBox.SetActive(true);
        dialogText.text = item.itemDescription;

        playerInventory.AddItem(item);
        playerInventory.currentItem = item;

        itemSignal.Raise();
        clue.Raise();
        isBlocked = true;
    }

    // private void CloseChest() {
    //     dialogBox.SetActive(false);
    //     playerInventory.currentItem = null;
    //     itemSignal.Raise(); 
    // }

    // private IEnumerator WaitCo() {
    //     yield return new WaitForSeconds(2f);

    //     dialogBox.SetActive(false);
    //     playerInventory.currentItem = null;
    //     itemSignal.Raise(); 
    // }
}

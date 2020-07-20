using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Chest : Interactive {

    public Inventory playerInventory;
    public Item item;
    public GameSignal itemSignal;
    public GameObject dialogBox;
    public Text dialogText;
    public BoolValue storedOpen;

    private Animator animator;

    void Start() {
        animator = GetComponent<Animator>();
        if(storedOpen.runtimeValue) {
            animator.SetBool("open", true);
            blocked = true;
        }
    }

    void Update() {
        if(Input.GetButtonDown("Check") && !blocked && playerInRange) {
            OpenChest();
            StartCoroutine(WaitCo());
        }
    }

    private void OpenChest() {
        animator.SetBool("open", true);
        
        storedOpen.runtimeValue = true;
        dialogBox.SetActive(true);
        dialogText.text = item.itemDescription;

        playerInventory.AddItem(item);
        playerInventory.currentItem = item;
        
        itemSignal.Raise();
        clue.Raise(); 

        blocked = true;
    }

    private IEnumerator WaitCo() {
        yield return new WaitForSeconds(2f);

        dialogBox.SetActive(false);
        playerInventory.currentItem = null;
        itemSignal.Raise(); 
    }
}

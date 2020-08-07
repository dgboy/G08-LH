using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
[CreateAssetMenu(fileName = "Inventory", menuName = "Scriptable Objects/Inventory/Inventory")]
public class PlayerInventory : ScriptableObject {
    public List<InventoryItem> myInventory = new List<InventoryItem>();
    public InventoryItem receiveItem;

    public int coins = 0;
    // public int keys = 0;
    // public FloatValue maxMagic;
    // public float currentMagic;

    // public void OnEnable() {
    //     currentMagic = maxMagic.value;
    // }

    // public void DecreaseMagic(float magicCost) {
    //     currentMagic -= magicCost;
    // }

    public bool CheckForItem(InventoryItem item) {
        if(myInventory.Contains(item)) {
            return true;
        }
        return false;
    }

    public void AddItem(InventoryItem itemToAdd) {
        receiveItem = itemToAdd;

        if(!myInventory.Contains(itemToAdd)) {
            myInventory.Add(itemToAdd);
        }
        // if(itemToAdd.isKey) {
        //     keys++;
        // } else {
        // }
    }
}

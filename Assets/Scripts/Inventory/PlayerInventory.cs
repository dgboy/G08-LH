using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Inventory", menuName = "Inventory/Player Inventory", order = 0)]
public class PlayerInventory : ScriptableObject {
    public List<InventoryItem> myInventory = new List<InventoryItem>();

    void Start() {
        
    }

    void Update() {
        
    }
}

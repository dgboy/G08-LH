using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(fileName = "Item", menuName = "Scriptable Objects/Inventory/Item")]
public class InventoryItem : ScriptableObject {
    public string itemName;
    public string itemDescription;
    public Sprite itemImage;
    public int numberHeld;
    public bool usable;
    public bool unique;
    public UnityEvent thisEvent;

    public void Use() {
        Debug.Log("Using " + itemName);
        thisEvent.Invoke();
    }

    public void DecreaseAmount(int amountToDecrease) {
        numberHeld -= (numberHeld > 0) ? amountToDecrease : 0;
    }
}

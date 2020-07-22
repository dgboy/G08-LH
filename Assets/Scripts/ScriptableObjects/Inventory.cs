using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObjects/Inventory", fileName = "Inventory")]
public class Inventory : ScriptableObject, ISerializationCallbackReceiver {

    public Item currentItem;
    public List<Item> items = new List<Item>();
    public int numberOfKeys = 0;
    public int coins = 0;
    public float maxMagic = 10;
    public float currentMagic = 10;

    public Vector2 defaultValue;

    public void OnAfterDeserialize() {
        numberOfKeys = 0;
        coins = 0;
    }
    public void OnBeforeSerialize() {
        
    }

    public void AddItem(Item itemToAdd) {
        if(itemToAdd.isKey) {
            numberOfKeys++;
        } else {
            if(!items.Contains(itemToAdd)) {
                items.Add(itemToAdd);
            }
        }
    }
}

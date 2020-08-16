using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoney : MonoBehaviour {
    [SerializeField] private int maxMoney = 10000;
    [SerializeField] private int currentMoney = 0;

    public void AddMoney(int amount) {
        currentMoney = (currentMoney >= maxMoney) ? currentMoney + amount : maxMoney;
    }

    public void SubtractMoney(int amount) => currentMoney -= amount;
    public bool CanAfford(int price) => (currentMoney >= price);
}

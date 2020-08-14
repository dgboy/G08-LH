using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoney : MonoBehaviour
{
    [SerializeField] private int currentMoney = 0;
    [SerializeField] private int maxMoney = 100000;

    public void AddMoney(int amountToAdd)
    {
        currentMoney += amountToAdd;
        if(currentMoney >= maxMoney)
        {
            currentMoney = maxMoney;
        }
    }


    public bool CanAfford(int price)
    {
        return (currentMoney >= price);
    }


    public void SubtractMoney(int amountToTake)
    {
        currentMoney -= amountToTake;
    }
}

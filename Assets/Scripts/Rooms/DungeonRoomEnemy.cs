﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DungeonRoomEnemy : DungeonRoom {
    public LockedDoor[] doors;

    public void CheckEnemies() {
        for (int i = 0; i < enemies.Length; i++) {
            if (enemies[i].gameObject.activeInHierarchy && i < enemies.Length - 1) {
                return;
            }
            Debug.Log("Here!");
        }
        OpenDoors();
    }

    public void CloseDoors() {
        for (int i = 0; i < doors.Length; i++) {
            doors[i].Close();
        }
    }

    public void OpenDoors() {
        for (int i = 0; i < doors.Length; i++) {
            doors[i].Open();
        }
    }

    public override void OnTriggerEnter2D(Collider2D other) {
        if(other.CompareTag("Player") && !other.isTrigger) {
            for (int i = 0; i < enemies.Length; i++) {
                ChangeActivation(enemies[i], true);
            }
            for (int i = 0; i < pots.Length; i++) {
                ChangeActivation(pots[i], true);
            }
            CloseDoors();
        }
    }
    public override void OnTriggerExit2D(Collider2D other) {
        if(other.CompareTag("Player") && !other.isTrigger) {
            for (int i = 0; i < enemies.Length; i++) {
                ChangeActivation(enemies[i], false);
            }
            for (int i = 0; i < pots.Length; i++) {
                ChangeActivation(pots[i], false);
            }
        }
    }
}
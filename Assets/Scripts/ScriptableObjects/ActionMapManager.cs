using UnityEngine;

public static class ActionMap {
    public const string Player = "Player";
    public const string Dialog = "Dialog";
    public const string Inventory = "Inventory";
    public const string Diary = "Diary";
}

[CreateAssetMenu(menuName = "Scriptable Objects/Action Map Manager", fileName = "Action Map Manager")]
public class ActionMapManager : ScriptableObject {
    [Header("Action Map Notifications")]
    [SerializeField] private Notification playerMap = null;
    [SerializeField] private Notification dialogMap = null;
    // [SerializeField] private Notification inventoryMap = null;
    // [SerializeField] private Notification diaryMap = null;

    public void Change(string map) {
        switch (map) {
            case ActionMap.Player:
                playerMap.Raise();
                break;
            case ActionMap.Dialog:
                dialogMap.Raise();
                break;
            // case ActionMap.Inventory:
            //     inventoryMap.Raise();
            //     break;
            // case ActionMap.Diary:
            //     diaryMap.Raise();
            //     break;
        }
    }
}
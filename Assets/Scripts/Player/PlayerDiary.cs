using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// [System.Serializable]
// [CreateAssetMenu(fileName = "Inventory", menuName = "Scriptable Objects/Inventory/Inventory")]
public class PlayerDiary : MonoBehaviour {
    public List<Quest> quests = new List<Quest>();
    [SerializeField] private Quest questBuffer;
    [SerializeField] private Notification questSaver;

    public void AddQuest() {
        if (IsNewQuest(questBuffer)) {
            quests.Add(new Quest(questBuffer));
        }
    }

    public void UpdateQuestBuffer() {
        questBuffer.Progress = Quest.Status.executed;
    }

    // WIP
    public void UpdateQuest() {
        Debug.Log(questBuffer.Progress);
        if (questBuffer.IsAvailable) {
            if (IsNewQuest(questBuffer)) {
                quests.Add(new Quest(questBuffer));
            }
            questBuffer.Progress = Quest.Status.received;
        } else if (questBuffer.IsReceived) {
            questBuffer.Progress = Quest.Status.executed;
            questSaver.Raise();
        } else if (questBuffer.IsExecuted) {
            questBuffer.Progress = Quest.Status.deposited;
        }
    }

    public bool IsNewQuest(Quest quest) {
        bool newQuest = true;
        quests.ForEach((Quest q) => {
            if (q == quest) {
                newQuest = false;
            }
        });
        return newQuest;
    }
}

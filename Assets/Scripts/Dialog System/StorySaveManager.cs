using UnityEngine;

// WIP
public class StorySaveManager : MonoBehaviour {
    [Header("Story State")]
    [SerializeField] private StringValue storyStateBuffer = null;
    [SerializeField] private Notification storyStateNotif = null;

    // private void SaveStoryState(TextAsset text, string varName, object newValue) {
    //     Story save = new Story(text);
    //     save.variablesState[varName] = newValue;
    //     storyStateBuffer.value = save.state.ToJson();
    //     storyStateNotif.Raise();
    //     questBuffer.CopyStats(speakerBuffer.quest);
    //     diaryNotif.Raise();
    // }
}

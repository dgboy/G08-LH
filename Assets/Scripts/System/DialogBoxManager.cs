using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DialogBoxManager : MonoBehaviour {
    [SerializeField] private Notification dialogNotification;
    [SerializeField] private GameObject dialogBox;
    [SerializeField] private TextMeshProUGUI dialogText;
    [SerializeField] private StringValue stringText;

    public void ChangeDialogBox() {
        dialogBox.SetActive(!dialogBox.activeSelf);
        if (dialogBox.activeSelf) {
            dialogText.text = stringText.value;
        } else {
            dialogText.text = "";
        }
    }
}

using UnityEngine;

class NotifierOnDisable : MonoBehaviour {
    [SerializeField] private Notification notif;

    private void OnDisable() {
        notif.Raise();
    }
}
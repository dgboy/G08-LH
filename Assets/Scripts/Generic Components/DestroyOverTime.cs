using UnityEngine;

public class DestroyOverTime : MonoBehaviour {
    [SerializeField] private float destroyDelay;

    private void Update() {
        destroyDelay -= Time.deltaTime;
        if(destroyDelay <= 0) {
            Destroy(this.gameObject);
        }
    }
}

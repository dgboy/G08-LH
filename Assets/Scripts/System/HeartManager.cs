using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HeartManager : MonoBehaviour {
    public Sprite fullHeart;
    public Sprite halfHeart;
    public Sprite emptyHeart;
    [SerializeField] private PlayerHealth playerHealth = null;
    [SerializeField] private GameObject heart;
    private List<GameObject> hearts = new List<GameObject>();

    public void CreateHeart() {
        GameObject temp = Instantiate(heart, this.transform.position, Quaternion.identity);
        temp.transform.SetParent(this.transform);
        hearts.Add(temp);
    }

    public void UpdateHearts() {
        int max = playerHealth.Max / 2;
        float current = (float)playerHealth.Current / 2;

        Debug.Log(max);
        Debug.Log(hearts.Count);
        if (max > hearts.Count) {
            CreateHeart();
        }

        for (int i = 0; i < max; i++) {
            Image image = hearts[i].GetComponent<Image>();

            if (i + 1 <= current) {
                image.sprite = fullHeart;
            } else if (i >= current) {
                image.sprite = emptyHeart;
            } else {
                image.sprite = halfHeart;
            }
        }
    }

    void Start() {
        InitHearts();
    }

    private void InitHearts() {
        for (int i = 0; i < playerHealth.Max / 2; i++) {
            CreateHeart();
        }
    }
}

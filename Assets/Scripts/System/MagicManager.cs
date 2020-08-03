using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MagicManager : MonoBehaviour {
    public Slider magicSlider;
    public FloatValue playerMP;

    void Start() {
        magicSlider.value = magicSlider.maxValue = playerMP.value;
    }

    public void UpdateMagic() {
        magicSlider.value = playerMP.value;
    }
}

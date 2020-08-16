using System.Collections; 
using System.Collections.Generic; 
using UnityEngine; 
using UnityEngine.UI; 

public class MagicManager : MonoBehaviour {
    public Slider magicSlider;
    [SerializeField] private PlayerMagic playerMagic = null;

    void Start() {
        magicSlider.value = magicSlider.maxValue = playerMagic.Max; 
    }

    public void UpdateMagic() {
        magicSlider.value = playerMagic.Current;
    }
}

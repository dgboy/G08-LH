using System.Text;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

[System.Serializable]
public class LocalizationData {
    public LocalizationItem[] items;
}

[System.Serializable]
public class LocalizationItem {
    public string key;
    public string value;
}

public class LocalizationManager : MonoBehaviour {
    public static LocalizationManager instance;
    public static string defaultLocale = "en_EN";

    private Dictionary<string, string> localizedText;
    private bool isReady = false;
    private string missingTextString = "Localized text not found";

    private void Awake() {
        DontDestroyOnLoad(gameObject);
        if (instance == null) {
            instance = this;
        } else if (instance != this) {
            Destroy(gameObject);
        }

        // SetLocalization ();
        UpdateLocalePreference();
    }

    public void UpdateLocalePreference() {
        string localeName = PlayerPrefs.GetString("locale", defaultLocale);
        LoadLocalizedText(localeName);
    }

    public string GetLocalizedValue(string key) {
        string result = missingTextString;
        if (localizedText.ContainsKey(key)) {
            result = localizedText[key];
        } else {
            Debug.LogError(key + " not found!");
        }

        return result;
    }

    public bool GetIsReady() {
        return isReady;
    }

    private void SetLocalization() {
        switch (Application.systemLanguage) {
            case SystemLanguage.Russian:
                defaultLocale = "ru_RU";
                break;
            case SystemLanguage.English:
                defaultLocale = "en_EN";
                break;
            default:
                defaultLocale = "en_EN";
                break;
        }
    }

    private void LoadLocalizedText(string fileName) {
        localizedText = new Dictionary<string, string>();
        // string filePath = $"{Application.streamingAssetsPath}/locales/{fileName}/{fileName}.json";
        // string dataAsJson = JsonUtility.FromJson<LocalizationData> (filePath);
        // LoadLocalizationData (dataAsJson);

#if UNITY_EDITOR || UNITY_STANDALONE_WIN
        string filePath = $"{Application.streamingAssetsPath}/locales/{fileName}/{fileName}.json";
        LoadLocalizedTextOnIOs(filePath);
#elif UNITY_IOS
		string filePath = Path.Combine (Application.streamingAssetsPath + "/Raw", fileName);
		LoadLocalizedTextOnIOs (filePath);
#elif UNITY_ANDROID
		LoadLocalizedTextOnAndroid (fileName);
#endif
    }

    public void ChangeLocalization() {
        if (defaultLocale == "en_EN") {
            defaultLocale = $"ru_RU";
        } else {
            defaultLocale = $"en_EN";
        }
        UpdateLocalePreference();
    }

    private void LoadLocalizedTextOnIOs(string filePath) {
        if (File.Exists(filePath)) {
            Debug.Log("localization loading from " + filePath);
            string dataAsJson = File.ReadAllText(filePath, Encoding.UTF8);
            LoadLocalizationData(dataAsJson);
        } else {
            Debug.LogError($"Cannot find file: {filePath}");
        }

        isReady = true;
    }

    private string SanitizeReceivedJson(string uglyJson) {
        var sb = new System.Text.StringBuilder(uglyJson);
        sb.Replace("\\\t", "\t");
        sb.Replace("\\\n", "\n");
        sb.Replace("\\\r", "\r");
        return sb.ToString();
    }

    private void LoadLocalizedTextOnAndroid(string fileName) {
        string path = Application.streamingAssetsPath + "/" + defaultLocale;

        WWW www = new WWW(path);
        while (!www.isDone) { }
        string dataAsJson = www.text;

        LoadLocalizationData(dataAsJson);

        isReady = true;
    }

    private void LoadLocalizationData(string dataAsJson) {
        LocalizationData loadedData = JsonUtility.FromJson<LocalizationData>(dataAsJson);
        Debug.Log("loadedData: " + loadedData);

        for (int i = 0; i < loadedData.items.Length; i++) {
            localizedText.Add(loadedData.items[i].key, loadedData.items[i].value);
        }

        Debug.Log("Data loaded, dictionary contains: " + localizedText.Count + " entries");
    }
}

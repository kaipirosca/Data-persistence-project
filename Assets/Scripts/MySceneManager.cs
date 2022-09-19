using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class MySceneManager : MonoBehaviour
{
    public static MySceneManager Instance;

    public string playerName;
    public string bestplayerName = "";
    public int bestScore = 0;

    [System.Serializable]
    class SaveData
    {
        public string bestplayerName;
        public int bestScore;
    }

    public void Save()
    {
        SaveData data = new SaveData();
        data.bestplayerName = bestplayerName;
        data.bestScore = bestScore;

        string json = JsonUtility.ToJson(data);
        File.WriteAllText(Application.persistentDataPath + "/bestScore.json", json);
    }

    public void Load()
    {
        string path = Application.persistentDataPath + "/bestScore.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            bestplayerName = data.bestplayerName;
            bestScore = data.bestScore;
        }
    }

    // Start is called before the first frame update
    private void Awake()
    {
        Load();
        Instance = this;
        DontDestroyOnLoad(gameObject);
    }
}

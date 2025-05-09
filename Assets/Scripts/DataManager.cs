using System.IO;
using UnityEngine;

public class DataManager : MonoBehaviour
{
    public static DataManager Instance;

    public string CurrentPlayerName;    // ��e��J���W�r
    public string HighScoreName;        // �̰��������a�W�r
    public int HighScore;               // �̰�����

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
        LoadData();
    }

    [System.Serializable]
    class HighScoreData
    {
        public string playerName;
        public int highScore;
    }

    public void SaveData()
    {
        HighScoreData data = new HighScoreData();
        data.playerName = HighScoreName;
        data.highScore = HighScore;

        string json = JsonUtility.ToJson(data);
        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }

    public void LoadData()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            HighScoreData data = JsonUtility.FromJson<HighScoreData>(json);

            HighScoreName = data.playerName;
            HighScore = data.highScore;
        }
        else
        {
            HighScoreName = "";
            HighScore = 0;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainManager : MonoBehaviour
{
    public static MainManager instance { get; private set; }

    public string playerName { get; set; }
    public string animalChoice { get; set; }
    public int spawnAmount { get; set; }
    public float moveRange { get; } = 17f;

    private void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
            return;
        }

        instance = this;
        DontDestroyOnLoad(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    /* [System.Serializable]
    class SaveData
    {
        public int playerScore;
    }

    public void SaveScore()
    {
        SaveData data = new SaveData();
        data.playerScore = m_highScore;

        string json = JsonUtility.ToJson(data);

        File.WriteAllText(Application.persistentDataPath + $"/{playerName}savefile.json", json);
    }

    public void LoadScore()
    {
        m_Points = 0;
        string path = Application.persistentDataPath + $"/{playerName}savefile.json";

        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            m_highScore = data.playerScore;
            HighScoreText.text = $"High Score : {m_highScore}";
        }

        else
        {
            m_highScore = 0;
            HighScoreText.text = $"High Score : {m_highScore}";
        }
    } */
}

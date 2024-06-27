using System.IO;
using UnityEngine;

public class MenuManager : MonoBehaviour
{
    public static MenuManager Instance { get; private set; }

    public string newPlayerName;
    public string highScorePlayerName;
    public int highScore = 0;

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(Instance);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(Instance);

        GetScore();
    }

    public class HighScore
    {
        public string playerName;
        public int highScore;
    }

    public void SetScore(int newScore)
    {
        highScore = newScore;

        HighScore data = new HighScore();
        data.highScore = highScore;
        data.playerName = newPlayerName;
        highScorePlayerName = data.playerName;

        string json = JsonUtility.ToJson(data);

        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }

    public void GetScore()
    {
        string path = Application.persistentDataPath + "/savefile.json";

        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            HighScore data = JsonUtility.FromJson<HighScore>(json);

            highScorePlayerName = data.playerName;

            newPlayerName = data.playerName;
            highScore = data.highScore;
        }
    }

    public string GetBestScore()
    {
        return "Best Score : " + highScorePlayerName + ": " + highScore;
    }
}

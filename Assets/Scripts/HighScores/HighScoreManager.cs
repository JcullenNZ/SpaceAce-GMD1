using System.Collections;
using System.IO;
using System.Collections.Generic;
using UnityEngine;
using Unity.Collections;

public class HighScoreManager : MonoBehaviour
{
    public static HighScoreManager Instance;

    private string highScoresFilePath;
    private HighScores highScores; 
    private int numberOfHighScores;
    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

        highScoresFilePath = Path.Combine(Application.persistentDataPath,"highscores.json");
    }
    
    void Start()
    {
        LoadHighScores();
    }
        
    //Saves HighScores list as JSON
    public void SaveHighScores(HighScores highScores)
    {
        string json = JsonUtility.ToJson(highScores,true);
        File.WriteAllText(highScoresFilePath, json);
    }

//Load HighScore JSON file
    public void LoadHighScores()
    {
        if (File.Exists(highScoresFilePath))
        {
            string json = File.ReadAllText(highScoresFilePath);
            highScores = JsonUtility.FromJson<HighScores>(json);
        }
        else
        {
            Debug.Log("HighScore file not found. Making a new one.");
            highScores = new HighScores();
        }
    }

//To check if score is a high score
    public bool IsHighScore(int score)
    {
        
        if(highScores.scores.Count < numberOfHighScores)
        {
            return true;
        }
        return score > highScores.scores[highScores.scores.Count - 1].score;
    }
//To add the high score, maximum according to 'numberOfHighScores'
    public void AddHighScore(string playerName, int score)
    {
        ScoreEntry newScore = new ScoreEntry {playerName = playerName, score = score};

        highScores.scores.Add(newScore);
        highScores.scores.Sort((x,y) => y.score.CompareTo(x.score)); //Sort scores decending (x>y)

        if(highScores.scores.Count > numberOfHighScores)
        {
            highScores.scores.RemoveAt(highScores.scores.Count - 1); //Remove the lowest score
        }
    }

    //Return highScores
    public HighScores GetHighScores()
    {
        return highScores;
    }

}

[System.Serializable]
public class ScoreEntry
{
    public string playerName;
    public int score;
}

[System.Serializable]
public class HighScores
{
    public List<ScoreEntry> scores = new List<ScoreEntry>();
}
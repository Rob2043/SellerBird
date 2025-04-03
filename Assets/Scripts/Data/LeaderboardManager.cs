using System.Collections;
using UnityEngine;
using UnityEngine.Networking;
using System.Collections.Generic;

[System.Serializable]
public class ScoreEntry
{
    public string Rank;
    public string Name;
    public string Score;
}

[System.Serializable]
public class ScoreList
{
    public ScoreEntry[] scores;
}
public class LeaderboardManager : MonoBehaviour
{
    private string googleFormUrl = "https://script.google.com/macros/s/AKfycbw_umRmvyrnjcQ3XXOd-FmIgAAGCadXR6Xbocd-vUHDkKBfENjEwfPa7NPiUINR8CiIPg/exec";

    void Start()
    {
        GetTopScores();
    }

    public void SendScore(string playerName, int score)
    {
        StartCoroutine(SendScoreCoroutine(playerName, score));
    }

    IEnumerator SendScoreCoroutine(string playerName, int score)
    {
        WWWForm form = new WWWForm();
        form.AddField("Name", playerName);
        form.AddField("Score", score);

        using (UnityWebRequest www = UnityWebRequest.Post(googleFormUrl, form))
        {
            yield return www.SendWebRequest();
            if (www.result == UnityWebRequest.Result.Success)
            {
                Debug.Log("Score submitted successfully!");
            }
            else
            {
                Debug.LogError("Error submitting score: " + www.error);
            }
        }
    }

    public void GetTopScores()
    {
        StartCoroutine(GetScoresCoroutine());
    }

    IEnumerator GetScoresCoroutine()
    {
        using (UnityWebRequest www = UnityWebRequest.Get(googleFormUrl))
        {
            yield return www.SendWebRequest();

            if (www.result == UnityWebRequest.Result.Success)
            {
                string jsonText = www.downloadHandler.text;
                jsonText = "{\"scores\":" + jsonText + "}"; // Оборачиваем массив в объект, чтобы JsonUtility мог его обработать

                ScoreList topScores = JsonUtility.FromJson<ScoreList>(jsonText);

                foreach (var entry in topScores.scores)
                {
                    Debug.Log($"Rank: {entry.Rank}, Name: {entry.Name}, Score: {entry.Score}");
                }
            }
            else
            {
                Debug.LogError("Error fetching scores: " + www.error);
            }
        }
    }
}

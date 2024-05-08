using System.Collections;
using System.Collections.Generic;
using System.IO;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Persistence : MonoBehaviour
{
    public HighScore highScore = new HighScore();
    public static Persistence Instance;

    public string playerName;

    // Start is called before the first frame update
    void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);

        LoadScore();

        if(highScore == null){
            highScore = new HighScore();
        }
    }

    [System.Serializable]
    class SaveData{
        public string username;
        public int score;
    }

    public void SaveScore(){
        highScore.username = playerName;

        SaveData data = new SaveData();
        data.username = highScore.username;
        data.score = highScore.score;

        string json = JsonUtility.ToJson(data);
  
        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }

    public void LoadScore(){
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            highScore.username = data.username;
            highScore.score = data.score;
        }
    }

    public void StartButton(){
        SceneManager.LoadScene(1);
    }

    public void UpdateName(TextMeshProUGUI newName){
        playerName = newName.text;
    }
}

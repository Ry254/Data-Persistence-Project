using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HighScore
{
    public string username;
    public int score;

    public string GetString(){
        if(score <= 0){
            return "High Score: 0";
        }
        return "High Score: " + username + " - " + score;
    }

    public HighScore(){
        username = "NoName";
        score = 0;
    }
}

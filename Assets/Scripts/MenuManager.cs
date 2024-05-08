using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MenuManager : MonoBehaviour
{
    public TextMeshProUGUI highScoreText;

    // Start is called before the first frame update
    void Start()
    {
        highScoreText.text = Persistence.Instance.highScore.GetString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

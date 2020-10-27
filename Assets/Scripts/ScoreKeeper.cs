using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreKeeper : MonoBehaviour
{
    private TextMeshProUGUI scoreText;
    public int scoreValue;

    // Start is called before the first frame update
    void Start()
    {
        scoreText = GetComponent<TextMeshProUGUI>();
    }
    public void UpdateScore()
    {
        scoreValue += 5;
        scoreText.text = "Score: " + scoreValue.ToString();
    }




    // Update is called once per frame
    void Update()
    {
        
    }
}

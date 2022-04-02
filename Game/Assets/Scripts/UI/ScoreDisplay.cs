using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreDisplay : MonoBehaviour
{
    //[SerializeField] TextMeshProUGUI totalScoreText;
    //[SerializeField] public int totalScore;
    [SerializeField] Stats playerStats;
    TextMeshProUGUI totalScoreText;

    // Start is called before the first frame update
    void Start()
    {
        totalScoreText = gameObject.GetComponent<TextMeshProUGUI>();
    }

    void Update()
    {
        int score = playerStats.totalScore;
        int maxScore = Stats.maxScore;
        Color baseColor = totalScoreText.color;
        totalScoreText.text = "Score: " + score + "/" + maxScore;
        float newRedValue = 1f - (float)score / maxScore;
        totalScoreText.color = new Color(newRedValue, baseColor.g, baseColor.b);
    }


}

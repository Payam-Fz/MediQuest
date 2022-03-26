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
        totalScoreText.text = "Score: " + playerStats.totalScore;
    }

    // Update is called once per frame
    void UpdateScoreText()
    {
        totalScoreText.text = "Score: " + playerStats.totalScore;
    }


}

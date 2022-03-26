using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class scoreDisplay : MonoBehaviour
{
    public TextMeshProUGUI totalScoreText;
    public int totalScore;

    // Start is called before the first frame update
    void Start()
    {
        totalScore = 0;
        totalScoreText.text = "Score: " + totalScore;
    }

    // Update is called once per frame
    void Update()
    {
        GameObeject player = GameObject.FindGameObjectWithTag("Player");
        totalScore = player.GetComponent<DataContainer>().playerStats;
        totalScoreText.text = "Score: " + totalScore;
    }


}

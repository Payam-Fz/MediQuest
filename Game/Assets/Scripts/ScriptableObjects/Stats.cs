using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//[CreateAssetMenu(fileName = "Stats_player", menuName = "CodeBlue/Player stats")]
public class Stats : MonoBehaviour
{
    public int totalScore = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void increaseScore(int amount) 
    {
        this.totalScore += amount;
    }

    public void decreaseScore(int amount)
    {
        this.totalScore -= amount;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//[CreateAssetMenu(fileName = "Stats_player", menuName = "CodeBlue/Player stats")]
public class Stats : MonoBehaviour
{
    public int totalScore = 80;
    public static int maxScore = 100; 

    // Start is called before the first frame update
    void Start()
    {
        //autoDecreaseScore();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator autoDecreaseScore()
    {
        yield return new WaitForSeconds(10f);
        decreaseScore(5);
        Debug.Log("score decreased");
        autoDecreaseScore();
    }

    public void increaseScore(int amount) 
    {
        totalScore = totalScore + amount > maxScore ? maxScore : totalScore + amount;
    }

    public void decreaseScore(int amount)
    {
        totalScore = totalScore - amount < 0 ? 0 : totalScore - amount;
    }
}

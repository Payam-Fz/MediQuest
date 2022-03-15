using System.Diagnostics;
using UnityEngine;
using UnityEditor;


/* Stores the attributes/data related to the player
 * Author:  Min @ 2022-01-22
 * Update:  Payam F @ 2022-01-29
 */

[System.Serializable]
public class PlayerData
{
    public string ID;
    public string name;
    public int age;
    public double size;
    public Gender gender;
    public int hairColor;
    public int skinColor;
    
    private readonly float[] position;

    public PlayerData(CharacterInfo characterInfo)
    {
        this.ID = characterInfo.ID;
        this.name = characterInfo.Name;
        this.age = characterInfo.age;
        this.size = characterInfo.size;
        this.gender = characterInfo.gender;
        this.hairColor = characterInfo.hairColor;
        this.skinColor = characterInfo.skinColor;

        this.position = new float[2];
        this.position[0] = GameObject.FindGameObjectsWithTag("Player")[0].transform.position.x;
        this.position[1] = GameObject.FindGameObjectsWithTag("Player")[0].transform.position.y;
    }

    public float[] Position => position;

    public float[] Position1 => position;

    public void LoadToObject()
    {
        //const string assetPath = "Assets/Resources/Data/Player";
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        //CharacterInfo charInfo = player.GetComponent<DataContainer>().characterInfo;
        CharacterInfo charInfo = ScriptableObject.CreateInstance<CharacterInfo>();
        charInfo.ID = this.ID;
        charInfo.Name = this.name;
        charInfo.age = this.age;
        charInfo.size = this.size;
        charInfo.gender = this.gender;
        charInfo.hairColor = this.hairColor;
        charInfo.skinColor = this.skinColor;

        player.transform.position.Set(this.position[0], this.position[1], 0);

        player.GetComponent<DataContainer>().characterInfo = charInfo;
    }
}

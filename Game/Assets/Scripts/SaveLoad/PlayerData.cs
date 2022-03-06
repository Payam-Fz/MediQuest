using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;


/* Stores the attributes/data of the patient
 * Author:  Min @ 2022-01-22
 * Update:  Payam F @ 2022-01-29
 */

[System.Serializable]
[DebuggerDisplay("{" + nameof(GetDebuggerDisplay) + "(),nq}")]
public class PlayerData
{
    public readonly string ID;
    public readonly string name;
    public readonly int age;
    public readonly double size;
    public readonly string gender;
    public readonly int hairColor;
    public readonly int skinColor;
    
    private readonly float[] position;

    public PlayerData(CharacterInfo characterInfo)
    {
        this.ID = characterInfo.ID;
        this.name = characterInfo.Name;
        this.age = characterInfo.age;
        this.size = characterInfo.size;
        this.gender = characterInfo.gender.ToString();
        this.hairColor = characterInfo.hairColor;
        this.skinColor = characterInfo.skinColor;

        this.position = new float[2];
        this.position[0] = GameObject.FindGameObjectsWithTag("Player")[0].transform.position.x;
        this.position[1] = GameObject.FindGameObjectsWithTag("Player")[0].transform.position.y;
    }

    public float[] Position => position;

    public float[] Position1 => position;

    public void SavePlayerData()
    {
        SaveLoadSystem.SavePlayerData();
    }

    public void LoadPlayerData()
    {
        const string resource_path = "Assets/Resources/Data/Character";
        CharacterInfo characterInfo = ScriptableObject.CreateInstance<CharacterInfo>();
        
        PlayerData playerData = SaveLoadSystem.LoadPlayerData();

        characterInfo.ID = playerData.ID;
        characterInfo.Name = playerData.name;
        characterInfo.age = playerData.age;
        characterInfo.size = playerData.size;
        characterInfo.gender = playerData.gender.ToString();
        characterInfo.hairColor = playerData.hairColor;
        characterInfo.skinColor = playerData.skinColor;
        GameObject.FindGameObjectsWithTag("Player")[0].transform.position.x = playerData.position[0];
        GameObject.FindGameObjectsWithTag("Player")[0].transform.position.y = playerData.position[1];

        AssetDatabase.CreateAsset(characterInfo, resource_path + "/Player/CharacterInfo_Player.asset");
        AssetDatabase.SaveAssets();
        AssetDatabase.Refresh();
        EditorUtility.FocusProjectWindow();
        Selection.activeObject = characterInfo;
    }

    private string GetDebuggerDisplay()
    {
        return ToString();
    }

}

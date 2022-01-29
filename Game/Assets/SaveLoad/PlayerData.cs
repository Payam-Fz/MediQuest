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

    public PlayerData(CharacterInfo characterInfo, GameObject gameObject)
    {
        ID = characterInfo.ID;
        name = characterInfo.Name;
        age = characterInfo.age;
        size = characterInfo.size;
        gender = characterInfo.gender.ToString();
        hairColor = characterInfo.hairColor;
        skinColor = characterInfo.skinColor;
        
        position =  new float[2];
        position[0] = GameObject.FindGameObjectsWithTag("Player")[0].transform.position.x;
        //Debug.Log();
        position[1] = GameObject.FindGameObjectsWithTag("Player")[1].transform.position.y;
    }

    public float[] Position => position;

    public float[] Position1 => position;

    private string GetDebuggerDisplay()
    {
        return ToString();
    }
}

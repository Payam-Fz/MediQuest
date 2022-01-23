using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;


// Stores the attributes/data of the patient

[System.Serializable]
[DebuggerDisplay("{" + nameof(GetDebuggerDisplay) + "(),nq}")]
public class PlayerData
{
    public readonly string genderCode;
    public readonly int hairColor;
    public readonly int skinColor;
    public readonly double size;

    private readonly float[] position;

    public PlayerData(CharacterInfo characterInfo, GameObject gameObject)
    {
        genderCode = characterInfo.getGender();
        hairColor = characterInfo.getHairColor();
        skinColor = characterInfo.getSkinColor();
        size = characterInfo.getSize();
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

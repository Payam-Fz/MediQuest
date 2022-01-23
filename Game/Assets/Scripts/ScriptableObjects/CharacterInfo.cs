using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/*
 *  Stores the data of a character
 *  Author:     Nokia T @ 2021-10-30
 */
[CreateAssetMenu(fileName = "CharacterInfo_name", menuName = "CodeBlue/Character Info")]
public class CharacterInfo : ScriptableObject 
{
    [Range(0,2)] [SerializeField] public int genderCode;
    [Range(1,10)][SerializeField] public int hairColor;
    [Range(1,10)][SerializeField] public int skinColor;
    [SerializeField] public double size;
    

    public string getGender()
    {
        var enumStatus = (Gender)genderCode;
        string res = enumStatus.ToString();

        return res;
    }

    public int getHairColor()
    {
        return hairColor;
    }

    public int getSkinColor()
    {
        return skinColor;
    }

    public double getSize()
    {
        return size;
    }
}

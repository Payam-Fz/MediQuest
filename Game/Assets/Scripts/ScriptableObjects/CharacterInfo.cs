using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 *  Defines the gender of a character
 *  Author:     Nokia T @ 2021-10-30
 */
public enum Gender
{
    Male = 0,
    Female = 1,
    Other = 2
}

/*
 *  Stores the data of a character
 *  Author:     Nokia T @ 2021-10-30
 */
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

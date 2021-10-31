using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "NPCInfo")]
public class NPCInfo : ScriptableObject 
{
    public enum gender {
        Male = 0,
        Female = 1,
        Other = 2
    }

    [Range(0,2)] [SerializeField] public int genderCode;
    [Range(1,10)][SerializeField] public int hairColor;
    [Range(1,10)][SerializeField] public int skinColor;
    [SerializeField] public double size;
    [SerializeField] public int bedNumber;
    [SerializeField] public int correctDiagnosisID;
    [SerializeField] public int[] nearCorrectDiagnosisID;
    [Range(1,5)][SerializeField] public int difficulty;

    public string getNPCGender()
    {
        var enumStatus = (gender)genderCode;
        string res = enumStatus.ToString();

        return res;
    }

    public int getNPCHairColor()
    {
        return hairColor;
    }

    public int getNPCSkinColor()
    {
        return skinColor;
    }

    public double getNPCSize()
    {
        return size;
    }

    public int getBedNumber()
    {
        return bedNumber;
    }

    public int getCorrectDiag()
    {
        return correctDiagnosisID;
    }

    /*
     * Check if the diagnosis id input by the user is in the set of near correct diagnosis
     */
    public bool checkNearCorrect(int diag)
    {
        for (int i = 0; i < nearCorrectDiagnosisID.Length; i++)
        {
            if (diag == nearCorrectDiagnosisID[i])
            {
                return true;
            }
        }

        return false;
    }

    public int getDiff()
    {
        return difficulty;
    }
}

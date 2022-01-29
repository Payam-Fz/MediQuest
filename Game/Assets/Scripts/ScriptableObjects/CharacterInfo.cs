using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/*
 *  Stores the data of a character
 *  Author:     Nokia T @ 2021-10-30
 *  Updated:    Payam F @ 2022-01-29
 */
[CreateAssetMenu(fileName = "CharacterInfo_name", menuName = "CodeBlue/Character Info")]
public class CharacterInfo : ScriptableObject 
{
    [field: SerializeField] public string ID { get; set; }
    [field: SerializeField] public string Name { get; set; }
    [field: SerializeField] public int age { get; set; }
    [field: SerializeField] public double size { get; set; } = 1;
    [field: SerializeField] public Gender gender { get; set; }
    [Range(1,10)][SerializeField] private int _hairColor = 0;
    [Range(1,10)][SerializeField] private int _skinColor = 0;


    public int hairColor
    {
        get => _hairColor;
        set => _hairColor = value;
    }

    public int skinColor
    {
        get => _skinColor;
        set => _skinColor = value;
    }

}

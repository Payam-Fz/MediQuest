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
    [field: SerializeField] public string Name { get; set; } // Name is capital to distinguish with object name
    [field: SerializeField] public int Age { get; set; }
    [field: SerializeField] public double Size { get; set; } = 1;
    [field: SerializeField] public Gender Gender { get; set; }
    [SerializeField] private SerializableColor _hairColor;
    [SerializeField] private SerializableColor _eyeColor;
    [SerializeField] private SerializableColor _skinColor;
    [SerializeField] private SerializableColor _shirtColor;
    [SerializeField] private SerializableColor _pantsColor;
    [SerializeField] private SerializableColor _shoesColor;
    [SerializeField] private SerializableColor _stethoscopeColor;

    public Color HairColor
    {
        get => _hairColor;
        set => _hairColor = value;
    }

    public Color EyeColor
    {
        get => _eyeColor;
        set => _eyeColor = value;
    }

    public Color SkinColor
    {
        get => _skinColor;
        set => _skinColor = value;
    }

    public Color ShirtColor
    {
        get => _shirtColor;
        set => _shirtColor = value;
    }

    public Color PantsColor
    {
        get => _pantsColor;
        set => _pantsColor = value;
    }

    public Color ShoesColor
    {
        get => _shoesColor;
        set => _shoesColor = value;
    }

    public Color StethoscopeColor
    {
        get => _stethoscopeColor;
        set => _stethoscopeColor = value;
    }

}

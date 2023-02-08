using System.Diagnostics;
using UnityEngine;
using UnityEngine.UI;
using System;


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
    public SerializableColor hairColor;
    public SerializableColor eyeColor;
    public SerializableColor skinColor;
    public SerializableColor shirtColor;
    public SerializableColor pantsColor;
    public SerializableColor shoesColor;
    public SerializableColor stethoscopeColor;

    private readonly float[] position;

    public PlayerData(CharacterInfo characterInfo)
    {
        this.ID = characterInfo.ID;
        this.name = characterInfo.Name;
        this.age = characterInfo.Age;
        this.size = characterInfo.Size;
        this.gender = characterInfo.Gender;

        this.hairColor = characterInfo.HairColor;
        this.eyeColor = characterInfo.EyeColor;
        this.skinColor = characterInfo.SkinColor;
        this.shirtColor = characterInfo.ShirtColor;
        this.pantsColor = characterInfo.PantsColor;
        this.shoesColor = characterInfo.ShoesColor;
        this.stethoscopeColor = characterInfo.StethoscopeColor;

        this.position = new float[2] { -20.6f, -0.6f };
        GameObject playerObject = GameObject.FindGameObjectWithTag("Player");
        if (playerObject)
        {
            this.position[0] = playerObject.transform.position.x;
            this.position[1] = playerObject.transform.position.y;
        }
    }

    public float[] Position => position;

    public void LoadToObject()
    {
        //CharacterInfo charInfo = ScriptableObject.CreateInstance<CharacterInfo>();
        
        try
        {
            CharacterInfo charInfo = Resources.LoadAll<CharacterInfo>("Data/Player")[0];

            charInfo.ID = this.ID;
            charInfo.Name = this.name;
            charInfo.Age = this.age;
            charInfo.Size = this.size;
            charInfo.Gender = this.gender;

            charInfo.HairColor = this.hairColor;
            charInfo.EyeColor = this.eyeColor;
            charInfo.SkinColor = this.skinColor;
            charInfo.EyeColor = this.eyeColor;
            charInfo.EyeColor = this.eyeColor;
            charInfo.EyeColor = this.eyeColor;
            charInfo.EyeColor = this.eyeColor;
        }
        catch (Exception ex)
        {
            UnityEngine.Debug.LogError("Cannot load Player data from resources.");
        }

        

        //GameObject player = GameObject.FindGameObjectWithTag("Player");
        //player.transform.position.Set(this.position[0], this.position[1], 0);
        //player.GetComponent<DataContainer>().characterInfo = charInfo;
    }
}

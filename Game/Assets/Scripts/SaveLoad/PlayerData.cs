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

        this.position = new float[2] { 0f, 0f };
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
        CharacterInfo charInfo = ScriptableObject.CreateInstance<CharacterInfo>();
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

        GameObject player = GameObject.FindGameObjectWithTag("Player");
        player.transform.position.Set(this.position[0], this.position[1], 0);
        player.GetComponent<DataContainer>().characterInfo = charInfo;
        SetSpriteColors(player, charInfo);
    }

    private void SetSpriteColors(GameObject player, CharacterInfo charInfo)
    {
        Transform playerSpritesTransform = player.transform.Find("Sprites");
        Gender gender = charInfo.Gender;
        if (gender == Gender.Male)
        {
            playerSpritesTransform.Find("MaleFeatures").gameObject.SetActive(true);
            playerSpritesTransform.Find("FemaleFeatures").gameObject.SetActive(false);
            playerSpritesTransform.Find("MaleFeatures").Find("Hair_Male").GetComponent<SpriteRenderer>().color = charInfo.HairColor;
        }
        else if (gender == Gender.Female)
        {
            playerSpritesTransform.Find("MaleFeatures").gameObject.SetActive(false);
            playerSpritesTransform.Find("FemaleFeatures").gameObject.SetActive(true);
            playerSpritesTransform.Find("FemaleFeatures").Find("Hair_Female").GetComponent<SpriteRenderer>().color = charInfo.HairColor;
        }
        else
        {
            // no other gender yet
        }
        playerSpritesTransform.Find("Eyes").GetComponent<SpriteRenderer>().color = charInfo.EyeColor;
        playerSpritesTransform.Find("Skin").GetComponent<SpriteRenderer>().color = charInfo.SkinColor;
        playerSpritesTransform.Find("Shirt").GetComponent<SpriteRenderer>().color = charInfo.ShirtColor;
        playerSpritesTransform.Find("Pants").GetComponent<SpriteRenderer>().color = charInfo.PantsColor;
        playerSpritesTransform.Find("Shoes").GetComponent<SpriteRenderer>().color = charInfo.ShoesColor;
        playerSpritesTransform.Find("DoctorFeatures").Find("Stethoscope").GetComponent<SpriteRenderer>().color = charInfo.StethoscopeColor;

    }
}

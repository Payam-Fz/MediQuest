﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CustomizationMenuScript : MonoBehaviour
{
    public GameObject referencePlayerSprites;
    public GameObject sliders;

    public TMP_InputField nameBox;

    

    private Gender gender;

    private SpriteRenderer hairSprite;
    private SpriteRenderer eyeSprite;
    private SpriteRenderer skinSprite;
    private SpriteRenderer shirtSprite;
    private SpriteRenderer pantsSprite;
    private SpriteRenderer shoesSprite;
    private SpriteRenderer stethoscopeSprite;

    private Slider hairSlider;
    private Slider eyeSlider;
    private Slider skinSlider;
    private Slider shirtSlider;
    private Slider pantsSlider;
    private Slider shoesSlider;
    private Slider stethoscopeSlider;

    // Start is called before the first frame update
    void Start()
    {
        hairSlider = sliders.transform.Find("HairSlider").GetComponent<Slider>();
        eyeSlider = sliders.transform.Find("EyeSlider").GetComponent<Slider>();
        skinSlider = sliders.transform.Find("SkinSlider").GetComponent<Slider>();
        shirtSlider = sliders.transform.Find("ShirtSlider").GetComponent<Slider>();
        pantsSlider = sliders.transform.Find("PantsSlider").GetComponent<Slider>();
        shoesSlider = sliders.transform.Find("ShoesSlider").GetComponent<Slider>();
        stethoscopeSlider = sliders.transform.Find("StethoscopeSlider").GetComponent<Slider>();

        //nameBox = GameObject.Find("NameBox").GetComponent<TMP_InputField>();

        //charInfo = Resources.LoadAll<CharacterInfo>("Data/Character/Player");

        hairSprite = referencePlayerSprites.transform.Find("MaleFeatures").Find("Hair_Male").GetComponent<SpriteRenderer>();
        eyeSprite = referencePlayerSprites.transform.Find("Eyes").GetComponent<SpriteRenderer>();
        skinSprite = referencePlayerSprites.transform.Find("Skin").GetComponent<SpriteRenderer>();
        shirtSprite = referencePlayerSprites.transform.Find("Shirt").GetComponent<SpriteRenderer>();
        pantsSprite = referencePlayerSprites.transform.Find("Pants").GetComponent<SpriteRenderer>();
        shoesSprite = referencePlayerSprites.transform.Find("Shoes").GetComponent<SpriteRenderer>();
        stethoscopeSprite = referencePlayerSprites.transform.Find("DoctorFeatures").Find("Stethoscope").GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        UpdateColor(hairSprite, hairSlider.value, 'v');
        UpdateColor(eyeSprite, eyeSlider.value, 'v');
        UpdateColor(skinSprite, skinSlider.value, 'v');
        UpdateColor(shirtSprite, shirtSlider.value, 'h');
        UpdateColor(pantsSprite, pantsSlider.value, 'h');
        UpdateColor(shoesSprite, shoesSlider.value, 'v');
        UpdateColor(stethoscopeSprite, stethoscopeSlider.value, 'h');
        //eyeSprite.color = eyeSlider.value;
        //skinVal = (int)skinSlider.value;
        //hairVal = (int)hairSlider.value;

        //name = nameBox.text;

        //charInfo[0].Name = name;
        //charInfo[0].hairColor = hairVal;
        //charInfo[0].skinColor = skinVal;
    }

    public void SetGender(int genderCode)
    {
        gender = (Gender)genderCode;
        if (gender == Gender.Male)
        {
            referencePlayerSprites.transform.Find("MaleFeatures").gameObject.SetActive(true);
            referencePlayerSprites.transform.Find("FemaleFeatures").gameObject.SetActive(false);
            hairSprite = referencePlayerSprites.transform.Find("MaleFeatures").Find("Hair_Male").GetComponent<SpriteRenderer>();
        }
        else if (gender == Gender.Female)
        {
            referencePlayerSprites.transform.Find("MaleFeatures").gameObject.SetActive(false);
            referencePlayerSprites.transform.Find("FemaleFeatures").gameObject.SetActive(true);
            hairSprite = referencePlayerSprites.transform.Find("FemaleFeatures").Find("Hair_Female").GetComponent<SpriteRenderer>();
        }
        else
        {
            // no other gender yet
        }
        
    }

    public void Submit ()
    {
        CharacterInfo finalCharInfo = ScriptableObject.CreateInstance<CharacterInfo>();
        finalCharInfo.Gender = gender;
        
        if (nameBox.text == null || nameBox.text == "")
        {
            finalCharInfo.Name = "Player";
        } else
        {
            finalCharInfo.Name = nameBox.text;
        }

        finalCharInfo.HairColor = hairSprite.color;
        finalCharInfo.EyeColor = eyeSprite.color;
        finalCharInfo.SkinColor = skinSprite.color;
        finalCharInfo.ShirtColor = shirtSprite.color;
        finalCharInfo.PantsColor = pantsSprite.color;
        finalCharInfo.ShoesColor = shoesSprite.color;
        finalCharInfo.StethoscopeColor = stethoscopeSprite.color;

        GameObject.FindGameObjectWithTag("GameController").GetComponentInChildren<SceneLoader>().customizedPlayer = finalCharInfo;
        //SaveLoadSystem.SavePlayerData(finalCharInfo);
    }

    private void UpdateColor(SpriteRenderer sprite, float newValue, char specific)
    {
        float h, s, v;
        Color.RGBToHSV(sprite.color, out h, out s, out v);
        switch (specific)
        {
            case 'h':
                sprite.color = Color.HSVToRGB(newValue, s, v);
                break;
            case 's':
                sprite.color = Color.HSVToRGB(h, newValue, v);
                break;
            default:
                sprite.color = Color.HSVToRGB(h, s, newValue);
                break;
        }
        
    } 
}

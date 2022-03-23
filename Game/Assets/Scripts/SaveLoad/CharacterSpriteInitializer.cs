using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterSpriteInitializer : MonoBehaviour
{
    void Awake()
    {
        CharacterInfo charInfo = gameObject.GetComponentInParent<DataContainer>().characterInfo;
        if (charInfo != null)
        {
            SetSpriteColors(transform, charInfo);
        }
    }

    private void SetSpriteColors(Transform spritesTransform, CharacterInfo charInfo)
    {
        Gender gender = charInfo.Gender;
        if (gender == Gender.Male)
        {
            spritesTransform.Find("MaleFeatures").gameObject.SetActive(true);
            spritesTransform.Find("FemaleFeatures").gameObject.SetActive(false);
            spritesTransform.Find("MaleFeatures").Find("Hair_Male").GetComponent<SpriteRenderer>().color = charInfo.HairColor;
        }
        else if (gender == Gender.Female)
        {
            spritesTransform.Find("MaleFeatures").gameObject.SetActive(false);
            spritesTransform.Find("FemaleFeatures").gameObject.SetActive(true);
            spritesTransform.Find("FemaleFeatures").Find("Hair_Female").GetComponent<SpriteRenderer>().color = charInfo.HairColor;
        }
        else
        {
            // no other gender yet
        }
        spritesTransform.Find("Eyes").GetComponent<SpriteRenderer>().color = charInfo.EyeColor;
        spritesTransform.Find("Skin").GetComponent<SpriteRenderer>().color = charInfo.SkinColor;
        spritesTransform.Find("Shirt").GetComponent<SpriteRenderer>().color = charInfo.ShirtColor;
        spritesTransform.Find("Pants").GetComponent<SpriteRenderer>().color = charInfo.PantsColor;
        spritesTransform.Find("Shoes").GetComponent<SpriteRenderer>().color = charInfo.ShoesColor;
        spritesTransform.Find("DoctorFeatures").Find("Stethoscope").GetComponent<SpriteRenderer>().color = charInfo.StethoscopeColor;

    }

}

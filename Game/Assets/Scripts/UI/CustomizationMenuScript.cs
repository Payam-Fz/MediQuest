using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CustomizationMenuScript : MonoBehaviour
{

    public Slider skinSlider;
    public Slider hairSlider;
    public Slider eyeSlider;
    public TMP_InputField nameBox;

    public CharacterInfo[] charInfo;



    public int hairVal;   
    public int skinVal;
    public float eyeVal;
    public string name;
    // Start is called before the first frame update
    void Start()
    {
        skinSlider = GameObject.Find("SkinSlider").GetComponent<Slider>();
        hairSlider = GameObject.Find("HairSlider").GetComponent<Slider>();
        eyeSlider = GameObject.Find("EyeSlider").GetComponent<Slider>();
        nameBox = GameObject.Find("NameBox").GetComponent<TMP_InputField>();

        charInfo = Resources.LoadAll<CharacterInfo>("Data/Character/Player");
    }

    // Update is called once per frame
    void Update()
    {
        skinVal = (int)skinSlider.value;
        hairVal = (int)hairSlider.value;
        eyeVal = eyeSlider.value;
        name = nameBox.text;

        charInfo[0].Name = name;
        charInfo[0].hairColor = hairVal;
        charInfo[0].skinColor = skinVal;
    }
}

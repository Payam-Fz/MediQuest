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



    public float hairVal;   
    public float skinVal;
    public float eyeVal;
    public string name;
    // Start is called before the first frame update
    void Start()
    {
        skinSlider = GameObject.Find("SkinSlider").GetComponent<Slider>();
        hairSlider = GameObject.Find("HairSlider").GetComponent<Slider>();
        eyeSlider = GameObject.Find("EyeSlider").GetComponent<Slider>();
        nameBox = GameObject.Find("NameBox").GetComponent<TMP_InputField>();
    }

    // Update is called once per frame
    void Update()
    {
        skinVal = skinSlider.value;
        hairVal = hairSlider.value;
        eyeVal = eyeSlider.value;
        name = nameBox.text;
    }
}

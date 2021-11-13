using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Creates a specific patient object at runtime
 * Author:    Payam F @ 2021-11-05
 */
public class PatientInitializer : MonoBehaviour
{

    public GameObject patientPrefab;

    private static string PATIENT_DATA_PATH;
    private GameObject patientObject;
    private int patientID;
    private PatientInfo patientInfo;
    
    private Gender gender;
    private int hairColor;
    private int skinColor;
    private double scale;
    private int bedNumber;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    /*
     * Creates an instance of patientPrefab and modifies the appearance of it based on
     * the info stored for this patient. Determines the appropriate position for the
     * patient and positions it accordingly
     * @param       ID of the patient
     * @return      the created gameObject
     */
    public GameObject create (int patientID)
    {
        // To determine the position
        patientObject = Instantiate(patientPrefab, new Vector3(0, 0, 0), Quaternion.identity);
        // setsprites (gender, direction)
        // setSkinColor
        // setHairColor
        // setClothingColor
        // rescale
        
        return patientObject;
    }

    private void setSprite (Gender gender, Direction direction) 
    {
        //patientObject.GetComponent<SpriteRenderer>().sprite = Resources.LoadAll<Sprite>("Character/" + piece + type + "/RightFront");
    }
}

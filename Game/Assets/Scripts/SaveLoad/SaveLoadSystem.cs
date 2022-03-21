using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;
using UnityEditor;

/* Stores the attributes/data of the patient
 * Author:  Min @ 2022-03-05
 */

// Save the data of the patient into a file
public static class SaveLoadSystem
{
    const string root_save_path = "/Save_Data";

    private static void CreateSavePath()
    {
        string rootDir = Application.persistentDataPath + root_save_path ;
        if (!Directory.Exists(rootDir + "/Player")) {
            Directory.CreateDirectory(rootDir + "/Player");
        }
        if (!Directory.Exists(rootDir + "/Patients"))
        {
            Directory.CreateDirectory(rootDir + "/Patients");
        }
        if (!Directory.Exists(rootDir + "/Staff"))
        {
            Directory.CreateDirectory(rootDir + "/Staff");
        }
    }
    
    // Save the binary data of the player into a file
    private static void SavePlayerData(CharacterInfo customizedCharInfo = null)
    {
        CharacterInfo characterInfo;
        if (customizedCharInfo == null)
        {
            // Getting player's data from object
            characterInfo = GameObject.FindGameObjectWithTag("Player").GetComponent<DataContainer>().characterInfo;
        } else
        {
            CreateSavePath();
            characterInfo = customizedCharInfo;
        }

        // Saving playerData
        BinaryFormatter formatter = new BinaryFormatter();
        string savePath = Application.persistentDataPath + root_save_path + "/Player" + "/PlayerData.bin";
        FileStream stream = new FileStream(savePath, FileMode.Create);
        PlayerData playerData = new PlayerData(characterInfo);
        formatter.Serialize(stream, playerData);
        Debug.Log("Saved Player's data into " + savePath);
        stream.Close();
    }


    // Save the binary data of the patient instances into its respective files
    private static void SavePatientData()
    {
        BinaryFormatter formatter = new BinaryFormatter();
        FileStream stream;

        var allPatients = GameObject.FindGameObjectsWithTag("Patient");
        string savepath;
        PatientData patientData;
        DiagnosisProgress patientDiagPro;
        DialogueProgress patientDialPro;
        
        foreach (var patient in allPatients)
        {
            // Getting patient's data from objects
            patientDiagPro = patient.GetComponent<DataContainer>().diagnosisProgress;
            patientDialPro = patient.GetComponent<DataContainer>().dialogueProgress;

            // Saving PatientData
            savepath = Application.persistentDataPath + root_save_path + "/Patients/" + patient.name + ".bin";
            patientData = new PatientData(patient.name, patientDialPro, patientDiagPro);
            stream = new FileStream(savepath, FileMode.Create);
            formatter.Serialize(stream, patientData);
            Debug.Log("Saved Patient's data into " + savepath);
            stream.Close();
        }
    }

    // Save the binary data of the staff instances into its respective files
    private static void SaveStaffData()
    {
        BinaryFormatter formatter = new BinaryFormatter();
        FileStream stream;

        var allStaff = GameObject.FindGameObjectsWithTag("Staff");
        string savePath;
        StaffData staffData;
        DialogueProgress staffDialPro;

        foreach (var staff in allStaff)
        {
            // Getting staff's data from objects
            staffDialPro = staff.GetComponent<DataContainer>().dialogueProgress;

            // Saving StaffData
            savePath = Application.persistentDataPath + root_save_path + "/Staff/" + staff.name + ".bin";
            staffData = new StaffData(staff.name, staffDialPro);
            stream = new FileStream(savePath, FileMode.Create);
            formatter.Serialize(stream, staffData);
            Debug.Log("Saved Staff's data into " + savePath);
            stream.Close();
        }
    }
    

    // Load the data of the Player from a file/path
    private static void LoadPlayerData()
    {
        string savedPath = Application.persistentDataPath + root_save_path + "/Player" + "/PlayerData.bin";
        if (File.Exists(savedPath))
        {
            // Getting PlayerData from saved file
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(savedPath, FileMode.Open);

            // Loading PlayerData
            PlayerData data = formatter.Deserialize(stream) as PlayerData;
            data.LoadToObject();
            stream.Close();
            Debug.Log("Loaded Player's data from " + savedPath);
        }
        else
        {
            Debug.LogError("File not found in " + savedPath);
        }
    }


    // Load the data of the Patients from its respective files/paths
    private static void LoadPatientData()
    {
        string rootSavedPath = Application.persistentDataPath + root_save_path + "/Patients/";
        var allPatientsBinFiles = Directory.GetFiles(rootSavedPath);
        BinaryFormatter formatter = new BinaryFormatter();
        FileStream stream;
        PatientData data;

        foreach (string patientBinFile in allPatientsBinFiles)
        {
            if (File.Exists(patientBinFile))
            {
                // Getting PatientData from saved file
                stream = new FileStream(patientBinFile, FileMode.Open);

                // Loading PatientData
                data = formatter.Deserialize(stream) as PatientData;
                data.LoadToObject();
                stream.Close();
                Debug.Log("Loaded Patient's data from " + patientBinFile);
            }
            else
            {
                Debug.LogError("File not found in " + rootSavedPath);
            }
        }
    }

    // Load the data of the Staffs from its respective files/paths
    private static void LoadStaffData()
    {
        string rootSavedPath = Application.persistentDataPath + root_save_path + "/Staff/";
        var allStaffBinFiles = Directory.GetFiles(rootSavedPath);
        BinaryFormatter formatter = new BinaryFormatter();
        FileStream stream;
        StaffData data;

        foreach (string staffBinFile in allStaffBinFiles)
        {
            if (File.Exists(staffBinFile))
            {
                // Getting StaffData from saved file
                stream = new FileStream(staffBinFile, FileMode.Open);

                // Loading StaffData
                data = formatter.Deserialize(stream) as StaffData;
                data.LoadToObject();
                stream.Close();
                Debug.Log("Loaded Staff's data from " + staffBinFile);
            }
            else
            {
                Debug.LogError("File not found in " + rootSavedPath);
            }
        }
    }

    public static void SaveAllData()
    {
        CreateSavePath();

        SavePlayerData();
        SavePatientData();
        SaveStaffData();
    }

    public static void LoadAllData()
    {
        LoadPlayerData();
        LoadPatientData();
        LoadStaffData();

        //probably unnecessary
        AssetDatabase.SaveAssets();
        AssetDatabase.Refresh();
    }
}

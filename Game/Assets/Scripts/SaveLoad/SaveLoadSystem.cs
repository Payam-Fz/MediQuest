using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

/* Stores the attributes/data of the patient
 * Author:  Min @ 2022-03-05
 */

// Save the data of the patient into a file
public static class SaveLoadSystem
{
    const string player_path = "/MediQuest/PlayerData.bin";
    const string patient_path = "/MediQuest/PatientData/";
    const string staff_path = "/MediQuest/StaffData/";
    const string resource_path = "Data/Character";


    // Save the binary data of the player into a file
    public static void SavePlayerData()
    {
        BinaryFormatter formatter = new BinaryFormatter();
        var Player_Folder = Directory.GetDirectories(resource_path + "/Player");
        CharacterInfo characterInfo = Resources.Load<CharacterInfo>(Player_Folder);

        string path = Application.persistentDataPath + player_path + Player_Folder + ".bin";
        FileStream stream = new FileStream(path, FileMode.Create);
        PlayerData playerData = new PlayerData(characterInfo);

        formatter.Serialize(stream, playerData);
        Debug.log("Saved Player into" + path);
        stream.Close();
    }

    // Save the binary data of the patient instances into its respective files
    public static void SavePatientData()
    {
        BinaryFormatter formatter = new BinaryFormatter();
        var Patient_Folders = Directory.GetDirectories(resource_path + "/Patients");
        DiagnosisProgress patientDiagPro;
        DialogueProgress patientDialPro;
        foreach (var patient_folder in Patient_Folders)
        {
            patientDiagPro = Resources.Load<DiagnosisProgress>(patient_folder);
            patientDialPro = Resources.Load<DialogueProgress>(patient_folder);

            string path = Application.persistentDataPath + patient_path + patient_folder + ".bin";
            FileStream stream = new FileStream(path, FileMode.Create);
            PatientData patientData = new PatientData(patientDialPro, patientDiagPro);

            formatter.Serialize(stream, patientData);
            Debug.log("Saved Patient into" + path);
            stream.Close();
        }
    }

    // Save the binary data of the staff instances into its respective files
    public static void SaveStaffData()
    {
        BinaryFormatter formatter = new BinaryFormatter();
        var Staff_Folders = Directory.GetDirectories(resource_path + "/Staff");
        DialogueProgress staffDialPro;
        foreach (var staff_folder in Staff_Folders)
        {
            staffDialPro = Resources.Load<DialogueProgress>(staff_folder);

            string path = Application.persistentDataPath + staff_path + staff_folder + ".bin";
            StaffData staffData = new StaffData(staffDialPro);
            FileStream stream = new FileStream(path, FileMode.Create);

            formatter.Serialize(stream, staffData);
            Debug.log("Saved Staff into" + path);
            stream.Close();
        }
    }
    

    // Load the data of the Player from a file/path
    public static PlayerData LoadPlayerData()
    {
        string path = Application.persistentDataPath + player_path + Player_Folder + ".bin";
        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            PlayerData data = formatter.Deserialize(stream) as PlayerData;
            Debug.log("Loaded from" + path);
            stream.Close();

            return data;
        }
        else
        {
            Debug.LogError("File not found in " + path);
            return null;
        }
    }


    // Load the data of the Patients from its respective files/paths
    public static PatientData LoadPatientData()
    {
        string path = Application.persistentDataPath + player_path + Player_Folder + ".bin";
        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            PlayerData data = formatter.Deserialize(stream) as PlayerData;
            Debug.log("Loaded from" + path);
            stream.Close();

            return data;
        }
        else
        {
            Debug.LogError("File not found in " + path);
            return null;
        }
    }

    // Load the data of the Staffs from its respective files/paths
    public static StaffData LoadStaffData()
    {
        return null;
    }
}

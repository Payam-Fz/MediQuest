using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

// Save the data of the patient into a file
public static class SaveSystem
{
    public static void SavePatientInfo(PatientMedicalInfo patientInfo, GameObject gameObject)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = getPath();
        FileStream stream = new FileStream(path, FileMode.Create); // Create or Append

        PlayerData data = new PlayerPatientData(patientInfo, gameObject);

        formatter.Serialize(stream, data);
        stream.Close();
    }

    // Load the data of the patient from a file
    public static PlayerPatientData LoadPatientInfo()
    {
        string path = getPath();
        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            PlayerPatientData data = formatter.Deserialize(stream) as PlayerPatientData;
            stream.Close();

            return data;
        }
        else
        {
            Debug.LogError("File not found in " + path);
            return null;
        }
    }

    // Get the path to the binary code file
    public static string getPath()
    {
        return Application.persistentDataPath + "/MediQuest/PatientData.bin";
    }
}

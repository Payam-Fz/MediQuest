using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

// Save the data of the patient into a file
public static class SaveSystem
{
    public static void SavePatientInfo(MedicalInfo patientInfo, GameObject gameObject)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = getPath();
        FileStream stream = new FileStream(path, FileMode.Create); // Create or Append

        PatientData data = new PatientData(patientInfo, gameObject);

        formatter.Serialize(stream, data);
        stream.Close();
    }

    // Load the data of the patient from a file
    public static PatientData LoadPatientInfo()
    {
        string path = getPath();
        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            PatientData data = formatter.Deserialize(stream) as PatientData;
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

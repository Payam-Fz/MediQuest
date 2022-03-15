using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "Queue", menuName = "CodeBlue/Queue")]
public class Queue : ScriptableObject {

public List<string> queue = new List<string>();  
public int maxSize;

public int getQueueSize() {
    return queue.Count;
}

public void queueAdd(string objectName) {
    if (getQueueSize() < maxSize) {
        queue.Add(objectName);
    }
}

public string getName(int i) {
    if(i <= getQueueSize()) {
        return getNameFromRef(queue[i-1]);
    } else {
        return "error";
    }
}

private string getNameFromRef(string objectName) {
    GameObject patient = GameObject.Find(objectName);
    if (patient.tag != "Patient")
            {
                Debug.LogError("Patient object with name = " + name + " not found. ");
                return "error";
            }
    return patient.GetComponent<DataContainer>().characterInfo.name;
}

}

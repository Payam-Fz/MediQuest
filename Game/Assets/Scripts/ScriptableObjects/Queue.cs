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

public void queueAdd(string id) {
    if (getQueueSize() < maxSize) {
        queue.Add(id);
    }
}

public string getId(int i) {
    if(i <= getQueueSize()) {
        return queue[i-1];
    } else {
        return "error";
    }
}

public string getNameFromRef(string s) {
    return GameObject.Find(s).GetComponent<DataContainer>().CharacterInfo.name;
}

}

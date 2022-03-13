using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

public class LabTestButton : MonoBehaviour, IPointerDownHandler {
 
private string charID;
private Queue[] queue;

void Start() {
    queue = Resources.LoadAll<Queue>("Data/Queue");
}

public void OnPointerDown (PointerEventData eventData){
    queue[0].queueAdd("1234");
}

}
 

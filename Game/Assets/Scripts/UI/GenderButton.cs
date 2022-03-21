using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
 


public class GenderButton : MonoBehaviour, IPointerDownHandler {
 
public Gender genderValue;
private CharacterInfo[] charInfo;


void Start() {
    charInfo = Resources.LoadAll<CharacterInfo>("Data/Character/Player");
}
 
public void OnPointerDown(PointerEventData eventData){
    charInfo[0].Gender = genderValue;

}
 

}